using System.Collections.Generic;
using GameScripts.GameEvent;
using GameScripts.StateMachine.StateActions;
using GameScripts.StateMachine.StateTrasions;
using UnityEngine;

namespace GameScripts.StateMachine.States{
    public abstract class SOBaseState : ScriptableObject{
        [SerializeField] protected List<SOBaseStateAction> _stateActionsList;
        [SerializeField] protected List<SOStateTransition> _stateTransionsList;
        [SerializeField] protected SOGameEvent _onEnterStateEvent;
        [SerializeField] protected SOGameEvent _onExitStateEvent;

        public abstract void OnStateEnter(StateMachine stateMachine);
        public abstract void OnStateExit(StateMachine stateMachine);
        public abstract void ExecuteState(StateMachine stateMachine);
        
    }
}