using GameScripts.SOSingletons;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameScripts.GridGeneratorMap{
    public class TileMapReader : MonoBehaviour{
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private SOAvaibleCellsSingleton _avaibleCellsSingleton;
        private BaseMatrixGrid _baseMatrixGrid;

        private void Awake() {
            _gridBehaviour.CreateGrid();
            _baseMatrixGrid = _gridBehaviour.Grid;

            foreach (var gridCell in (_baseMatrixGrid.CellsMatrix)) {
                if (_tilemap.GetTile(_tilemap.WorldToCell(gridCell.WorldPosition))) {
                    gridCell.SetWalkable(false);
                }
            }

            foreach (var cell in _baseMatrixGrid.CellsMatrix) {
                if (_baseMatrixGrid.IsCellAvaible(cell.GridPosition)) {
                    _avaibleCellsSingleton.CellsDict.Add(cell.GridPosition, cell);
                }
            }

        }
        
    }
}