using System.Collections;
using System.Collections.Generic;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class PathFindingMoverBehaviour : MonoBehaviour{
       [SerializeField] private GridBehaviour _gridBehaviour;
       [SerializeField] private float _cooldownMover = 0.3f;

       public SOSingleVector2Int GhostPositionSingleton;
       
       private GridAgent _gridAgent;
       private BaseMatrixGrid _grid;
       private IPathCalculator _pathCalculator;
       private Queue<Vector2Int> _pathInGridQueue;
       private Vector2Int _gridPosition;
       private Vector2Int _targetPosition;

       private Transform _fakeGhostTransform;

       private Coroutine k;

       private void Awake() {
           _fakeGhostTransform = transform.GetChild(0).transform;
           _fakeGhostTransform.parent = null;
       }

       private void Start() {
            _grid = _gridBehaviour.Grid;
            _pathCalculator = new AStarCalculator(_grid);
            _gridAgent = new GridAgent(_grid, _grid.WorldPosToGridPos(transform.position));
            GridPosition = _gridAgent.PositionInGrid;
            StartMoveToTargetCoroutine();
       }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
        }

        [ContextMenu("Mova ate o target")]
        public void StartMoveToTargetCoroutine() {
            k = StartCoroutine(MoveToTargetCoroutine());
        }
        public void StopMoveToTargetCoroutine() {
            StopCoroutine(k);
        }

        public void SetTarget(Vector2Int position) {
            if(_grid.IsCellAvaible(position)) {
                _targetPosition = position;
                CalculatePath(_targetPosition);
            }
        }

        public void Move(Vector2Int direction) {
            _gridAgent.Move(direction);
            GridPosition = _gridAgent.PositionInGrid;
        }

        private IEnumerator MoveToTargetCoroutine() {
            while (true) {
                if (_gridPosition != _targetPosition) {
                    MoveToNextInQueue();
                    yield return new WaitForSeconds(_cooldownMover);
                }
                else
                    yield return null;
            }
        }
        
        private void CalculatePath(Vector2Int targetPosition) {
            _pathInGridQueue = _pathCalculator.SetTarget(GridPosition, targetPosition);
        }
        
        
        private void MoveToNextInQueue() {
            if (_pathInGridQueue == null) return;
            
            _pathInGridQueue.TryDequeue(out var nextPosition);
            _gridAgent.SetAgentPositionAtGrid(nextPosition);
            GridPosition = _gridAgent.PositionInGrid;
        }

        public GridAgent GridAgent => _gridAgent;

        public Vector2Int GridPosition {
            get => _gridPosition;
            set {
            _gridPosition = value;
            GhostPositionSingleton.Value = value;
            }
        }
    }
}