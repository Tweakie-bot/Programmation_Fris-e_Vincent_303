using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class GoingInGameState : IState
    {

        StateMachine _machine;
        public GoingInGameState(StateMachine machine) { _machine = machine; }

        public void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("Etat : Chargement du jeu");
            Console.WriteLine();
        }
        public void Exit()
        {
            
            Console.WriteLine("Fin du chargement");
        }

        public void Input(ConsoleKey key)
        {
            
        }
        public void Render()
        {
            Console.WriteLine("Chargement...");
        }

        public void Render(LocationComponent location)
        {

        }
        public void Update()
        {
            _machine.SetState(_machine.GetState(typeof(ChoosingLocationState)));
        }
    }
}
