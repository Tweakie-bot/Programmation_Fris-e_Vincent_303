using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal interface IState
    {
        public void Enter();
        public void Exit();

        public void Input(ConsoleKey key);
        public void Update();
        public void Render();
        public void Render(LocationComponent location);
    }
}
