using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> ownTiles = new List<GameObject>();
    public List<GameObject> emptyTiles = new List<GameObject>();

    /*private GameManager gameManager;
    private ItemsToPool itemsToPool;
    private ItemsToSpawn itemsToSpawn;
    private Dictionary<Vector2, GameObject> spawnerTiles = new Dictionary<Vector2, GameObject>();
    private Dictionary<Vector2, GameObject> emptyTiles = new Dictionary<Vector2, GameObject>();

    

    public delegate void NewItemsSpawned();
    public static event NewItemsSpawned OnNewItemsSpawned;

    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        itemsToPool = FindObjectOfType<ItemsToPool>();
        itemsToSpawn = FindObjectOfType<ItemsToSpawn>();
    }

    private void OnEnable()
    {
        GameManager.OnTileGatheringDone += FindTilesonColumn;
    }

    private void OnDisable()
    {
        GameManager.OnTileGatheringDone -= FindTilesonColumn;
    }

    private void FindTilesonColumn()
    {
        foreach(var tile in gameManager.tileDic)
        {
            if(gameObject.transform.position.x == tile.Key.x)
            {
                spawnerTiles.Add(tile.Key, tile.Value);
            }
        }

        if(spawnerTiles.Count == 8)
        {
            FindEmptyTiles();
        }
        
    }

    private void FindEmptyTiles()
    {
        
        foreach(var spawnerTile in spawnerTiles)
        {
            if (!gameManager.itemsKeys.Contains(spawnerTile.Key))
            {
                emptyTiles.Add(spawnerTile.Key, spawnerTile.Value);
            }
        }

        foreach(var emptyTile in emptyTiles)
        {
            Debug.Log("Tile X: " + emptyTile.Key.x + " Tile Y: " + emptyTile.Key.y);
        }
        SummonNewItems();
    }

    private void SummonNewItems()
    {
        if(emptyTiles != null)
        {
            for(int i = 0; i< emptyTiles.Count; i++)
            {
                GameObject item = itemsToPool.GetItem(itemsToSpawn.itemList[Random.Range(0,itemsToSpawn.itemList.Count)]);
                item.transform.position = gameObject.transform.position;
                gameManager.itemsKeys.Add(item.transform.position);
            }
        }
        

        if(OnNewItemsSpawned != null)
        {
            OnNewItemsSpawned();
        }
    }*/
}
