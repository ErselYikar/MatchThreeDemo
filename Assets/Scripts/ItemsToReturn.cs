using UnityEngine;

public class ItemsToReturn : MonoBehaviour
{
    private ItemsToPool itemPool;

    private void Start()
    {
        itemPool = FindObjectOfType<ItemsToPool>();
    }

    private void OnDisable()
    {
        if(itemPool != null)
        {
            itemPool.ReturnItem(this.gameObject);
        }
    }
}
