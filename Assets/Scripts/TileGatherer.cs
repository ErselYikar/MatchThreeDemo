using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGatherer : MonoBehaviour
{
    public Dictionary<Vector2, GameObject> tileDic = new Dictionary<Vector2, GameObject>();
    public GameObject[] tiles;


    private void OnEnable()
    {
        GameManager.OnGameStatesChanged += GatherTiles;
    }

    private void OnDisable()
    {
        GameManager.OnGameStatesChanged -= GatherTiles;
    }

    private void GatherTiles(GameState state)
    {
        if(state == GameState.TileGathering)
        {
            tiles = GameObject.FindGameObjectsWithTag("Tile");
            if (tiles != null)
            {
                foreach (GameObject tile in tiles)
                {
                    tileDic.Add(tile.transform.position, tile);
                }
            }
            if(tiles.Length == tileDic.Count)
            {
                GameManager.Instance.UpdateGameStates(GameState.AttendChildsToTiles);
            }
            
        }  
    }
}
