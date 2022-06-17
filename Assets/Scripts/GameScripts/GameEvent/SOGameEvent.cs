using System;
using UnityEngine;

namespace GameScripts.GameEvent{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent")]
    public class SOGameEvent : ScriptableObject{
        private event Action OnEventRaised;

        public void InvokeEvent() {
            OnEventRaised?.Invoke();
        }
        
        public void Subscribe(Action action) {
            OnEventRaised += action;
        }

        public void Unsubscribe(Action action) {
            OnEventRaised -= action;
        }
    }
}