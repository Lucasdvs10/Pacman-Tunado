using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    
    [RequireComponent(typeof(PathFindingMoverBehaviour))]
    public class RedTargetDefiner : MonoBehaviour{
        [SerializeField] private SOSingleVector2Int _targetPosition;
        private PathFindingMoverBehaviour _ghostMover;

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
            _ghostMover.SetTarget(_targetPosition.Value);
        }

        [ContextMenu("Mover fantasma")]
        public void StartGhostMoving() {
            _ghostMover.StartMoveToTargetCoroutine();
        }
    }
}