using UnityEngine;

namespace GameScripts{
    public class BaseMatrixGrid{
        private GridCell[,] _cellsMatrix;
        private int _numRows;
        private int _numColums;
        private float _offsetX;
        private float _offsetY;

        public static Vector2Int Position(int i, int j) => new Vector2Int(i, j);
        
        public void TurnOffWalkableFlag(Vector2Int cellPosition) {
            _cellsMatrix[cellPosition.x, cellPosition.y].SetWalkable(false);
        }
        
        public void TurnOnWalkableFlag(Vector2Int cellPosition) {
            _cellsMatrix[cellPosition.x, cellPosition.y].SetWalkable(true);
        }

        public GridCell GetCellAtGridPosition(Vector2Int position) {
            return CellsMatrix[position.x, position.y];
        }
        
        private void InitializeGrid(int numRows, int numCols, Vector2 firstCellPosition, float offsetX, float offsetY) {
            for (int i = 0; i < numRows; i++) {
                for (int j = 0; j < numCols; j++) {
                    _cellsMatrix[i, j] = new GridCell(i, j, firstCellPosition + new Vector2(offsetX * j, - offsetY * i));
                }
            }
        }

        public Vector2Int WorldPosToGridPos(Vector2 worldPos) {
            var x = Mathf.RoundToInt(Mathf.Abs((worldPos - _cellsMatrix[0, 0].WorldPosition).y / _offsetX));
            var y = Mathf.RoundToInt(Mathf.Abs((worldPos - _cellsMatrix[0,0].WorldPosition).x / _offsetY));

            return new Vector2Int(x, y);
        }
        
        public int NumRows => _numRows;

        public int NumColums => _numColums;

        public GridCell[,] CellsMatrix => _cellsMatrix;

        public BaseMatrixGrid(int numRows, int numCols, Vector2 firstCellPosition, float offsetX, float offsetY) {
            _numRows = numRows;
            _numColums = numCols;
            _offsetX = offsetX;
            _offsetY = offsetY;
            
            _cellsMatrix = new GridCell[_numRows, _numColums];

            InitializeGrid(_numRows, _numColums, firstCellPosition, offsetX, offsetY);
        }
    }
}