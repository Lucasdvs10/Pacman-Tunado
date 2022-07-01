using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.MochilaIons{
    public class RaycastEmmiter : MonoBehaviour{
        [SerializeField] private SOSingleVector2 _directionToRaycast;
        [SerializeField] private float _raycastDistance;
        [SerializeField] private float _raycastOffset = 1.3f;

        [ContextMenu("Emitir raycast")]
        private RaycastHit2D EmitRayCast() {
            var raycastHit = Physics2D.Raycast(transform.position + (new Vector3(_directionToRaycast.Value.x, _directionToRaycast.Value.y, 0) *_raycastOffset), _directionToRaycast.Value, _raycastDistance);

            return raycastHit;
        }
    }
}