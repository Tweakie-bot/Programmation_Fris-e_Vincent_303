using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmation
{
    internal class ComponentTable <T> where T : Component
    {
        private Component[] _componentTable = new Component[10];

        private int _componentCount = 0;
        public void Display()
        {
            for(int i = 0; i < _componentCount; i++)
            {
                Console.WriteLine((i + 1) + ".  " + _componentTable[i].GetName());
            }
        }

        public void Update()
        {
            for (int table_index = 0; table_index< _componentCount; table_index++)
            {
                _componentTable[table_index].Update();
            }
        }

        public void Add(T component)
        {
            bool is_type_available = true;

            for (int i  = 0; i < _componentCount; i++)
            {
                if (_componentTable[i].GetType() == typeof(T))
                {
                    Console.WriteLine("You added two components of the same type, check if they are locations : " + _componentTable[i].GetType().ToString());
                }
            } 
                _componentTable[_componentCount] = component;

                _componentCount++;
        }

        public Component GetComponent(Type type)
        {
            for (int table_index = 0; table_index < _componentCount; table_index++)
            {
                Type temp_type = _componentTable[table_index].GetType();

                if (temp_type == type)
                {
                    return _componentTable[table_index];
                }
            }
            throw new Exception("This component isn't present");
        }

        public Component[] GetTable()
        {
            return _componentTable;
        }
        public bool ContainsComponent(Type class_type)
        {

            for (int table_index = 0; table_index < _componentCount; table_index++)
            {
                Type type = _componentTable[table_index].GetType();
                if (type == class_type)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetCount()
        {
            return _componentCount;
        }
    }
}
