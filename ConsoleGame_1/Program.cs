using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleGame_1
{
    class Program
    {
        static void Main(string[] args)

        {

            Random rnd = new Random();

            Robot user = new Robot(2, 12, 3, 5);
            Robot pc = new Robot(1, 13, 3, 0);

            Console.WriteLine("Давайте сыграем! Ваша задача выжить и убить противника.");
            Console.WriteLine("Показатель здоровья вашего робота: {0}, количество патронов: {1}", user.hp, user.bullets);
            Console.WriteLine("Показатель здоровья робота противника: {0}, количество патронов: {1}", pc.hp, pc.bullets);
            Console.WriteLine("____________Начинаем!____________");


            while (user.hp > 0 & pc.hp > 0)
            {
                Console.Write("Что будете делать? \n 1. Выстрел \n 2. Исцеление \n 3. Купить патроны \n");

                string move = Console.ReadLine();

                switch (move)
                {
                    case "1":
                        user.Shot(pc);
                        break;
                    case "2":
                        user.Heal();
                        break;
                    case "3":
                        user.Purchase();
                        break;
                    default:
                        Console.WriteLine("Команда введена неверно! Попробуйте еще раз.");
                        continue;

                }

                if (pc.hp < 0) break;

                int move_1 = rnd.Next(1, 4);

                switch (move_1)
                {
                    case 1:
                        if (pc.hp < pc.max_hp)
                        {
                            pc.Heal();
                            Console.WriteLine("Противник лечится.");
                        }
                        else continue;
                        break;

                    case 2:
                        if (pc.bullets > 0)
                        {
                            pc.Shot(user);
                            Console.WriteLine("Противник стреляет!!!");
                        }
                        else
                        {
                            pc.Purchase();
                            Console.WriteLine("Противник покупает патроны.");
                        }
                        break;

                    case 3:
                        pc.Purchase();
                        Console.WriteLine("Противник покупает патроны.");
                        break;

                }

                Console.WriteLine("___________________________");
                Console.WriteLine("| Ваши  показатели |   Очки здоровья: {0}    Патроны: {1}", user.hp, user.bullets);
                Console.WriteLine("| Показатели врага |   Очки здоровья: {0}    Патроны: {1} \n", pc.hp, pc.bullets);


            }


            if (user.hp <= 0) Console.WriteLine("Поражение! Противник оказался сильнее...");
            else if (pc.hp <= 0) Console.WriteLine("Вы устранили противника! Победа!");

        }
    }
}