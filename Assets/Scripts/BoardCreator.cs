using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    private GameObject _tile;
    private int xTileNumber = 8;
    private int yTileNumber = 8;
    private int yMaxNumber = 2;
    private float farLeft = -3.5f;

    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        for(int i = 0; i < xTileNumber; i++)
        {
            for(int j = 0; j < yTileNumber; j++)
            {
                _tile = TilePooler.TileInstance.GetTileFromPool();

                if (_tile != null)
                {
                    _tile.SetActive(true);
                }
                
                for(int y = 3; y > yMaxNumber; y--)
                {
                    _tile.transform.position = new Vector2(farLeft, y);
                }
                yMaxNumber--;
            }
            farLeft++;
            yMaxNumber = 2;
        }
    }
}
