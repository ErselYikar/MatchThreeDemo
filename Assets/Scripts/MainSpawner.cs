using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    TileGatherer tileGatherer;
    ItemsToPool itemsToPool;
    [SerializeField] private List<GameObject> childSpawners = new List<GameObject>();
    private Spawner[] childSpawnersArray;
    [SerializeField] private GameObject itemParent;

    private Dictionary<Vector2, GameObject> items = new Dictionary<Vector2, GameObject>();
    private GameObject[] itemsArray;
    private List<GameObject> itemsList = new List<GameObject>();

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
    }

    private void OnDisable()
    {
        GameManager.OnGameStatesChanged -= FindTilesOfEachChildSpawner;
        GameManager.OnGameStatesChanged -= FindEmptyTilesOnEachColumn;
        GameManager.OnGameStatesChanged -= SpawnNewItemsForEmptyTiles;
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
            foreach (GameObject childSpawner in childSpawners)
            {
                foreach (GameObject tilesOfChildSpawners in childSpawner.GetComponent<Spawner>().ownTiles)
                {
                    if (!items.ContainsKey(tilesOfChildSpawners.transform.position))
                    {
                        childSpawner.GetComponent<Spawner>().emptyTiles.Add(tilesOfChildSpawners);
                    }
                }
            }

            //GameManager.Instance.UpdateGameStates(GameState.Spawning);
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
