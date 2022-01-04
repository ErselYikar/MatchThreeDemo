using System.Collections.Generic;
using UnityEngine;


public class ItemsToPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> itemsPool = new Dictionary<string, Queue<GameObject>>();
    
    public GameObject GetItem(GameObject item)
    {
        if(itemsPool.TryGetValue(item.name, out Queue<GameObject> itemList))
        {
            if(itemList.Count == 0)
            {
                return CreateNewItem(item);
            }
            else
            {
                GameObject _item = itemList.Dequeue();
                _item.SetActive(true);
                return _item;
            }
        }
        else
        {
            return CreateNewItem(item);
        }
    }

    private GameObject CreateNewItem(GameObject item)
    {
        GameObject newItem = Instantiate(item);
        newItem.name = item.name;
        return newItem;
    }

    public void ReturnItem(GameObject item)
    {
        if(itemsPool.TryGetValue(item.name, out Queue<GameObject> itemList))
        {
            itemList.Enqueue(item);
        }
        else
        {
            Queue<GameObject> newItemQueue = new Queue<GameObject>();
            newItemQueue.Enqueue(item);
            itemsPool.Add(item.name, newItemQueue);
        }

        item.SetActive(false);
    }
}
