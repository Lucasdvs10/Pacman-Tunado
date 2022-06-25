using System.Collections.Generic;
using GameScripts.GameEvent;
using GameScripts.StateMachine.StateActions;
using GameScripts.StateMachine.StateTrasions;
using UnityEngine;

namespace GameScripts.StateMachine.States{
    [CreateAssetMenu(fileName = "State", menuName = "StateMachine/State", order = 0)]
    public class SOState : ScriptableObject{
        [SerializeField] private List<SOBaseStateAction> _stateActionsList;
        [SerializeField] private List<SOStateTransition> _stateTransionsList;
        [SerializeField] private SOGameEvent _onExecuteStateEvent;
        [SerializeField] private SOGameEvent _onEnterStateEvent;
        [SerializeField] private SOGameEvent _onExitStateEvent;

        public void OnStateEnter(StateMachine stateMachine) {
            _onEnterStateEvent?.InvokeEvent();
        }

        public void OnStateExit(StateMachine stateMachine) {
            _onExitStateEvent?.InvokeEvent();
        }

        public void ExecuteState(StateMachine stateMachine) {
            foreach (var action in _stateActionsList) {
                action.ExecuteAction(stateMachine);
            }
            
            _onExecuteStateEvent?.InvokeEvent();
            
            foreach (var transition in _stateTransionsList) {
                transition.TryToTransition(stateMachine);
            }
            
        }
        
    }
}