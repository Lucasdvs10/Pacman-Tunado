using UnityEngine;

namespace GameScripts{
    public class MatrixGrid{
        private GridCell[,] _cellsMatrix;
        private int _numRows;
        private int _numColums;

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

        public int NumRows => _numRows;

        public int NumColums => _numColums;

        public GridCell[,] CellsMatrix => _cellsMatrix;

        public MatrixGrid(int numRows, int numCols, Vector2 firstCellPosition, float offsetX, float offsetY) {
            _numRows = numRows;
            _numColums = numCols;
            
            _cellsMatrix = new GridCell[_numRows, _numColums];

            InitializeGrid(_numRows, _numColums, firstCellPosition, offsetX, offsetY);
        }
    }
}