using System;
using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.Pontuation {
    public class FoodManager : MonoBehaviour {
        [SerializeField] private SOSingleInt _foodRemainAmountSingleton;
        [SerializeField] private SOGameEvent _eventToListen;
        private int _foodRemainAmount;

        private void Start() {
            UpdateFoodRemainAmountSingleton();
        }

        private void OnEnable() {
            _eventToListen.Subscribe(UpdateFoodRemainAmountSingleton);
        }

        private void OnDisable() {
            _eventToListen.Unsubscribe(UpdateFoodRemainAmountSingleton);
        }


        public void UpdateFoodRemainAmountSingleton() {
            GetFoodRemainAmount();
            _foodRemainAmountSingleton.Value = _foodRemainAmount;
        }
        
        private void GetFoodRemainAmount() {
            _foodRemainAmount = transform.childCount;
        }
    }
}