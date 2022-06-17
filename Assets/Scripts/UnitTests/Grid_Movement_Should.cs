using GameScripts;
using NUnit.Framework;
using UnityEngine;

namespace UnitTests{
    public class Grid_Movement_Should{
        MatrixGrid grid; 
        GridAgent gridAgent; 
    
        [SetUp]
        public void Setup_Tests() {
            grid = new MatrixGrid(3,3, Vector2.zero, 1,1);
            gridAgent = new GridAgent(grid, Vector2Int.one);
        }
    
        [Test]
        public void Walk_To_Right_Cell() {
            MoveGridAgentRight();

            Assert.AreEqual(MatrixGrid.Position(1,2), gridAgent.PositionInGrid);
        }
    
        [Test]
        public void Walk_To_Left_Cell() {
            MoveGridAgentLeft();

            Assert.AreEqual(MatrixGrid.Position(1,0), gridAgent.PositionInGrid);
        }
    
        [Test]
        public void Walk_To_Upper_Cell() {
            MoveGridAgentUp();

            Assert.AreEqual(MatrixGrid.Position(0,1), gridAgent.PositionInGrid);
        }
    
        [Test]
        public void Walk_To_Botton_Cell() {
            MoveGridAgentDown();

            Assert.AreEqual(MatrixGrid.Position(2,1), gridAgent.PositionInGrid);
        }

        [Test]
        public void Not_Walk_On_Grid_Right_Edge() {
            MoveGridAgentRight();
            MoveGridAgentRight();
        
            Assert.AreEqual(MatrixGrid.Position(1,2) ,gridAgent.PositionInGrid);
        }
    
        [Test]
        public void Not_Walk_On_Grid_Up_Edge() {
            MoveGridAgentUp();
            MoveGridAgentUp();
        
            Assert.AreEqual(MatrixGrid.Position(0,1) ,gridAgent.PositionInGrid);
        }
    
        [Test]
        public void Not_Walk_To_Not_Walkable_Cells() {
            grid.TurnOffWalkableFlag(Vector2Int.up);
        
            MoveGridAgentUp();

            Assert.AreEqual(MatrixGrid.Position(1,1) ,gridAgent.PositionInGrid);
        }

        [Test]
        public void Not_Walk_When_Can_Walk_Flag_Is_False() {
            gridAgent.CanWalk = false;
        
            MoveGridAgentLeft();
        
            Assert.AreEqual(MatrixGrid.Position(1,1) ,gridAgent.PositionInGrid);
        }

        [Test]
        public void Change_World_Position() {
            var currentWorldPosition = gridAgent.WorldPosition;
        
            MoveGridAgentRight();
        
            Assert.AreNotEqual(currentWorldPosition, gridAgent.WorldPosition);
            Assert.AreEqual(grid.CellsMatrix[1,2].WorldPosition, gridAgent.WorldPosition);
        }
    
        [Test]
        public void Agent_World_Position_Must_Be_Same_As_12_Cell() {
            MoveGridAgentRight();
        
            Assert.AreEqual(grid.CellsMatrix[1,2].WorldPosition, gridAgent.WorldPosition);
        }

        private void MoveGridAgentRight() {
            gridAgent.Move(Vector2Int.up);
        }
        private void MoveGridAgentLeft() {
            gridAgent.Move(Vector2Int.down);
        }
    
        private void MoveGridAgentUp() {
            gridAgent.Move(Vector2Int.left);
        }
    
        private void MoveGridAgentDown() {
            gridAgent.Move(Vector2Int.right);
        }
    
    }
}
