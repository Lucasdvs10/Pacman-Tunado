using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.StateMachine.States{
    public abstract class BaseState : ScriptableObject{
        public abstract void OnStateEnter(StateMachine stateMachine);
        public abstract void OnStateExit(StateMachine stateMachine);
        public abstract void ExecuteState(StateMachine stateMachine);
        protected SOGameEvent _eventToRaise;
        
        
    }
}