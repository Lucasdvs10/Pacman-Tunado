using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.MochilaIons{
    public class SavingLastPlayerDirectionInput : MonoBehaviour{
        [SerializeField] private SOSingleVector2 _directionSingleton;
        [SerializeField] private SOSingleVector2 _playerInputDirection;
        [SerializeField] private SOGameEvent _event;


        private void OnEnable() {
            _event.Subscribe(UpdateDirectionSingleton);
        }

        private void OnDisable() {
            _event.Unsubscribe(UpdateDirectionSingleton);
            _directionSingleton.Value = Vector2.zero;
        }

        private void UpdateDirectionSingleton() {
            if (_playerInputDirection.Value != Vector2.zero)
                _directionSingleton.Value = _playerInputDirection.Value;
        }
    }
}