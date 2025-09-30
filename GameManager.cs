using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class GameManager
    {
        private Queue<ConsoleKey> _consoleKeys = new Queue<ConsoleKey>();
        private Thread _thread;
        private StateMachine _stateMachine;

        private bool _shouldEnd;

        private Component _currentLocation;

        private GameObject _world = new GameObject();
        private GameObject _dragonSanctuary = new GameObject();
        private GameObject _observatory = new GameObject();

        public GameManager() 
        {
            _stateMachine = new StateMachine(this);
        }

        public void SetCurrentLocation(string location_name)
        {
            if (_world.GetComponent(typeof(LocationComponent)).GetName() == location_name)
            {
                _currentLocation = _world.GetComponent(typeof(LocationComponent));
            }

            else if (_dragonSanctuary.GetComponent(typeof(LocationComponent)).GetName() == location_name)
            {
                _currentLocation = _dragonSanctuary.GetComponent(typeof(LocationComponent));
            }

            else if (_observatory.GetComponent(typeof(LocationComponent)).GetName() == location_name)
            {
                _currentLocation = _observatory.GetComponent(typeof(LocationComponent));
            }
        }

        public void Run()
        {
            Start();

            _thread = new Thread(ReadKey);
            _thread.Start();

            while (!_shouldEnd)
            {
                Render();
                ProcessInput();
                Update();

                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        private void Start()
        {
            _world.AddComponent(new LocationComponent("Monde ouvert", this));
            _dragonSanctuary.AddComponent(new LocationComponent("Sanctuaire du repos du dragon", this));
            _observatory.AddComponent(new LocationComponent("Observatoire", this));

            _currentLocation = _world.GetComponent(typeof(LocationComponent));

            LocationComponent world_location = _world.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent santuary_location = _dragonSanctuary.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent observatory_location = _observatory.GetComponent(typeof(LocationComponent)) as LocationComponent;

            world_location.ConnectALocation(santuary_location);
            world_location.ConnectALocation(observatory_location);

            observatory_location.ConnectALocation(world_location);

            santuary_location.ConnectALocation(world_location);
        }
        private void Update()
        {
            _stateMachine.Update();
        }
        private void Render()
        {
            _stateMachine.Render(_currentLocation as LocationComponent);
            Thread.Sleep(1000);
        }

        public void QuitGame()
        {
            _shouldEnd = true;
            _thread.Join();
        }
        private void ReadKey()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                _consoleKeys.Enqueue(key);

                Thread.Sleep(10);
            }
        }

        private void ProcessInput()
        {
            if (_consoleKeys.Count != 0)
            {
                ConsoleKey key = _consoleKeys.Dequeue();

                _stateMachine.ProcessInput(key);
            }
        }

        public StateMachine GetStateMachine()
        {
            return _stateMachine;
        }

        public Component GetCurrentLocation()
        {
            return _currentLocation;
        }
    }
}
