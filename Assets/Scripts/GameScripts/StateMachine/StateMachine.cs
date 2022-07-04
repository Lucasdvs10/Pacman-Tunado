using GameScripts.StateMachine.States;
using UnityEngine;

namespace GameScripts.StateMachine{
    public class StateMachine : MonoBehaviour{
        [SerializeField] private SOState _initialState;
        private SOState _currentState;

        private void Awake() {
            _currentState = _initialState;
        }

        private void Start() {
            _currentState.OnStateEnter(this);
        }

        public void ChangeState(SOState nextState) {
            _currentState.OnStateExit(this);
            _currentState = nextState;
            _currentState.OnStateEnter(this);
        }

        private void Update() {
            _currentState.ExecuteState(this);
        }
    }
}