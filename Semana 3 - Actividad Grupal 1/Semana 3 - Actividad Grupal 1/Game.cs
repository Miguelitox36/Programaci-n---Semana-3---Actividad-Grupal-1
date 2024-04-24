using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3___Actividad_Grupal_1
{
    class Game
    {
        private Player player;
        private List<DialogueOption> dialogueOptions;
        private List<Item> items;

        public Game()
        {
            dialogueOptions = new List<DialogueOption>();            
            dialogueOptions.Add(new DialogueOption("¡Hola aventurero! ¿Qué camino quieres tomar?", 0, 0, 0));
            dialogueOptions.Add(new DialogueOption("Atravesar el bosque oscuro", 20, 0, -10));
            dialogueOptions.Add(new DialogueOption("Explorar las montañas", 0, 30, -5));
            dialogueOptions.Add(new DialogueOption("Descansar en la posada", 0, 0, 10));

            items = new List<Item>();            
            items.Add(new Item("Poción de salud", 20, 0, 0));
            items.Add(new Item("Elixir de fuerza", 0, 10, 0));
            items.Add(new Item("Poción de destreza", 0, 0, 10));
        }

        public void Start()
        {
            Console.WriteLine("¡Bienvenido al juego de aventura de texto!");
            player = new Player("", 0, 0, 0);
            player.CreatePlayer();

            bool gameOver = false;

            while (!gameOver)
            {
                Console.WriteLine("Diálogo:");

                foreach (var option in dialogueOptions)
                {
                    Console.WriteLine(option.Text);
                }

                Console.Write("Selecciona una opción (1-" + dialogueOptions.Count + "): ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                DialogueOption selectedOption = dialogueOptions[choice];
                if (selectedOption.RequiredStrength <= player.Strength &&
                    selectedOption.RequiredDexterity <= player.Dexterity)
                {
                    player.Health += selectedOption.HealthChange;

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("¡Has perdido! Tu aventura ha llegado a su fin.");
                        gameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("Has elegido: " + selectedOption.Text);
                    }
                }
                else
                {
                    Console.WriteLine("No tienes los requisitos necesarios para esta opción.");
                }

                Console.WriteLine("Ítems disponibles:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + items[i].Name);
                }

                Console.Write("Selecciona un ítem para usar (1-" + items.Count + "): ");
                int itemChoice = int.Parse(Console.ReadLine()) - 1;

                Item selectedItem = items[itemChoice];
                player.Health += selectedItem.HealthIncrease;
                player.Strength += selectedItem.TemporaryStrengthIncrease;
                player.Dexterity += selectedItem.TemporaryDexterityIncrease;

                if (player.Health <= 0)
                {
                    Console.WriteLine("¡Has perdido! Tu aventura ha llegado a su fin.");
                    gameOver = true;
                }
                else
                {
                    if (player.Strength >= 80)
                    {
                        Console.WriteLine("¡Felicidades! Has alcanzado el final 1. Eres un héroe poderoso.");
                    }
                    else if (player.Dexterity >= 80)
                    {
                        Console.WriteLine("¡Felicidades! Has alcanzado el final 2. Tu destreza te ha llevado a la victoria.");
                    }
                    else
                    {
                        Console.WriteLine("¡Has llegado al final del juego!");
                    }

                    gameOver = true;
                }
            }
        }
    }
}