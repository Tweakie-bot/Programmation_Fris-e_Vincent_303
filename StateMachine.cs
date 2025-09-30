using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Progra_1
{
    internal class StateMachine
    {
        private GameManager _gameManager;

        private IState _currentState;

        private IState _mainMenuState;

        private IState _goingInGameState;

        private IState _choosingLocation;

        public StateMachine(GameManager game_manager)
        {
            _gameManager = game_manager;

            _mainMenuState = new MainMenuState(this);
            _currentState = _mainMenuState;

            _goingInGameState = new GoingInGameState(this);
            _choosingLocation = new ChoosingLocationState(this);
        }
        public void Render(LocationComponent location)
        {
            if (_currentState is ChoosingLocationState)
            {
                _choosingLocation.Render(location);
            }

            else
            {
                _currentState.Render();
            }
        }
        public void Update()
        {
            _currentState.Update();
        }
        public void ProcessInput(ConsoleKey key)
        {
            _currentState.Input(key);
        }

        public void SetState(IState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        public IState? GetState(Type type)
        {
            if (type == typeof(MainMenuState))
            {
                return _mainMenuState;
            }

            else if (type == typeof(GoingInGameState))
            {
                return _goingInGameState;
            }

            else if (type == typeof(ChoosingLocationState))
            {
                return _choosingLocation;
            }

            throw new Exception("Tried to return a state that doesn't exist");
        }

        public IState GetCurrentState()
        {
            return _currentState;
        }
        public GameManager GetGameManager() { return _gameManager; }
    }
}
