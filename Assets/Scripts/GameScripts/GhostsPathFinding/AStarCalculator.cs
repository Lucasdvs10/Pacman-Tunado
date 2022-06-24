using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class AStarCalculator : IPathCalculator{
        private BaseMatrixGrid _grid;
        private AStarNode[,] _matrixNode;

        private HashSet<AStarNode> _openSet;
        private HashSet<AStarNode> _closeSet;
        
        public Queue<Vector2Int> SetTarget(Vector2Int startPosition, Vector2Int endPosition) {
            _openSet = new HashSet<AStarNode>();
            _closeSet = new HashSet<AStarNode>();
            AStarNode currentNode;
            
            Stack<Vector2Int> stackToReturn = new Stack<Vector2Int>();

            var startNode = new AStarNode(_grid, startPosition, endPosition);
            _openSet.Add(startNode);

            while (true) {
                if (_openSet.Count <= 0) 
                    return null;
                
                currentNode = GetCheapestNode();
                _openSet.Remove(currentNode);
                _closeSet.Add(currentNode);
                currentNode.InitializeNeighbours(ref _matrixNode);
                
                if(currentNode.GridPosition == endPosition)
                    break;

                foreach (var neighbour in currentNode.NeighboursSet) {
                    if(_closeSet.Contains(neighbour))
                        continue;

                    if (!_openSet.Contains(neighbour)) {
                        neighbour.SetParentAndRecalculateCost(currentNode);
                        _openSet.Add(neighbour);
                    }
                    else {
                        var oldCost = neighbour.FCost;
                        var oldParent = neighbour.ParentNode;
                        
                        neighbour.SetParentAndRecalculateCost(currentNode);
                        
                        if(neighbour.FCost > oldCost)
                            neighbour.SetParentAndRecalculateCost(oldParent);
                    }
                }
            }
            
            while (currentNode != startNode) {
                stackToReturn.Push(currentNode.GridPosition);
                currentNode = currentNode.ParentNode;
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