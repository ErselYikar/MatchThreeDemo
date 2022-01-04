using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<GameState> OnGameStatesChanged;

    public GameState State;

    //private ItemsToSpawn itemsToSpawn;
    //private ItemsToPool itemsToPool;
    //public Dictionary<Vector2, GameObject> items = new Dictionary<Vector2, GameObject>();
    //public Dictionary<Vector2, GameObject> spawnerDic = new Dictionary<Vector2, GameObject>();
    //public Dictionary<Vector2, GameObject> tileDic = new Dictionary<Vector2, GameObject>();
    //public List<Vector2> itemsKeys = new List<Vector2>();
    //public List<GameObject> itemsValues = new List<GameObject>();
    //public GameObject[] spawners;
    //public GameObject[] tiles;

    /*public delegate void ItemsDicFilled();
    public static event ItemsDicFilled OnItemsDicFilled;

    public delegate void AdjacentsFound();
    public static event AdjacentsFound OnAdjacentsFound;

    public delegate void MatchedFound();
    public static event MatchedFound OnMatchesFound;

    public delegate void TileGatheringDone();
    public static event TileGatheringDone OnTileGatheringDone;*/

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //itemsToSpawn = FindObjectOfType<ItemsToSpawn>();
        //itemsToPool = FindObjectOfType<ItemsToPool>();
    }

    private void OnEnable()
    {
        //ItemsToSpawn.OnBooardFilled += FillItemDic;
        //OnItemsDicFilled += GetAdjacentItems;
        //OnMatchesFound += GatherSpawners;
        //OnAdjacentsFound += CheckMatches;
        //BoardCreator.OnBoardCreationDone += GatherTiles;
    }

    private void OnDisable()
    {
        //ItemsToSpawn.OnBooardFilled -= FillItemDic;
        //OnItemsDicFilled -= GetAdjacentItems;
        //OnMatchesFound -= GatherSpawners;
        //OnAdjacentsFound -= CheckMatches;
        //BoardCreator.OnBoardCreationDone -= GatherTiles;
    }

    public void UpdateGameStates(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Ready:
                break;
            case GameState.TileGathering:
                break;
            case GameState.MatchChecking:
                break;
            case GameState.Spawning:
                break;
            case GameState.TileGatheringDone:
                break;
            case GameState.AdjacentsFounding:
                break;
            case GameState.EmptyTilesFounding:
                break;
        }

        OnGameStatesChanged?.Invoke(newState);
    }

    private void Start()
    {
        //UpdateGameStates(GameState.TileGathering);
    }

    /*public void FillItemDic()
    {
        itemsToSpawn.items = GameObject.FindGameObjectsWithTag("Item");
        if (itemsToSpawn.items != null)
        {
            foreach (GameObject item in itemsToSpawn.items)
            {
                items.Add(item.transform.position, item);
                itemsKeys.Add(item.transform.position);
                itemsValues.Add(item);
            }
        }
        if (OnItemsDicFilled != null)
        {
            OnItemsDicFilled();
        }
    }*/

    

    /*private void GetAdjacentItems()
    {
        foreach(var item in items)
        {
            if (item.Key.x != -7)
            {
                if (items.ContainsKey(new Vector2(item.Key.x - 2, item.Key.y)))
                {
                    item.Value.GetComponent<FindMatches>().left = items[new Vector2(item.Key.x - 2, item.Key.y)];
                }
            }
            if (item.Key.x != 7)
            {
                if (items.ContainsKey(new Vector2(item.Key.x + 2, item.Key.y)))
                {
                    item.Value.GetComponent<FindMatches>().right = items[new Vector2(item.Key.x + 2, item.Key.y)];
                }
            }
            if (item.Key.y != -7)
            {
                if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y - 2)))
                {
                    item.Value.GetComponent<FindMatches>().bottom = items[new Vector2(item.Key.x, item.Key.y - 2)];
                }
            }
            if (item.Key.y != 7)
            {
                if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y + 2)))
                {
                    item.Value.GetComponent<FindMatches>().top = items[new Vector2(item.Key.x, item.Key.y + 2)];
                }
            }
        }
 
        if(OnAdjacentsFound != null)
        {
            OnAdjacentsFound();
        }
    }

    private void CheckMatches()
    {
        foreach(var item in items)
        {
            if ((item.Value.GetComponent<FindMatches>().left != null && item.Value.GetComponent<FindMatches>().right != null) && 
                (item.Value.GetComponent<FindMatches>().left.name == item.Value.GetComponent<FindMatches>().right.name) && 
                (item.Value.GetComponent<FindMatches>().left.name == item.Value.name || 
                item.Value.GetComponent<FindMatches>().right.name == item.Value.name))
            {
                item.Value.GetComponent<FindMatches>().horizontalMatch = true;
                itemsKeys.Remove(item.Key);
                itemsValues.Remove(item.Value);
                itemsToPool.ReturnItem(item.Value);
            }
            else if ((item.Value.GetComponent<FindMatches>().top != null && item.Value.GetComponent<FindMatches>().bottom != null) && 
                (item.Value.GetComponent<FindMatches>().top.name == item.Value.GetComponent<FindMatches>().bottom.name) && 
                (item.Value.GetComponent<FindMatches>().top.name == item.Value.GetComponent<FindMatches>().gameObject.name || 
                item.Value.GetComponent<FindMatches>().bottom.name == item.Value.GetComponent<FindMatches>().gameObject.name))
            {
                item.Value.GetComponent<FindMatches>().verticalMatch = true;
                itemsKeys.Remove(item.Key);
                itemsValues.Remove(item.Value);
                itemsToPool.ReturnItem(item.Value);
            }
        }
        

        if(OnMatchesFound != null)
        {
            OnMatchesFound();
        }
        
    }*/

    /*private void GatherSpawners()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawnerDic.Add(spawner.transform.position, spawner);
        }
    }*/

    /*private void GatherTiles()
    {
        
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        if (tiles != null)
        {
            foreach (GameObject tile in tiles)
            {
                tileDic.Add(tile.transform.position, tile);
            }
        }

        if(OnTileGatheringDone != null)
        {
            OnTileGatheringDone();
        }
    }*/

}

public enum GameState
{
    Ready,
    TileGathering,
    TileGatheringDone,
    AdjacentsFounding,
    MatchChecking,
    EmptyTilesFounding,
    Spawning
}
