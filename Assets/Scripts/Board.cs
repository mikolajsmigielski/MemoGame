using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject TilePrefab;
    public int Width = 6;
    public int Height = 4;
    public Sprite[] Sprites;
    Tile[] Tiles;
    void Start()
    {
        CreateTiles(Width, Height);
        PlaceTiles();
    }

    
    void Update()
    {
        
    }
    Tile CreateTile()
    {
        var gameobject = Instantiate(TilePrefab);
        
        var tile = gameobject.GetComponent<Tile>();
        tile.BackFace = GetRandomSprite();
        return tile;
    }
    void CreateTiles(int x, int y)
    {
        var length = Width * Height;
        Tiles = new Tile[length];

        for(int z = 0; z < length; z++)
        {
            Tiles[z] = CreateTile();
        }

        
    }
    void PlaceTiles()
    {
        for (int z = 0; z < Width * Height; z++)
        {
            int x = z % Width;
            int y = z / Width;
            Tiles[z].transform.position = Vector3.up * y * 2f + Vector3.right * x * 2f;
        }
    }
    Sprite GetRandomSprite()
    {
        int length = Sprites.Length;
        int index = Random.Range(0, length - 1);
        return Sprites[index];
    }
    
}
