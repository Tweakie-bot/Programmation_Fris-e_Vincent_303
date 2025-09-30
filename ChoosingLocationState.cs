using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class ChoosingLocationState : IState
    {

        StateMachine _machine;
        ConsoleKey _key;
        public ChoosingLocationState(StateMachine machine) 
        { 
            _machine = machine; 
        }

        public void Enter()
        {
            Console.WriteLine("Etat : En train de parcourir le monde");
        }
        public void Exit()
        {
            Console.WriteLine("Fin de l'état d'exploration");
        }

        public void Input(ConsoleKey key)
        {
            _key = key;
        }
        public void Render()
        {

        }

        public void Render(LocationComponent location)
        {
            location.Display();
        }
        public void Update()
        {
            (_machine.GetGameManager().GetCurrentLocation() as LocationComponent).Update(_key);
        }
    }
}
