using System;
using UnityEngine;

namespace GameScripts{
    [Serializable]
    public class GridCell{
        private bool _walkable;
        private Vector2Int _gridPosition;
        private Vector2 _worldPosition;


        public void SetWalkable(bool walkableFlag) {
            _walkable = walkableFlag;
        }
        
        public bool Walkable => _walkable;
        public Vector2Int GridPosition => _gridPosition;

        public Vector2 WorldPosition => _worldPosition;

        public GridCell(Vector2Int gridPosition,Vector2 worldPosition, bool walkable = true) {
            _walkable = walkable;
            _gridPosition = gridPosition;
            _worldPosition = worldPosition;
        }

        public GridCell(int i, int j ,Vector2 worldPosition ,bool walkable = true) {
            _gridPosition = new Vector2Int(i, j);
            _walkable = walkable;
            _worldPosition = worldPosition;
        }
    }
}