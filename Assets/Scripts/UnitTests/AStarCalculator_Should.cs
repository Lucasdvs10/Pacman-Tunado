using System.Collections.Generic;
using GameScripts;
using GameScripts.ExtentionMethods;
using GameScripts.GhostsPathFinding;
using NUnit.Framework;
using UnityEngine;

namespace UnitTests{
    public class AStarCalculator_Should{
        private Queue<Vector2Int> _pathQueueStraightLine = new Queue<Vector2Int>();
        private BaseMatrixGrid _grid;
        private AStarCalculator _aStarCalculator;

        [SetUp]
        public void Setup_Tests() {
            _grid = new BaseMatrixGrid(3, 3, Vector2.zero, 1f,1f);
            _aStarCalculator = new AStarCalculator(_grid);

            var initialPosition = Vector2Int.right; //(1,0)
            
            _pathQueueStraightLine.Enqueue(initialPosition);
            _pathQueueStraightLine.Enqueue(initialPosition + Vector2Int.up); //(1,1)
            _pathQueueStraightLine.Enqueue(initialPosition + Vector2Int.up * 2); //(1,2)
            
        }

        [Test]
        public void Return_Straigh_Line_Path() {
            Queue<Vector2Int> path = _aStarCalculator.SetPath(Vector2Int.right, new Vector2Int(1, 2));
            
            Assert.IsTrue(path.IsSameValues(_pathQueueStraightLine));   
        }
        
    }
}