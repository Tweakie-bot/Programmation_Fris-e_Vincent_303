using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class MainMenuState : IState
    {
        ConsoleKey _key;
        StateMachine _machine;
        public MainMenuState(StateMachine machine) { _machine = machine; }

        public void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("Etat : Menu principal");
            Console.WriteLine();
        }
        public void Exit()
        {
            Console.WriteLine("Quitte l'état : Menu principal");
            Console.WriteLine();
        }

        public void Input(ConsoleKey key)
        {
            _key = key;
        }
        public void Render()
        {
            Console.WriteLine("Appuyez sur :");
            Console.WriteLine();
            Console.WriteLine("Enter.   Jouer");
            Console.WriteLine("Escape.  Quitter l'application");
            Console.WriteLine();
        }

        public void Render(LocationComponent locationComponent)
        {

        }
        public void Update()
        {
            if (_key == ConsoleKey.Enter)
            {
                _machine.SetState(_machine.GetState(typeof(GoingInGameState)));
            }

            else if (_key == ConsoleKey.Escape)
            {
                _machine.GetGameManager().QuitGame();
            }

            else
            {
                Console.WriteLine("Veuillez choisir une touche correcte");
            }
        }
    }
}
