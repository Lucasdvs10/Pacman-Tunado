using GameScripts;
using NUnit.Framework;
using UnityEngine;

namespace UnitTests{
    public class Matrix_Grid_Should{
        private MatrixGrid grid;
        
        [SetUp]
        public void Setup_Tests() {
            grid = new MatrixGrid(3, 3, Vector2.zero, 1,1);
        }
        
        [Test]
        public void Return_10() {
            var worldPosition = new Vector2(0.6f, 0);

            var gridPosition = grid.WorldPosToGridPos(worldPosition);
            
            Assert.AreEqual(new Vector2Int(0,1), gridPosition);
        }
        
        [Test]
        public void Return_1_1() {
            var worldPosition = new Vector2(0.9f, -0.6f);

            var gridPosition = grid.WorldPosToGridPos(worldPosition);
            
            Assert.AreEqual(new Vector2Int(1,1), gridPosition);
        }
        
        [Test]
        public void Return_11() {
            grid = new MatrixGrid(3, 3, new Vector2(-10, -10), 1, 1);
            var worldPosition = new Vector2(-11,-11);

            var gridPosition = grid.WorldPosToGridPos(worldPosition);
            
            Assert.AreEqual(new Vector2Int(1,1), gridPosition);
        }
    }
}