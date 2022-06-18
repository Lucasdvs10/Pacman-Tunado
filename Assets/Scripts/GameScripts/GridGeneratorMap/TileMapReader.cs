﻿using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameScripts.GridGeneratorMap{
    public class TileMapReader : MonoBehaviour{
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private GridBehaviour _gridBehaviour;
        private MatrixGrid _matrixGrid;

        private void Start() {
            _matrixGrid = _gridBehaviour.Grid;

            foreach (var gridCell in (_matrixGrid.CellsMatrix)) {
                if (_tilemap.GetTile(_tilemap.WorldToCell(gridCell.WorldPosition))) {
                    gridCell.SetWalkable(false);
                }
            }
            
        }
        
    }
}