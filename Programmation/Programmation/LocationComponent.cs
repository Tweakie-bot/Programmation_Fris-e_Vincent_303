using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmation
{
    internal class LocationComponent : Component
    {
        private GameManager _gameManager;
        private ComponentTable<LocationComponent> _connectedLocations = new ComponentTable<LocationComponent>();

        private bool _isAccessible = true;
        public LocationComponent(string name, GameManager manager) : base(name) 
        { 
            _gameManager = manager;
        }

        public void ConnectALocation(LocationComponent location)
        {
            _connectedLocations.Add(location);
        }

        public void Display()
        {
            Console.WriteLine(GetName());
            _connectedLocations.Display();

            if (!_isAccessible)
            {
                
                Console.WriteLine("Votre destinée est ailleurs, vous serez amenés à visiter cet endroit plus tard");
            }
        }
        public void Update(ConsoleKey key)
        {
            if (_isAccessible)
            {
                if (key == ConsoleKey.Escape)
                {
                    _gameManager.GetStateMachine().SetState(_gameManager.GetStateMachine().GetState(typeof(MainMenuState)));
                    return;
                }

                int input = -1;

                switch (key)
                {
                    case ConsoleKey.NumPad0:
                        input = 0;
                        break;

                    case ConsoleKey.NumPad1:
                        input = 1;
                        break;

                    case ConsoleKey.NumPad2:
                        input = 2;
                        break;

                    case ConsoleKey.NumPad3:
                        input = 3;
                        break;

                    case ConsoleKey.NumPad4:
                        input = 4;
                        break;

                    case ConsoleKey.NumPad5:
                        input = 5;
                        break;

                    case ConsoleKey.NumPad6:
                        input = 6;
                        break;

                    case ConsoleKey.NumPad7:
                        input = 7;
                        break;

                    case ConsoleKey.NumPad8:
                        input = 8;
                        break;

                    case ConsoleKey.NumPad9:
                        input = 9;
                        break;

                    default:
                        if (key != ConsoleKey.None)
                        {
                            Console.WriteLine("Not a correct entry");
                        }
                        break;
                }

                if (input > 0 && input < (_connectedLocations.GetCount()))
                {
                    Component[] table = _connectedLocations.GetTable();

                    _gameManager.SetCurrentLocation(table[input - 1].GetName());
                }

                else
                {
                    if (key != ConsoleKey.None)
                    {
                        Console.WriteLine("Enter a correct key to continue");
                    }
                }
            }
        }
        public void SetAccessibility(bool boolean)
        {
            _isAccessible = boolean;
        }
    }
}
