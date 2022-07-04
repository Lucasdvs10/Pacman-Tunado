using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.Pontuation{
    public class PointsAdder : BaseEventEmmiter{
        [SerializeField] private SOSingleInt _pointsSingleton;
        [SerializeField] private int _pointsAmountValue;
        [SerializeField] private SOGameEvent _event;
        
        private void Start() {
            _pointsSingleton.Value = 0;
        }

        private void OnEnable() {
            _event.Subscribe(AddAmount);
        }

        private void OnDisable() {
            _event.Unsubscribe(AddAmount);
        }

        public void AddAmount() {
            _pointsSingleton.Value += _pointsAmountValue;
            InvokeEvent();
        }
        
    }
}