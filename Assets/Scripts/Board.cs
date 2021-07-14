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
        ShuffleTiles();
        PlaceTiles();
    }

    
    void Update()
    {
        
    }
    Tile CreateTile(Sprite FaceSprite)
    {
        var gameobject = Instantiate(TilePrefab);
        
        var tile = gameobject.GetComponent<Tile>();
        tile.BackFace = FaceSprite;
        return tile;
    }
    void CreateTiles(int x, int y)
    {
        var length = Width * Height;
        Tiles = new Tile[length];

        for(int z = 0; z < length; z++)
        {
            var sprite = Sprites[z / 2];
            Tiles[z] = CreateTile(sprite);
        }

        
    }
    void ShuffleTiles()
    {
        for(int i = 0; i < 1000; i++)
        {
            int index1 = Random.Range(0, Tiles.Length);
            int index2 = Random.Range(0, Tiles.Length);
            var tile1 = Tiles[index1];
            var tile2 = Tiles[index2];

            Tiles[index1] = tile2;
            Tiles[index2] = tile1;
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
   
}
