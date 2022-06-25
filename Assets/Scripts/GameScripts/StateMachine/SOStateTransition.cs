using GameScripts.StateMachine.StateDeciders;
using GameScripts.StateMachine.States;
using UnityEngine;

namespace GameScripts.StateMachine.StateTrasions{
    [CreateAssetMenu(fileName = "Transition", menuName = "StateMachine/Transition", order = 0)]
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

    }
}