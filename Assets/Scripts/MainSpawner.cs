using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainSpawner : MonoBehaviour
{
    TileGatherer tileGatherer;
    ItemsToPool itemsToPool;
    [SerializeField] private List<GameObject> childSpawners = new List<GameObject>();
    private Spawner[] childSpawnersArray;
    [SerializeField] private GameObject itemParent;

    public Dictionary<Vector2, GameObject> items = new Dictionary<Vector2, GameObject>();
    private GameObject[] itemsArray;
    private List<GameObject> itemsList = new List<GameObject>();

    [SerializeField] private List<GameObject> emptyTiles = new List<GameObject>();

    private void Start()
    {
        itemsToPool = FindObjectOfType<ItemsToPool>();
        tileGatherer = FindObjectOfType<TileGatherer>();
        FindChildSpawners();
    }

    private void OnEnable()
    {
        GameManager.OnGameStatesChanged += FindTilesOfEachChildSpawner;
        GameManager.OnGameStatesChanged += FindEmptyTilesOnEachColumn;
        GameManager.OnGameStatesChanged += SpawnNewItemsForEmptyTiles;
        //GameManager.OnGameStatesChanged += CheckMatchingDone;
    }

    private void OnDisable()
    {
        GameManager.OnGameStatesChanged -= FindTilesOfEachChildSpawner;
        GameManager.OnGameStatesChanged -= FindEmptyTilesOnEachColumn;
        GameManager.OnGameStatesChanged -= SpawnNewItemsForEmptyTiles;
        //GameManager.OnGameStatesChanged -= CheckMatchingDone;
    }

    private void FindChildSpawners()
    {
        childSpawnersArray = GetComponentsInChildren<Spawner>();
        for(int i = 0; i < childSpawnersArray.Length; i++)
        {
            childSpawners.Add(transform.GetChild(i).gameObject);
        }
    }

    private void FindTilesOfEachChildSpawner(GameState state)
    {
        if(state == GameState.TileGatheringDone)
        {
            foreach (GameObject childSpawner in childSpawners)
            {
                foreach (var tileTransform in tileGatherer.tileDic)
                {
                    if (childSpawner.transform.position.x == tileTransform.Key.x)
                    {
                        childSpawner.GetComponent<Spawner>().ownTiles.Add(tileTransform.Value);
                    }
                }
            }

            itemsArray = new GameObject[64];
            itemsArray = GameObject.FindGameObjectsWithTag("Item");
            items.Clear();
            itemsList.Clear();
            foreach (GameObject item in itemsArray)
            {
                itemsList.Add(item);
            }

            foreach (GameObject item in itemsList)
            {
                items.Add(item.transform.position, item);
            }

            GameManager.Instance.UpdateGameStates(GameState.AdjacentsFounding);
        }
        
    }

    private void FindEmptyTilesOnEachColumn(GameState state)
    {
        if(state == GameState.EmptyTilesFounding)
        {
            /*foreach(var tile in tileGatherer.tileDic)
            {
                if (!tile.Value.transform.GetChild(1).gameObject.activeInHierarchy)
                {
                    emptyTiles.Add(tile.Value);
                    
                }
                
            }*/
            
            for (int i = 0; i < 8 * 2; i += 2)
            {
                for (int j = 0; j < 8 * 2; j += 2)
                {
                    if (!tileGatherer.tileDic[new Vector2(i-7,j-7)].transform.GetChild(1).gameObject.activeInHierarchy)
                    {
                        emptyTiles.Add(tileGatherer.tileDic[new Vector2(i - 7, j - 7)]);
                    }
                }
            }

            
            
        }
    }

    private void SpawnNewItemsForEmptyTiles(GameState state)
    {
        if(state == GameState.Spawning)
        {
            foreach (GameObject childSpawner in childSpawners)
            {
                for (int i = 0; i < childSpawner.GetComponent<Spawner>().emptyTiles.Count; i++)
                {
                    GameObject item = itemsToPool.GetItem(itemsList[Random.Range(0, itemsList.Count)]);
                    item.transform.parent = itemParent.transform;
                    item.transform.position = childSpawner.transform.position;
                }
            }
        }
        

        /*gameManager.items.Clear();
        foreach (GameObject item in gameManager.itemsValues)
        {
            foreach (Vector2 itemTransform in gameManager.itemsKeys)
            {
                if ((Vector2)item.transform.position == itemTransform)
                {
                    gameManager.items.Add(item.transform.position, item);
                }
            }
        }*/

        /*itemsArray = GameObject.FindGameObjectsWithTag("Item");
        foreach(GameObject item in itemsArray)
        {
            items.Add(item.transform.position, item);
        }*/

        /*if (OnCycleDone != null)
        {
            OnCycleDone();
        }*/
    }
}
