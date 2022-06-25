using GameScripts.StateMachine.States;
using UnityEngine;

namespace GameScripts.StateMachine{
    public class StateMachine : MonoBehaviour{
        [SerializeField] private SOBaseState _initialState;
        private SOBaseState _currentState;

        private void Awake() {
            _currentState = _initialState;
        }

        public void ChangeState(SOBaseState nextState) {
            _currentState.OnStateExit(this);
            _currentState = nextState;
            _currentState.OnStateEnter(this);
        }

        private void Update() {
            _currentState.ExecuteState(this);
        }
    }
}