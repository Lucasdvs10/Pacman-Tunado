using UnityEngine;

namespace GameScripts{
    public class CentralizeObjectAtCell : MonoBehaviour{
        [SerializeField] private GridBehaviour _gridBehaviour;
        private BaseMatrixGrid _grid;
        
        private void Start() {
            _grid = _gridBehaviour.Grid;

            var gridPos = _grid.WorldPosToGridPos(transform.position);
            var cell = _grid.GetCellAtGridPosition(gridPos);

            transform.position = cell.WorldPosition;
        }
    }
}