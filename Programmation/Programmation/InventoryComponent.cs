using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmation
{
    internal class InventoryComponent : Component
    {
        private Dictionary<string, int> _objects = new Dictionary<string, int>();
        public InventoryComponent(string name) : base(name) { }

        public void Add(string name, int count)
        {
            if (_objects.ContainsKey(name))
            {
                _objects[name] += count;
            }
            
            else
            {
                _objects.Add(name, count);
            }
        }
    }
}
