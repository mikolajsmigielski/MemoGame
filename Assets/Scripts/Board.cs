using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject TilePrefab;
    public int Width = 6;
    public int Height = 4;
    public Sprite[] Sprites;
    void Start()
    {
        CreateTiles(Width, Height);
        
    }

    
    void Update()
    {
        
    }
    void CreateTiles(int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                CreateTile(i, j);
            }
        }
    }
    Sprite GetRandomSprite()
    {
        int length = Sprites.Length;
        int index = Random.Range(0, length - 1);
        return Sprites[index];
    }
    void CreateTile(int x, int y)
    {
        var tile = Instantiate(TilePrefab);
        tile.transform.position += Vector3.up * y * 2f + Vector3.right * x * 2f;
        tile.GetComponent<Tile>().BackFace = GetRandomSprite();
    }
}
