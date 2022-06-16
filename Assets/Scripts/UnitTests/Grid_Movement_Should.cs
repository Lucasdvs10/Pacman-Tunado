using GameScripts;
using NUnit.Framework;
using UnityEngine;

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
        gridAgent.MoveRight();

        Assert.AreEqual(MatrixGrid.Position(1,2), gridAgent.PositionInGrid);
    }
    
    [Test]
    public void Walk_To_Left_Cell() {
        gridAgent.MoveLeft();

        Assert.AreEqual(MatrixGrid.Position(1,0), gridAgent.PositionInGrid);
    }
    
    [Test]
    public void Walk_To_Upper_Cell() {
        gridAgent.MoveUp();

        Assert.AreEqual(MatrixGrid.Position(0,1), gridAgent.PositionInGrid);
    }
    
    [Test]
    public void Walk_To_Botton_Cell() {
        gridAgent.MoveDown();

        Assert.AreEqual(MatrixGrid.Position(2,1), gridAgent.PositionInGrid);
    }

    [Test]
    public void Not_Walk_On_Grid_Right_Edge() {
        gridAgent.MoveRight();
        gridAgent.MoveRight();
        
        Assert.AreEqual(MatrixGrid.Position(1,2) ,gridAgent.PositionInGrid);
    }
    
    [Test]
    public void Not_Walk_On_Grid_Up_Edge() {
        gridAgent.MoveUp();
        gridAgent.MoveUp();
        
        Assert.AreEqual(MatrixGrid.Position(0,1) ,gridAgent.PositionInGrid);
    }
    
    [Test]
    public void Not_Walk_To_Not_Walkable_Cells() {
        grid.TurnOffWalkableFlag(Vector2Int.up);
        
        gridAgent.MoveUp();

        Assert.AreEqual(MatrixGrid.Position(1,1) ,gridAgent.PositionInGrid);
    }

    [Test]
    public void Not_Walk_When_Cant_Walk_Flag_Is_True() {
        gridAgent.CantWalk = true;
        
        gridAgent.MoveLeft();
        
        Assert.AreEqual(MatrixGrid.Position(1,1) ,gridAgent.PositionInGrid);
    }

    [Test]
    public void Change_World_Position() {
        var currentWorldPosition = gridAgent.WorldPosition;
        
        gridAgent.MoveRight();
        
        Assert.AreNotEqual(currentWorldPosition, gridAgent.WorldPosition);
        Assert.AreEqual(grid.CellsMatrix[1,2].WorldPosition, gridAgent.WorldPosition);
    }
    
    [Test]
    public void Agent_World_Position_Must_Be_Same_As_12_Cell() {
        gridAgent.MoveRight();
        
        Assert.AreEqual(grid.CellsMatrix[1,2].WorldPosition, gridAgent.WorldPosition);
    }
    
}
