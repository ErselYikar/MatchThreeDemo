using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePooler : MonoBehaviour
{
    public static TilePooler TileInstance;
    public List<GameObject> tileObjects;
    [SerializeField] private GameObject tileToPool;
    [SerializeField] private GameObject board;
    private int poolAmount = 64;

    private void Awake()
    {
        TileInstance = this;
    }

    void OnEnable()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject tile = Instantiate(tileToPool);
            tile.SetActive(false);
            tileObjects.Add(tile);
            tile.transform.parent = board.transform;
        }
    }

    public GameObject GetTileFromPool()
    {
        for(int i = 0; i <tileObjects.Count; i++)
        {
            if (!tileObjects[i].activeInHierarchy)
            {
                return tileObjects[i];
            }
        }
        return null;
    }
}
