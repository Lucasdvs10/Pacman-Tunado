using UnityEngine;

namespace GameScripts{
    public class GridAgent{
        private MatrixGrid _grid;
        private Vector2Int _positionInGrid;


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
            
            if(!_grid.CellsGrid[xPosition,yPosition].Walkable)
                return;
            
            _positionInGrid = MatrixGrid.Position(xPosition, yPosition);
        }


        public Vector2Int PositionInGrid => _positionInGrid;
        
        public bool CantWalk { get; set; }

        public GridAgent(MatrixGrid grid) {
            _grid = grid;
            _positionInGrid = Vector2Int.zero;
        }
        public GridAgent(MatrixGrid grid, Vector2Int positionInGrid) {
            _grid = grid;
            _positionInGrid = positionInGrid;
        }
    }
}