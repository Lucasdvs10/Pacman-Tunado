using System;
using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders{
    [CreateAssetMenu(fileName = "DeciderEventListener", menuName = "StateMachine/Deciders/EventListener")]
    public class SODeciderEventListener : SOBaseStateDecider{
        public SOGameEvent _eventToListen;
        private bool flag;

        public override void OnDecideEnter() {
            _eventToListen.Subscribe(TurnOnFlag);
        }

        public override void OnDecideExit() {
            _eventToListen.Unsubscribe(TurnOnFlag);
            flag = false;
        }
        
        public override bool Decide(StateMachine stateMachine) {
            return flag;
        }

        private void OnEnable() {
            flag = false;
        }

        private void OnDisable() {
            flag = false;
        }

        private void TurnOnFlag() => flag = true;
    }
}