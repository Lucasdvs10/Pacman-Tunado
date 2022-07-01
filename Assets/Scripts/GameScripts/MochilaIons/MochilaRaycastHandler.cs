using System;
using UnityEngine;

namespace GameScripts.MochilaIons{
    [RequireComponent(typeof(RaycastEmmiter))]
    public class MochilaRaycastHandler : MonoBehaviour{
        private RaycastEmmiter _raycastEmmiter;

        private void Awake() {
            _raycastEmmiter = GetComponent<RaycastEmmiter>();
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