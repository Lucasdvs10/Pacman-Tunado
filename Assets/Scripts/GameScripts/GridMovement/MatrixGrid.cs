using UnityEngine;

namespace GameScripts{
    public class MatrixGrid{
        private GridCell[,] _cellsGrid;
        private int _numRows;
        private int _numColums;

        public static Vector2Int Position(int i, int j) => new Vector2Int(i, j);
        
        public void TurnOffWalkableFlag(Vector2Int cellPosition) {
            _cellsGrid[cellPosition.x, cellPosition.y].SetWalkable(false);
        }
        
        public void TurnOnWalkableFlag(Vector2Int cellPosition) {
            _cellsGrid[cellPosition.x, cellPosition.y].SetWalkable(true);
        }
        
        private void InitializeGrid(int numRows, int numCols) {
            for (int i = 0; i < numRows; i++) {
                for (int j = 0; j < numCols; j++) {
                    _cellsGrid[i, j] = new GridCell(i, j);
                }
            }
        }

        public int NumRows => _numRows;

        public int NumColums => _numColums;

        public GridCell[,] CellsGrid => _cellsGrid;

        public MatrixGrid(int numRows, int numCols) {
            _numRows = numRows;
            _numColums = numCols;
            
            _cellsGrid = new GridCell[_numRows, _numColums];

            InitializeGrid(_numRows, _numColums);
        }
    }
}