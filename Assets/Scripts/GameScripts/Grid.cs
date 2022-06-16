namespace GameScripts{
    public class Grid{
        private GridCell[,] _cellsGrid;

        
        
        
        
        public Grid(int numRows, int numCols) {
            _cellsGrid = new GridCell[numRows, numCols];

            InitializeGrid(numRows, numCols);
        }

        private void InitializeGrid(int numRows, int numCols) {
            for (int i = 0; i < numRows; i++) {
                for (int j = 0; j < numCols; j++) {
                    _cellsGrid[i, j] = new GridCell(i, j);
                }
            }
        }
    }
}