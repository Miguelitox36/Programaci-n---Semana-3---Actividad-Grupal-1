using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3___Actividad_Grupal_1
{
    class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Health { get; set; }

        public Player(string name, int strength, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Health = health;
        }

        public void CreatePlayer()
        {
            Console.WriteLine("Creación de jugador:");
            Console.Write("Nombre: ");
            Name = Console.ReadLine();
            Console.Write("Fuerza (0-100): ");
            Strength = int.Parse(Console.ReadLine());
            Console.Write("Destreza (0-" + (100 - Strength) + "): ");
            Dexterity = int.Parse(Console.ReadLine());
            Health = 100 - Strength - Dexterity;
        }
    }
}
