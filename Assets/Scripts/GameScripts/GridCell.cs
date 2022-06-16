using UnityEngine;

namespace GameScripts{
    public class GridCell{
        private bool _walkable;
        private Vector2Int _gridPosition;


        public void SetWalkable(bool walkableFlag) {
            _walkable = walkableFlag;
        }
        
        public bool Walkable => _walkable;
        public Vector2Int GridPosition => _gridPosition;
        public GridCell(Vector2Int gridPosition, bool walkable = true) {
            _walkable = walkable;
            _gridPosition = gridPosition;
        }

        public GridCell(int i, int j ,bool walkable = true) {
            _gridPosition = new Vector2Int(i, j);
            _walkable = walkable;
        }
    }
}