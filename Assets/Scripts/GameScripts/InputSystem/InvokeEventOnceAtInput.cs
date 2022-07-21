using GameScripts.GameEvent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameScripts.InputSystem{
    public class InvokeEventOnceAtInput : MonoBehaviour{
        [SerializeField] private SOGameEvent _eventWhenPerformButton;
        [SerializeField] private SOGameEvent _eventWhenCancelButton;

        public void InvokeEvents(InputAction.CallbackContext ctx) {
            if(ctx.performed)
                _eventWhenPerformButton?.InvokeEvent();
            
            if(ctx.canceled)
                _eventWhenCancelButton?.InvokeEvent();
        }
        
    }
}