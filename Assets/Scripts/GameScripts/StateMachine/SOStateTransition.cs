using GameScripts.GameEvent;
using GameScripts.StateMachine.StateDeciders;
using GameScripts.StateMachine.States;
using UnityEngine;

namespace GameScripts.StateMachine.StateTrasions{
    [CreateAssetMenu(fileName = "Transition", menuName = "StateMachine/Transition")]
    public class SOStateTransition : ScriptableObject{
        [SerializeField] private SOBaseStateDecider _decider;
        [SerializeField] private SOState _stateWhenTrue;
        [SerializeField] private SOState _stateWhenFalse;

        public void TryToTransition(StateMachine stateMachine) {
            if (_decider.Decide(stateMachine) && _stateWhenTrue != null) {
                stateMachine.ChangeState(_stateWhenTrue);
            }
            else if (!_decider.Decide(stateMachine) &&_stateWhenFalse != null) {
                stateMachine.ChangeState(_stateWhenFalse);
            }
        }

        public void OnTransitionEnter() {
            _decider.OnDecideEnter();
        }

        public void OnTransitionExit() {
            _decider.OnDecideExit();
        }

    }
}