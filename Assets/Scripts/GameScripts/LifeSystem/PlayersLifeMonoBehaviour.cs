using System.Collections.Generic;
using GameScripts.GameEvent;
using UnitTests;
using UnityEngine;

namespace GameScripts.LifeSystem {
    public class PlayersLifeMonoBehaviour : MonoBehaviour {
        [SerializeField] private int _initialLifeAmount;
        private LifeController _lifeController;
        private List<SOGameEvent> _eventsToApplyDamageOnPlayer;
        private List<SOGameEvent> _eventsToCurePlayer;

        private void Awake() {
            _lifeController = new LifeController(_initialLifeAmount);
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
        
        public void ApplyDamage() => _lifeController.ApplyDamage(1);

        public void AddOneLifeOnPlayer() => _lifeController.ApplyDamage(-1);

    }
}