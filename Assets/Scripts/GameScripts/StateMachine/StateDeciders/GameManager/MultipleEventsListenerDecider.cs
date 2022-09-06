using System;
using System.Collections.Generic;
using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders.GameManager {
    [CreateAssetMenu(fileName = "MultipleEventDecider", menuName = "StateMachine/Deciders/Multiple Event Listener")]
    public class MultipleEventsListenerDecider : SOBaseStateDecider {
        [SerializeField] private List<SOGameEvent> _eventsToListen;
        private List<bool> _boolsList;

        private void OnEnable() {
            _boolsList = new List<bool>();
            foreach (var gameEvent in _eventsToListen) {
                _boolsList.Add(false);
            }

            for (int i = 0; i < _boolsList.Count; i++) {
                _eventsToListen[i].Subscribe(() => SetIndexTrue(i));
            }            
        }

        private void OnDisable() {
            for (int i = 0; i < _eventsToListen.Count; i++) {
                _eventsToListen[i].Unsubscribe(() => SetIndexTrue(i));
            }
        }


        public override bool Decide(StateMachine stateMachine) {
            foreach (var item in _boolsList) {
                if (!item) return false;
            }
            return true;
        }
        
        private void SetIndexTrue(int itemIndex) => _boolsList[itemIndex] = true;

    }
}