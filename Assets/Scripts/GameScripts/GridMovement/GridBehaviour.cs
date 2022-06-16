using System;
using UnityEngine;

namespace GameScripts{
    public class GridBehaviour : MonoBehaviour{
        [SerializeField] private int rows;
        [SerializeField] private int colums;
        
        private MatrixGrid _grid;

        private void Awake() {
            _grid = new MatrixGrid(rows, colums);
        }
    }
}