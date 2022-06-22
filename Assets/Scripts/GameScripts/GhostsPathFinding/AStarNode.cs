using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class AStarNode{
        private BaseMatrixGrid _grid;
        private Vector2Int _gridPosition;
        private GridCell _gridCell;
        private float _distanceToNeighbour = 10f;
        private Vector2Int _endPosition;
        
        private HashSet<AStarNode> _neighboursSet = new HashSet<AStarNode>();
        private AStarNode _parentNode;

        private float _fCost;
        private float _hCost;
        private float _gCost = 0;
        
        
        
        public void InitializeNeighbours(ref AStarNode[,] matrixNode) {
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    var rowPosition = _gridPosition.x + i;
                    var colPosition = _gridPosition.y + j;
                    
                    if(rowPosition < 0 || rowPosition >= _grid.NumRows || colPosition < 0 || colPosition >= _grid.NumColums) //Se a posição estiver fora da grid
                        continue;
                    
                    if(!_grid.CellsMatrix[rowPosition,colPosition].Walkable || Mathf.Abs(i) == Mathf.Abs(j)) //Se não for walkable ou se estiver na diagonal
                        continue;

                    if (matrixNode[rowPosition, colPosition] == null) {
                        var node = new AStarNode(_grid, new Vector2Int(rowPosition, colPosition), _endPosition);
                        node.SetParentAndRecalculateCost(this);
                        matrixNode[rowPosition, colPosition] = node;
                    }
                    _neighboursSet.Add(matrixNode[rowPosition, colPosition]);
                }
                
            }
        }

        public void CalculateFCost() {
            _hCost = Mathf.Abs(_endPosition.x - _gridPosition.x) + Mathf.Abs(_endPosition.y - _gridPosition.y);

            _gCost = _parentNode._gCost + _distanceToNeighbour;

            _fCost = _gCost + _hCost;
        }
        
        public void SetParentAndRecalculateCost(AStarNode parent) {
            _parentNode = parent;
            CalculateFCost();
        }
        
        public AStarNode(BaseMatrixGrid grid, GridCell gridCell, Vector2Int endPosition) {
            _grid = grid;
            _gridCell = gridCell;
            _gridPosition = _gridCell.GridPosition;
            _endPosition = endPosition;
        }

        public AStarNode(BaseMatrixGrid grid, Vector2Int gridPosition, Vector2Int endPosition) {
            _grid = grid;
            _gridPosition = gridPosition;
            _endPosition = endPosition;
            _gridCell = _grid.GetCellAtGridPosition(_gridPosition);
        }

        public AStarNode() {
        }

        public BaseMatrixGrid Grid => _grid;

        public Vector2Int GridPosition => _gridPosition;

        public GridCell GridCell => _gridCell;

        public HashSet<AStarNode> NeighboursSet => _neighboursSet;

        public AStarNode ParentNode => _parentNode;

        public float FCost => _fCost;
    }
}