using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class ComponentTable <T> where T : Component
    {
        private Component[] _componentTable = new Component[2];

        private int _componentCount = 0;
        private void MakeBiggerTable()
        {
            Component[] temp_component = new Component[_componentTable.Length * 2];

            for (int table_index = 0; table_index < _componentCount; table_index++)
            {
                temp_component[table_index] = _componentTable[table_index];
            }

            _componentTable = temp_component;
        }

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
            if ((_componentCount) == _componentTable.Length)
            {
                MakeBiggerTable();
            }

            bool is_type_available = true;

            for (int i  = 0; i < _componentCount; i++)
            {
                if (_componentTable[i].GetType() == typeof(T))
                {
                    Console.WriteLine("Already in");
                    is_type_available = false;
                    return;
                }
            } 
            if (is_type_available)
            {
                _componentTable[_componentCount] = component;

                _componentCount++;
            }

            else
            {
                Console.WriteLine("Component can't be added twice");
            }
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
