using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmation
{
    internal class WorkingState : IState
    {
        private StateMachine _machine;

        private ConsoleKey _key;
        private int _workingCapacity;

        public WorkingState(StateMachine machine)
        {
            _machine = machine;
        }

        public void Enter()
        {
            Console.WriteLine("You start the work");

            _workingCapacity += 20;
        }
        public void Exit()
        {
            Console.WriteLine("You finished the work");
        }
        public void Input(ConsoleKey key)
        {
            _key = key;
        }
        public void Update()
        {
            (_machine.GetGameManager().GetInventory() as InventoryComponent).Add("Gold", _workingCapacity);
        }

        public void Render()
        {
            Console.WriteLine("Working...");
            Thread.Sleep(1000);
        }

        public void Render(LocationComponent location)
        {

        }
    }
}
