using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.Pontuation {
    public class FoodCounter : BaseEventEmmiter {
        [SerializeField] private SOSingleInt _foodRemainAmountSingleton;
        [SerializeField] private SOGameEvent _eventToListen;

        private void Start() {
            GetFoodRemainAmount();
            _foodRemainAmountSingleton.Value = GetFoodRemainAmount();
        }

        private void OnEnable() {
            _eventToListen.Subscribe(DecreaseFoodRemainAmountSingleton);
        }

        private void OnDisable() {
            _eventToListen.Unsubscribe(DecreaseFoodRemainAmountSingleton);
        }

        
        public void DecreaseFoodRemainAmountSingleton() {
            _foodRemainAmountSingleton.Value--;

            if(_foodRemainAmountSingleton.Value <= 0)
                InvokeEvent();
        }
        
        private int GetFoodRemainAmount() {
            return transform.childCount;
        }
    }
}