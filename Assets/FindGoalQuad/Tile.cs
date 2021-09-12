using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int w, h;
    
    [SerializeField]
    Material matPassed;
    Material matOriginal;

    public TileType tType;

    private void Awake()
    {
        matOriginal = GetComponentInChildren<MeshRenderer>().material;
    }
    public void SetTile(int w, int h, TileType tT)
    {
        this.w = w;
        this.h = h;

        tType = tT;
    }

    public void SetWalked(bool b)
    {
        if (b)
        {
            tType = TileType.WALKEDON;
            GetComponentInChildren<MeshRenderer>().material = matPassed;
        }
        else
        {
            tType = TileType.EMPTY;
            GetComponentInChildren<MeshRenderer>().material = matOriginal;
        }

    }
}

public enum TileType
{
    GOAL,
    AGENT,
    EMPTY,
    WALKEDON,
    Z
}
