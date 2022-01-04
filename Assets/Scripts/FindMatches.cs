using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatches : MonoBehaviour
{
    public GameObject left, right, top, bottom;
    public bool horizontalMatch, verticalMatch;
    /*private ItemsToSpawn itemsToSpawn;

    private Dictionary<Vector2, GameObject> items = new Dictionary<Vector2, GameObject>();

    public delegate void ItemsDicFilled();
    public static event ItemsDicFilled OnItemsDicFilled;

    private void Awake()
    {
        itemsToSpawn = FindObjectOfType<ItemsToSpawn>();
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        ItemsToSpawn.OnBooardFilled += FillItemDic;
        OnItemsDicFilled += GetAdjacentItems;
    }

    private void OnDisable()
    {
        ItemsToSpawn.OnBooardFilled -= FillItemDic;
        OnItemsDicFilled -= GetAdjacentItems;
    }

    private void FillItemDic()
    {
        if(itemsToSpawn.items != null)
        {
            foreach (GameObject item in itemsToSpawn.items)
            {
                items.Add(item.transform.position, item);
            }
        }
        
        if(OnItemsDicFilled != null)
        {
            OnItemsDicFilled();
        }
    }

    private void GetAdjacentItems()
    {
        if (transform.position.x != -7)
        {
            if (items.ContainsKey(new Vector2(transform.position.x - 2, transform.position.y)))
            {
                left = items[new Vector2(transform.position.x - 2, transform.position.y)];
            }
        }
        if (transform.position.x != 7)
        {
            if (items.ContainsKey(new Vector2(transform.position.x + 2, transform.position.y)))
            {
                right = items[new Vector2(transform.position.x + 2, transform.position.y)];
            }
        }
        if (transform.position.y != -7)
        {
            if (items.ContainsKey(new Vector2(transform.position.x, transform.position.y - 2)))
            {
                bottom = items[new Vector2(transform.position.x, transform.position.y - 2)];
            }
        }
        if (transform.position.y != 7)
        {
            if (items.ContainsKey(new Vector2(transform.position.x, transform.position.y + 2)))
            {
                top = items[new Vector2(transform.position.x, transform.position.y + 2)];
            }
        }

        CheckMatches();
    }

    private void CheckMatches()
    {
        if ((left != null && right != null) && (left.name == right.name) && (left.name == gameObject.name || right.name == gameObject.name))
        {
            horizontalMatch = true;
            Debug.Log("Horizontal Match found");
        }
        else if ((top != null && bottom != null) && (top.name == bottom.name) &&(top.name == gameObject.name || bottom.name == gameObject.name))
        {

            verticalMatch = true;
            Debug.Log("Vertical Match found");
        }
        else
        {
            return;
        }
    }*/
}
