using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    
    private GameObject _tile;
    private int xTileNumber = 8;
    private int yTileNumber = 8;

    

    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        for(int i = 0; i < xTileNumber*2; i+=2)
        {
            for(int j = 0; j < yTileNumber*2; j+=2)
            {
                _tile = TilePooler.TileInstance.GetTileFromPool();

                if (_tile != null)
                {
                    _tile.SetActive(true);
                }

                _tile.transform.position = new Vector2(i-7, j-7);
            }
        }

        GameManager.Instance.UpdateGameStates(GameState.TileGathering);
        
    }
}
