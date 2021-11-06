using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_1
{
    class Robot
    {
        public int armor, hp, damage, bullets, max_hp;
        public Robot(int a, int b, int c, int d) { armor = a; hp = b; damage = c; bullets = d; max_hp = b; }

        public void GetInfo()
        {
            Console.WriteLine($"Броня: {armor}  Жизнь: {hp}  Урон: {damage} Патроны: {bullets}");
        }

        public void Shot(Robot def)
        {

            if (bullets > 0)
            {
                def.hp = def.hp - damage + def.armor;
                bullets = bullets - 1;

            }

            else Console.WriteLine("Недостаточно патронов!");

        }

        public void Heal()
        {
            int n = 2;

            if (hp < max_hp)
            {
                hp = hp + n;
            }

            else
            {
                Console.WriteLine("У вас достаточно здоровья!");

            }
        }

        public void Purchase()
        {
            int m = 1;
            bullets = bullets + m;
        }
    }
}
