using System.Collections.Generic;
using GameScripts.GameEvent;
using GameScripts.StateMachine.StateActions;
using GameScripts.StateMachine.StateTrasions;
using UnityEngine;

namespace GameScripts.StateMachine.States{
    [CreateAssetMenu(fileName = "State", menuName = "StateMachine/State", order = 0)]
    public class SOState : ScriptableObject{
        [SerializeField] private List<SOBaseStateAction> _stateActionsOnExecuteList;
        [SerializeField] private List<SOBaseStateAction> _stateActionsOnStateEnterList;
        [SerializeField] private List<SOBaseStateAction> _stateActionsOnStateExitList;
        [SerializeField] private List<SOStateTransition> _stateTransionsList;
        [SerializeField] private SOGameEvent _onExecuteStateEvent;
        [SerializeField] private SOGameEvent _onEnterStateEvent;
        [SerializeField] private SOGameEvent _onExitStateEvent;

        public void OnStateEnter(StateMachine stateMachine) {
            foreach (var action in _stateActionsOnStateEnterList) {
                action.ExecuteAction(stateMachine);
            }
            
            foreach (var transition in _stateTransionsList) {
                transition.OnTransitionEnter();
            }
            
            _onEnterStateEvent?.InvokeEvent();
        }

        public void OnStateExit(StateMachine stateMachine) {
            foreach (var action in _stateActionsOnStateExitList) {
                action.ExecuteAction(stateMachine);
            }

            foreach (var transition in _stateTransionsList) {
                transition.OnTransitionExit();
            }
            
            _onExitStateEvent?.InvokeEvent();
        }

        public void ExecuteState(StateMachine stateMachine) {
            foreach (var action in _stateActionsOnExecuteList) {
                action.ExecuteAction(stateMachine);
            }
            
            _onExecuteStateEvent?.InvokeEvent();
            
            foreach (var transition in _stateTransionsList) {
                transition.TryToTransition(stateMachine);
            }
            
        }
        
    }
}