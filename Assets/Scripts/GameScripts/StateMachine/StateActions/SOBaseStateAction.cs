using UnityEngine;

namespace GameScripts.StateMachine.StateActions{
    public abstract class SOBaseStateAction : ScriptableObject{
        public abstract void ExecuteAction(StateMachine stateMachine);
    }
}