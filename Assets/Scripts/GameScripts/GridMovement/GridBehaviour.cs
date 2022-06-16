using System;
using UnityEngine;

namespace GameScripts{
    public class GridBehaviour : MonoBehaviour{
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float offSetX;
        [SerializeField] private float offSetY;
        
        private MatrixGrid _grid;

        private void Awake() {
            _grid = new MatrixGrid(rows, columns, transform.position, offSetX, offSetY);
        }

        public MatrixGrid Grid => _grid;

        private void OnDrawGizmos() {
            if(Application.isPlaying) {
                foreach (var cell in _grid.CellsMatrix) {
                    Gizmos.DrawWireCube(cell.WorldPosition, new Vector3(offSetX, offSetY, 0));
                }
            }
        }
    }
}