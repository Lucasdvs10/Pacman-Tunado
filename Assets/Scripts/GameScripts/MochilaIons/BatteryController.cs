using System;
using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.MochilaIons{
    public class BatteryController : BaseEventEmmiter{
        [SerializeField] private SOSingleInt _batteryAmountSingleton;
        [SerializeField] private SOGameEvent _eventToAddOneBattery;

        private void OnEnable() {
            _eventToAddOneBattery.Subscribe(AddOneToBatteryAmount);
        }

        private void OnDisable() {
            _eventToAddOneBattery.Unsubscribe(AddOneToBatteryAmount);
        }

        public void AddBatteryAmount(int amountToSum) {
            _batteryAmountSingleton.Value += amountToSum;
            Mathf.Clamp(_batteryAmountSingleton.Value, 0, Mathf.Infinity);

            InvokeEvent();
        }

        public void AddOneToBatteryAmount() {
            AddBatteryAmount(1);
        }
        
    }
}