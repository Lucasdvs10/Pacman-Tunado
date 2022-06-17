using System;
using UnityEngine;

namespace GameScripts{
    [Serializable]
    public class GridAgent{
        private MatrixGrid _grid;
        private Vector2Int _positionInGrid;
        private Vector2 _worldPosition;
        public event Action OnPositionChangedEvent;


        public void MoveRight() {
         SetAgentPositionAtGrid(_positionInGrid + Vector2Int.up);
        }
        
        public void MoveLeft() {
            SetAgentPositionAtGrid(_positionInGrid + Vector2Int.down);
        }
        
        public void MoveUp() {
            SetAgentPositionAtGrid(_positionInGrid + Vector2Int.left);
        }
        
        public void MoveDown() {
            SetAgentPositionAtGrid(_positionInGrid + Vector2Int.right);
        }
        
        
        public void SetAgentPositionAtGrid(Vector2Int newGridPosition) {
            if(CantWalk)
                return;
            
            int xPosition = newGridPosition.x;
            int yPosition = newGridPosition.y;
            
            if (newGridPosition.x >= _grid.NumColums || newGridPosition.x < 0) {
                xPosition = Mathf.Clamp(newGridPosition.x, 0, _grid.NumColums - 1);
            }
            
            if (newGridPosition.y >= _grid.NumRows || newGridPosition.y < 0) {
                yPosition = Mathf.Clamp(newGridPosition.y, 0, _grid.NumRows - 1);
            }
            
            if(!_grid.CellsMatrix[xPosition,yPosition].Walkable)
                return;
            
            _positionInGrid = MatrixGrid.Position(xPosition, yPosition);
            _worldPosition = _grid.GetCellAtGridPosition(_positionInGrid).WorldPosition;
            OnPositionChangedEvent?.Invoke();
        }


        public Vector2Int PositionInGrid => _positionInGrid;

        public Vector2 WorldPosition => _worldPosition;

        public bool CantWalk { get; set; }

        public GridAgent(MatrixGrid grid) {
            _grid = grid;
            _positionInGrid = Vector2Int.zero;
            _worldPosition = _grid.CellsMatrix[_positionInGrid.x, _positionInGrid.y].WorldPosition;
        }
        public GridAgent(MatrixGrid grid, Vector2Int positionInGrid) {
            _grid = grid;
            _positionInGrid = positionInGrid;
            _worldPosition = _grid.CellsMatrix[_positionInGrid.x, _positionInGrid.y].WorldPosition;

        }
    }
}