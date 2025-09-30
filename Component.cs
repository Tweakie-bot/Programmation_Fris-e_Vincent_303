using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal abstract class Component
    {

        private string _name;
        protected Component(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        public virtual void Update()
        {

        }
    }
}
