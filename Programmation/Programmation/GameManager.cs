using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Programmation
{
    internal class GameManager
    {
        private ConsoleKey _lastKey;
        private Thread _thread;
        private StateMachine _stateMachine;

        private bool _shouldEnd;

        private Component _currentLocation;

        private GameObject _world = new GameObject();

        private GameObject _dragonSanctuary = new GameObject();
        private GameObject _dragonSanctuary_A0 = new GameObject();
        private GameObject _dragonSanctuary_A1 = new GameObject();
        private GameObject _dragonSanctuary_A2 = new GameObject();
        private GameObject _dragonSanctuary_A31 = new GameObject();
        private GameObject _dragonSanctuary_A32 = new GameObject();
        private GameObject _dragonSanctuary_A33 = new GameObject();

        private GameObject _observatory = new GameObject();

        private GameObject _roseWind = new GameObject();

        private GameObject _caves = new GameObject();

        private GameObject _player = new GameObject();
        private Component _inventory = new InventoryComponent("Player inventory");

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
                _lastKey = ConsoleKey.None;

                Render();
                ProcessInput();
                Update();

                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        private void Start()
        {
            _world.AddComponent(new LocationComponent("Ile des tempêtes", this));

            _dragonSanctuary.AddComponent(new LocationComponent("Temple du repos du dragon", this));
            _dragonSanctuary_A0.AddComponent(new LocationComponent("Entrée du sanctuaire", this));
            _dragonSanctuary_A1.AddComponent(new LocationComponent("Cloître",this));
            _dragonSanctuary_A2.AddComponent(new LocationComponent("Escaliers", this));
            _dragonSanctuary_A31.AddComponent(new LocationComponent("Cuisine", this));
            _dragonSanctuary_A32.AddComponent(new LocationComponent("Bibliothèque", this));
            _dragonSanctuary_A33.AddComponent(new LocationComponent("Autel du dragon", this));

            _observatory.AddComponent(new LocationComponent("Observatoire de la falaise", this));
            (_observatory.GetComponent(typeof(LocationComponent)) as LocationComponent).SetAccessibility(false);

            _roseWind.AddComponent(new LocationComponent("Epave de la rose des vents", this));
            (_roseWind.GetComponent(typeof(LocationComponent)) as LocationComponent).SetAccessibility(false);

            _caves.AddComponent(new LocationComponent("Grottes de Poussemer", this));
            (_caves.GetComponent(typeof(LocationComponent)) as LocationComponent).SetAccessibility(false);

            _currentLocation = _world.GetComponent(typeof(LocationComponent));

            LocationComponent world_location = _world.GetComponent(typeof(LocationComponent)) as LocationComponent;

            LocationComponent santuary_location = _dragonSanctuary.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A0_location = _dragonSanctuary_A0.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A1_location = _dragonSanctuary_A1.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A2_location = _dragonSanctuary_A2.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A31_location = _dragonSanctuary_A31.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A32_location = _dragonSanctuary_A32.GetComponent(typeof(LocationComponent)) as LocationComponent;
            LocationComponent sanctuary_A33_location = _dragonSanctuary_A33.GetComponent(typeof(LocationComponent)) as LocationComponent;

            LocationComponent observatory_location = _observatory.GetComponent(typeof(LocationComponent)) as LocationComponent;

            LocationComponent roseWind_location = _roseWind.GetComponent(typeof(LocationComponent)) as LocationComponent;

            LocationComponent caves_location = _caves.GetComponent(typeof(LocationComponent)) as LocationComponent;

            world_location.ConnectALocation(santuary_location);
            world_location.ConnectALocation(observatory_location);
            world_location.ConnectALocation(roseWind_location);
            world_location.ConnectALocation(caves_location);

            observatory_location.ConnectALocation(world_location);

            santuary_location.ConnectALocation(world_location);
            santuary_location.ConnectALocation(sanctuary_A0_location);
            sanctuary_A0_location.ConnectALocation(santuary_location);
            sanctuary_A0_location.ConnectALocation(sanctuary_A1_location);
            sanctuary_A1_location.ConnectALocation(sanctuary_A0_location);
            sanctuary_A1_location.ConnectALocation(sanctuary_A2_location);
            sanctuary_A2_location.ConnectALocation(sanctuary_A1_location);
            sanctuary_A2_location.ConnectALocation(sanctuary_A31_location);
            sanctuary_A2_location.ConnectALocation(sanctuary_A32_location);
            sanctuary_A2_location.ConnectALocation(sanctuary_A33_location);
            sanctuary_A31_location.ConnectALocation(sanctuary_A2_location);
            sanctuary_A32_location.ConnectALocation(sanctuary_A2_location);
            sanctuary_A33_location.ConnectALocation(sanctuary_A2_location);

            _player.AddComponent(_inventory);
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
                
                if (key != ConsoleKey.None)
                {
                    _lastKey = key;
                }

                Thread.Sleep(10);
            }
        }

        private void ProcessInput()
        {
            _stateMachine.ProcessInput(_lastKey);
        }

        public StateMachine GetStateMachine()
        {
            return _stateMachine;
        }

        public Component GetCurrentLocation()
        {
            return _currentLocation;
        }

        public Component GetInventory()
        {
            return _inventory;
        }
    }
}
