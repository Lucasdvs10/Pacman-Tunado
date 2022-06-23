using System.Collections.Generic;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class PathFindingBehaviour : MonoBehaviour{
       [SerializeField] private GridBehaviour _gridBehaviour;
       [SerializeField] private SOSingleVector2Int _targetPosition;

       private GridAgent _gridAgent;
       private BaseMatrixGrid _grid;
       private IPathCalculator _pathCalculator;
       private Queue<Vector2Int> _pathQueue;
       private Vector2Int _gridPosition;
       
        private void Start() {
            _grid = _gridBehaviour.Grid;
            _pathCalculator = new AStarCalculator(_grid);
            _gridAgent = new GridAgent(_grid, _grid.WorldPosToGridPos(transform.position));
        }

        private void Update() {
            _gridPosition = _gridAgent.PositionInGrid;
            transform.position = _gridAgent.WorldPosition;
        }

    }
}