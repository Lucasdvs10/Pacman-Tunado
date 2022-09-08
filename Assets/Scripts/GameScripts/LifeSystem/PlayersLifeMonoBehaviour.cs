using System.Collections.Generic;
using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnitTests;
using UnityEngine;

namespace GameScripts.LifeSystem {
    public class PlayersLifeMonoBehaviour : BaseEventEmmiter {
        [SerializeField] private int _initialLifeAmount;
        [SerializeField] private SOSingleInt _lifeAmountSingleton;
        [SerializeField] private List<SOGameEvent> _eventsToApplyDamageOnPlayer;
        [SerializeField] private List<SOGameEvent> _eventsToCurePlayer;
        [SerializeField] private SOGameEvent _onDiedEvent;
        private LifeController _lifeController;

        private void Awake() {
            _lifeController = new LifeController(_initialLifeAmount);
            _lifeAmountSingleton.Value = _lifeController.GetCurrentLife();
        }

        private void OnEnable() {
            foreach (var soGameEvent in _eventsToApplyDamageOnPlayer) {
                soGameEvent.Subscribe(ApplyDamage);
            }
            
            foreach (var soGameEvent in _eventsToCurePlayer) {
                soGameEvent.Subscribe(AddOneLifeOnPlayer);
            }
        }

        
        private void OnDisable() {
            foreach (var soGameEvent in _eventsToApplyDamageOnPlayer) {
                soGameEvent.Unsubscribe(ApplyDamage);
            }
            
            foreach (var soGameEvent in _eventsToCurePlayer) {
                soGameEvent.Unsubscribe(AddOneLifeOnPlayer);
            }
        }
        
        public void ApplyDamage() {
            _lifeController.ApplyDamage(1);
            _lifeAmountSingleton.Value = _lifeController.GetCurrentLife();
            InvokeEvent();

            if (_lifeController.GetCurrentLife() <= 0) {
                _onDiedEvent?.InvokeEvent();
            }
        }

        public void AddOneLifeOnPlayer() {
            _lifeController.ApplyDamage(-1);
            _lifeAmountSingleton.Value = _lifeController.GetCurrentLife();
            InvokeEvent();
        }

    }
}