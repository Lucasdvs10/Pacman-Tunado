using System;
using System.Collections;
using System.Collections.Generic;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class PathFindingMoverBehaviour : MonoBehaviour{
       [SerializeField] private GridBehaviour _gridBehaviour;
       //todo: aqui ele vai receber um targetDefiner

       private GridAgent _gridAgent;
       private BaseMatrixGrid _grid;
       private IPathCalculator _pathCalculator;
       private Queue<Vector2Int> _pathInGridQueue;
       private Vector2Int _gridPosition;
       private Vector2Int _targetPosition;

       private Transform _fakeGhostTransform;

       private void Awake() {
           _fakeGhostTransform = transform.GetChild(0).transform;
           _fakeGhostTransform.parent = null;
       }

       private void Start() {
            _grid = _gridBehaviour.Grid;
            _pathCalculator = new AStarCalculator(_grid);
            _gridAgent = new GridAgent(_grid, _grid.WorldPosToGridPos(transform.position));
            _gridPosition = _gridAgent.PositionInGrid;
       }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
        }

        [ContextMenu("Mova ate o target")]
        public void StartMoveToTargetCoroutine() {
            StartCoroutine(MoveToTargetCoroutine(new Vector2Int(30,30)));
        }
        
        private IEnumerator MoveToTargetCoroutine(Vector2Int endPosition) {
            CalculatePath(endPosition);
            while (_gridPosition != endPosition) {
                MoveToNextInQueue();
                yield return new WaitUntil((() => _grid.WorldPosToGridPos(_fakeGhostTransform.position) == _gridPosition));
            }
        }
        
        private void CalculatePath(Vector2Int targetPosition) {
            _pathInGridQueue = _pathCalculator.SetTarget(_gridPosition, targetPosition);
        }
        
        
        private void MoveToNextInQueue() {
            _pathInGridQueue.TryDequeue(out var nextPosition);
            _gridAgent.SetAgentPositionAtGrid(nextPosition);
            _gridPosition = _gridAgent.PositionInGrid;
        }


    }
}