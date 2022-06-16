using GameScripts;
using NUnit.Framework;
using UnityEngine;
using Grid = UnityEngine.Grid;

public class Grid_Movement_Should{
    
    [Test]
    public void Walk_To_Right_Cell() {
        Grid grid = new Grid(3,3); //cria uma grid 4x4
        GridAgent gridAgent = new GridAgent(grid); //cria um agente que vai andar na dada grid
        gridAgent.SetAgentPositionAtGrid(Vector2Int.one);

        gridAgent.MoveRight();

        Assert.AreEqual(Vector2Int.up, gridAgent.GridPosition); //usaremos os vetores inteiros para a posição na grid
                                                                        //Não pense mais em x e y. Pense em Linha e coluna.
                                                                        //Portanto eu espero que a posição do agente seja linha 0 coluna 1
    }

  
}
