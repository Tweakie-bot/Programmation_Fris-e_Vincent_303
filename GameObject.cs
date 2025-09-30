using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class GameObject
    {
        private ComponentTable<Component> _componentTable = new ComponentTable<Component>();
        
        public void AddComponent(Component component)
        {
            _componentTable.Add(component);
        }

        public Component GetComponent(Type component)
        {
            if (_componentTable.ContainsComponent(component))
            {
                return _componentTable.GetComponent(component);
            } 
            else
            {
                throw new Exception("Not found");
            }
        }

        public void Contains(Component component)
        {
            _componentTable.ContainsComponent(component.GetType());
        }

        public void Update()
        {
            _componentTable.Update();
        }
    }
}
