using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders{
    public abstract class SOBaseStateDecider : ScriptableObject{
        public abstract bool Decide(StateMachine stateMachine);
        public virtual void OnDecideEnter(){}
        public virtual void OnDecideExit(){}
    }
}