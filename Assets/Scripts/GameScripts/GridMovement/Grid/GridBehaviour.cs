using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts{
    public class GridBehaviour : MonoBehaviour{
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float offSetX;
        [SerializeField] private float offSetY;
        [SerializeField] private SOSingleVector2Int _sizeSingleton;
        
        private BaseMatrixGrid _grid;

        public void CreateGrid() {
            _grid = new BaseMatrixGrid(rows, columns, transform.position, offSetX, offSetY);
            _sizeSingleton.Value = new Vector2Int(rows, columns);
        }

        public BaseMatrixGrid Grid => _grid;

        private void OnDrawGizmos() {
            if(Application.isPlaying) {
                foreach (var cell in _grid.CellsMatrix) {
                    Gizmos.DrawWireCube(cell.WorldPosition, new Vector3(offSetX, offSetY, 0));
                }
            }
        }
    }
}