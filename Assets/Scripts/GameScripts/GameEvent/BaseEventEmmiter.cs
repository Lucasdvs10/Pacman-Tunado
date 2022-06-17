using UnityEngine;

namespace GameScripts.GameEvent{
    public abstract class BaseEventEmmiter : MonoBehaviour{
        public SOGameEvent _gameEventToRaise;

        public virtual void InvokeEvent() {
            if (_gameEventToRaise is null) {
                Debug.Log("Voce não colocou nenhum evento aqui", this);
            }
            
            _gameEventToRaise.InvokeEvent();
        }
    }
}