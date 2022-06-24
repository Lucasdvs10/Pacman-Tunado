using GameScripts.GameEvent;
using GameScripts.GhostsPathFinding.SOTargetDefiners;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    
    [RequireComponent(typeof(PathFindingMoverBehaviour))]
    public class TargetDefinerController : MonoBehaviour{
        [SerializeField] private SOBaseTargertDefiner _targertDefiner;
        private PathFindingMoverBehaviour _ghostMover;
        private Vector2Int _targetPosition;

        public SOGameEvent Event;
        
        private void Awake() {
            _ghostMover = GetComponent<PathFindingMoverBehaviour>();
        }

        private void OnEnable() {
            Event.Subscribe(SetTargetAndMove);
        }

        private void OnDisable() {
            Event.Unsubscribe(SetTargetAndMove);
        }

        [ContextMenu("Setar e mover")]
        public void SetTargetAndMove() {
            SetTarget();
            StartGhostMoving();
            print("Settei e movi");
        }
        
        [ContextMenu("Setar o target")]
        public void SetTarget() {
            _targetPosition = _targertDefiner.DefineTargetPosition();
            _ghostMover.SetTarget(_targetPosition);
        }

        [ContextMenu("Mover fantasma")]
        public void StartGhostMoving() {
            _ghostMover.StartMoveToTargetCoroutine();
        }
    }
}