using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.MochilaIons{
    public class ObjRotationAcordingToInput : MonoBehaviour{
        [SerializeField] private SOSingleVector2 _directionSingleton;
        [SerializeField] private SOSingleVector2 _playerInputDirection;
        [SerializeField] private SOGameEvent _event;


        private void OnEnable() {
            _event.Subscribe(UpdateMochilaDirection);
        }

        private void OnDisable() {
            _event.Unsubscribe(UpdateMochilaDirection);
            _directionSingleton.Value = Vector2.zero;
        }

        private void UpdateMochilaDirection() {
            if (_playerInputDirection.Value != Vector2.zero)
                _directionSingleton.Value = _playerInputDirection.Value;
        }
    }
}