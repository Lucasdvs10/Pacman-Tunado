using System;
using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.MochilaIons{
    [RequireComponent(typeof(RaycastEmmiter))]
    public class MochilaRaycastHandler : MonoBehaviour{
        [SerializeField] private SOGameEvent _event;
        private RaycastEmmiter _raycastEmmiter;

        private void Awake() {
            _raycastEmmiter = GetComponent<RaycastEmmiter>();
        }

        private void OnEnable() {
            _event.Subscribe(EmitRaycastAndActivateResponse);
        }

        private void OnDisable() {
            _event.Unsubscribe(EmitRaycastAndActivateResponse);
        }


        [ContextMenu("Emitir raycast com resposta")]
        private void EmitRaycastAndActivateResponse() {
            var hit = _raycastEmmiter.EmitRayCast();
            var otherTransform = hit.transform;

            if (otherTransform == null) return;
            
            var otherMochilaDetectable = otherTransform.GetComponent<IMochilaRaycastDetectable>();
            
            otherMochilaDetectable?.RespondToRaycastDetection();
        }
        
    }
}