using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject TilePrefab;
    public int Width = 6;
    public int Height = 4;
    public Sprite[] Sprites;
    Tile[] Tiles;

    public bool CanMove = false;
    IEnumerator Start()
    {
        CreateTiles(Width, Height);
        ShuffleTiles();
        PlaceTiles();
        CanMove = false;
        yield return new WaitForSeconds(3f);
        CanMove = true;
        HideTiles();
    }

    
    void Update()
    {
        
    }
    Tile CreateTile(Sprite FaceSprite)
    {
        var gameobject = Instantiate(TilePrefab);
        
        var tile = gameobject.GetComponent<Tile>();
        tile.Active = true;
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
    void HideTiles()
    {
        Tiles.ToList().ForEach(tile => tile.Active = false);
    }
    public void CheckPair()
    {
        StartCoroutine(CheckPairCoroutine());
    }
     IEnumerator CheckPairCoroutine()
    {
        var tilesActive = Tiles.Where(tile=>!tile.TimeToDie).Where(tile => tile.Active).ToArray();
        if (tilesActive.Length != 2)
            yield break;
        var tile1 = tilesActive[0];
        var tile2 = tilesActive[1];

        CanMove = false;
        yield return new WaitForSeconds(1f);
        CanMove = true;

        if (tile1.BackFace == tile2.BackFace)
        {
            tile1.TimeToDie = true;
            tile2.TimeToDie = true;
        }
        else
        {
            tile1.Active = false;
            tile2.Active = false;
        }
        if (CheckIfEnd())
        {
            CanMove = false;
            Debug.Log("GameOver");
            yield return new WaitForSeconds(1f);
            Application.Quit();
        }
    }
    bool CheckIfEnd()
    {
        return Tiles.All(tile => tile.TimeToDie == true);
    }
   
}
