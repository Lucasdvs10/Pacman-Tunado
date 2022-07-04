using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.Collisions{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GhostCollidePlayerEventEmmiter : BaseEventEmmiter{
        [SerializeField] private SOGameEvent[] _stateEventEnterToListen;
        [SerializeField] private SOGameEvent[] _stateEventExitToListen;
        private bool _flag;

        private void OnEnable() {
            foreach (var state in _stateEventEnterToListen) {
                state.Subscribe(TurnOnFlag);
            }
            
            foreach (var state in _stateEventExitToListen) {
                state.Subscribe(TurnOffFlag);
            }
        }

        private void OnDisable() {
            foreach (var state in _stateEventEnterToListen) {
                state.Unsubscribe(TurnOnFlag);
            }
            
            foreach (var state in _stateEventExitToListen) {
                state.Unsubscribe(TurnOffFlag);
            }
        }

        private void TurnOnFlag() => _flag = true;
        private void TurnOffFlag() => _flag = false;

        private void OnTriggerEnter2D(Collider2D col) {
            if(col.tag == "Player" && _flag)
                InvokeEvent();
        }
    }
}