﻿using System;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts{
    [Serializable]
    public class GridAgent{
        private BaseMatrixGrid _grid;
        private Vector2Int _positionInGrid;
        private Vector2 _worldPosition;
        public event Action OnPositionChangedEvent;



        public void Move(Vector2Int direction) {
            SetAgentPositionAtGrid(_positionInGrid + direction);
        }
        
        public void SetAgentPositionAtGrid(Vector2Int newGridPosition) {
            if(!CanWalk || newGridPosition == _positionInGrid)
                return;
            
            int xPosition = newGridPosition.x;
            int yPosition = newGridPosition.y;
            
            if (newGridPosition.x >= _grid.NumColums || newGridPosition.x < 0) {
                xPosition = Mathf.Clamp(newGridPosition.x, 0, _grid.NumColums - 1);
            }
            
            if (newGridPosition.y >= _grid.NumRows || newGridPosition.y < 0) {
                yPosition = Mathf.Clamp(newGridPosition.y, 0, _grid.NumRows - 1);
            }
            
            if(!_grid.CellsMatrix[xPosition,yPosition].Walkable)
                return;
            
            _positionInGrid = BaseMatrixGrid.Position(xPosition, yPosition);
            _worldPosition = _grid.GetCellAtGridPosition(_positionInGrid).WorldPosition;
            OnPositionChangedEvent?.Invoke();
        }


        public Vector2Int PositionInGrid => _positionInGrid;

        public Vector2 WorldPosition => _worldPosition;

        public bool CanWalk { get; set; } = true;

        public GridAgent(BaseMatrixGrid grid) {
            _grid = grid;
            _positionInGrid = Vector2Int.zero;
            _worldPosition = _grid.CellsMatrix[_positionInGrid.x, _positionInGrid.y].WorldPosition;
        }
        public GridAgent(BaseMatrixGrid grid, Vector2Int positionInGrid) {
            _grid = grid;
            _positionInGrid = positionInGrid;
            _worldPosition = _grid.CellsMatrix[_positionInGrid.x, _positionInGrid.y].WorldPosition;

        }
    }
}