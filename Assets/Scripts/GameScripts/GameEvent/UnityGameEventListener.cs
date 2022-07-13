using UnityEngine;
using UnityEngine.Events;

namespace GameScripts.GameEvent{
    public class UnityGameEventListener : MonoBehaviour{
        [SerializeField] private SOGameEvent _eventToListen;
        public UnityEvent UnityEvent;

        private void OnEnable() {
            _eventToListen.Subscribe(InvokeEvent);
        }

        private void OnDisable() {
            _eventToListen.Subscribe(InvokeEvent);
        }

        private void InvokeEvent() {
            UnityEvent?.Invoke();
        }
    }
}