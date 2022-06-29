using GameScripts.GameEvent;
using GameScripts.GhostsPathFinding.SOTargetDefiners;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    
    [RequireComponent(typeof(PathFindingMoverBehaviour))]
    public class TargetDefinerController : MonoBehaviour{
        private SOBaseTargetDefiner targetDefiner;
        private PathFindingMoverBehaviour _ghostMover;
        private Vector2Int _targetPosition;

        public SOGameEvent Event;
        
        private void Awake() {
            _ghostMover = GetComponent<PathFindingMoverBehaviour>();
        }

        private void OnEnable() {
            Event.Subscribe(SetTarget);
        }

        private void OnDisable() {
            Event.Unsubscribe(SetTarget);
        }

        [ContextMenu("Setar o target")]
        public void SetTarget() {
            if (targetDefiner == null) return;
            
            _targetPosition = targetDefiner.DefineTargetPosition();
            _ghostMover.SetTarget(_targetPosition);
        }

        public void SetTargetDefiner(SOBaseTargetDefiner nextTargetDefiner) => targetDefiner = nextTargetDefiner;


    }
}