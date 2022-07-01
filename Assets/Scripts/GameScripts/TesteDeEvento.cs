using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts{
    public class TesteDeEvento : MonoBehaviour{
        [SerializeField] private SOGameEvent _event;

        private void OnEnable() {
            _event.Subscribe(Kappa);
        }

        private void OnDisable() {
            _event.Unsubscribe(Kappa);
        }

        private void Kappa() {
            Debug.Log("Evento foi chamado!");
        }
    }
}