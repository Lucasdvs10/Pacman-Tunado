using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class AStarCalculator : IPathCalculator{
        private BaseMatrixGrid _grid;
        private AStarNode[,] _matrixNode;

        private HashSet<AStarNode> _openSet = new HashSet<AStarNode>();
        private HashSet<AStarNode> _closeSet = new HashSet<AStarNode>();

        private AStarNode _currentNode;
        
        public Queue<Vector2Int> SetTarget(Vector2Int startPosition, Vector2Int endPosition) {
            Stack<Vector2Int> stackToReturn = new Stack<Vector2Int>();

            var startNode = new AStarNode(_grid, startPosition, endPosition);
            _openSet.Add(startNode);

            while (_openSet.Count > 0) {
                _currentNode = GetCheapestNode();
                _openSet.Remove(_currentNode);
                _closeSet.Add(_currentNode);
                _currentNode.InitializeNeighbours(ref _matrixNode);
                
                if(_currentNode.GridPosition == endPosition)
                    break;

                foreach (var neighbour in _currentNode.NeighboursSet) {
                    if(_closeSet.Contains(neighbour))
                        continue;

                    if (!_openSet.Contains(neighbour)) {
                        neighbour.SetParentAndRecalculateCost(_currentNode);
                        _openSet.Add(neighbour);
                    }
                    else {
                        var oldCost = neighbour.FCost;
                        var oldParent = neighbour.ParentNode;
                        
                        neighbour.SetParentAndRecalculateCost(_currentNode);
                        
                        if(neighbour.FCost > oldCost)
                            neighbour.SetParentAndRecalculateCost(oldParent);
                    }
                }
            }

            while (_currentNode != startNode) {
                stackToReturn.Push(_currentNode.GridPosition);
                _currentNode = _currentNode.ParentNode;
            }
            return new Queue<Vector2Int>(stackToReturn);
        }


        private AStarNode GetCheapestNode() {
            var chepeastValue = Mathf.Infinity;
            AStarNode starNode = new AStarNode();

            foreach (var node in _openSet) {
                if (node.FCost < chepeastValue) {
                    chepeastValue = node.FCost;
                    starNode = node;
                }
            }
            return starNode;
        }
        
        public AStarCalculator(BaseMatrixGrid grid) {
            _grid = grid;
            _matrixNode = new AStarNode[grid.NumRows, grid.NumColums];
        }
    }
}