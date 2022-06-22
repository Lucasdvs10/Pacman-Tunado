using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class AStarCalculator{
        private BaseMatrixGrid _grid;
        private AStarNode[,] _matrixNode;

        public Queue<Vector2Int> SetPath(Vector2Int right, Vector2Int vector2Int) {
            throw new System.NotImplementedException();
        }
        
        
        public AStarCalculator(BaseMatrixGrid grid) {
            _grid = grid;
            _matrixNode = new AStarNode[grid.NumRows, grid.NumColums];
        }
    }
}