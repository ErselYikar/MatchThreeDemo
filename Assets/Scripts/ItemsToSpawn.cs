using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToSpawn : MonoBehaviour
{
    //public ItemsToSpawn Instance;

    private GameObject item;
    private ItemsToPool itemPool;
    public List<GameObject> itemList;
    public GameObject[] items = new GameObject[64];
    [SerializeField] private GameObject itemParent;
    
    public delegate void BoardFilled();
    public static event BoardFilled OnBooardFilled; 

    private void Start()
    {
        itemPool = FindObjectOfType<ItemsToPool>();
        CreateItems();
    }

    private void CreateItems()
    {
        for (int i = 0; i < 8*2; i+=2)
        {
            for (int j = 0; j < 8*2; j+=2)
            {
                item = itemPool.GetItem(itemList[Random.Range(0,itemList.Count)]);
                item.transform.position = new Vector2(i - 7, j - 7);
                item.transform.parent = itemParent.transform;

            }
        }
        
        if (OnBooardFilled != null)
        {
            OnBooardFilled();
        }

    }
}


