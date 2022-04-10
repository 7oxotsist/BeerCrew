using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine;

public class SimpleRandomWalkGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParametrs;
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParametrs, startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parametrs, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int>  floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parametrs.iterations; i++)
        {
            var path = ProcedualGeneratingAlgorythm.SimpleRandomWalk(currentPosition, parametrs.walkLength);
            floorPositions.UnionWith(path);
            if(parametrs.startRandomlyEachIteration)
            currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

}
