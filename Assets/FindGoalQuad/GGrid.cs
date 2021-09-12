using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGrid : MonoBehaviour
{

    [SerializeField]
    Tile tilePrefab;

    public Tile[,] Tiles { get; private set; }

    [SerializeField]
    GameObject goalPrefab;

    GameObject goal;
    SearchAgent sAgent;



    public int width, height;
    float boardScale = 1;
    private void Awake()
    {
        InstantiateGrid();
        AddGoalToGrid();
        

    }

    void InstantiateGrid()
    {
        Tiles = new Tile[width, height];

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                var t = Tiles[w, h] = Instantiate(tilePrefab, transform, false);
                t.transform.localPosition = new Vector3(w * boardScale, 0, h * boardScale);

                t.SetTile(w, h, TileType.EMPTY);
            }
        }
    }

    public void ResetGrid()
    {

        //Debug.Log("RESETTING GRID");
        foreach (Tile ti in Tiles)
        {
            
            ti.SetWalked(false);
        }

        Tile tA = GetFreeRandomTile();
        sAgent.transform.localPosition = new Vector3(tA.w, 0, tA.h);
        sAgent.currentTile = tA;
        tA.tType = TileType.AGENT;

        
        Tile tG = GetFreeRandomTile();
        tG.tType = TileType.GOAL;
        //Debug.Log($"Set type: {tG.tType}");
        goal.transform.localPosition = new Vector3(tG.w, 0, tG.h);
        
    }

    void AddGoalToGrid()
    {
        var t = GetFreeRandomTile();

        goal = Instantiate(goalPrefab, transform, false);
        goal.transform.localPosition = new Vector3(t.w * boardScale, .5f, t.h * boardScale);
        t.tType = TileType.GOAL;

        
    }


    public SearchAgent AddAgentToGrid(SearchAgent p)
    {
        var t = GetFreeRandomTile();

        sAgent = Instantiate(p, transform, false);
        sAgent.transform.localPosition = new Vector3(t.w * boardScale, .5f, t.h * boardScale);
        
        sAgent.InitializeAgent(this, t);
        t.tType = TileType.AGENT;
        return sAgent;
    }

    Tile GetFreeRandomTile()
    {
        int coordsW;
        int coordsH;
        do
        {
            coordsW = Random.Range(0, width);
            coordsH = Random.Range(0, height);
        } while (Tiles[coordsH, coordsW].tType != TileType.EMPTY);

        return Tiles[coordsH, coordsW];
    }

    public float TryMoveInDirection(SearchAgent sA, Dir d)
    {
        Tile nextTile = GetTileFromDirection(sA.currentTile, d);

        if (nextTile == null) return -1f;       //PUNISH

        sA.MoveToTile(nextTile);

        return -.01f;                           //PUNISH
    }

    Tile GetTileFromDirection(Tile currentTile, Dir d)
    {
        (int wD, int hD) = GetCoordsFromDirection(d);

        if(DoesTileExist(currentTile.w + wD,currentTile.h + hD))
        {
            return Tiles[currentTile.w + wD, currentTile.h + hD];
        }
        return null;
    }

    bool DoesTileExist(int w, int h)
    {
        if (w < 0 || w >= width) return false;
        if (h < 0 || h >= height) return false;

        return true;
    }
    public bool DoesNextTileExist(Tile t, Dir d)
    {
        (int wD, int hD) = GetCoordsFromDirection(d);
        return DoesTileExist(t.w + wD, t.h + hD);

    }

    (int w, int h) GetCoordsFromDirection(Dir d)
    {
        switch (d)
        {
            case Dir.UP:
                return (0, 1);
            case Dir.LEFT:
                return (-1, 0);
            case Dir.DOWN:
                return (0, -1);
            case Dir.RIGHT:
                return (1, 0);
            default:
                throw new System.Exception("direction does not exist");
        }
    }
}

public enum Dir
{
    UP,
    LEFT,
    DOWN,
    RIGHT,
    X
}
