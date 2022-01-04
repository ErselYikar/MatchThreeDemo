using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject left, secondLeft, right, secondRight, up, secondUp, bottom, secondBottom;
    public bool horizontalMatch, verticalMatch;
    private Dictionary<Vector2, GameObject> items = new Dictionary<Vector2, GameObject>();
    private GameObject[] itemsArray = new GameObject[64];
    private ItemsToPool itemsToPool;
    

    private void OnEnable()
    {
        GameManager.OnGameStatesChanged += FindAdjacentItems;
        itemsToPool = FindObjectOfType<ItemsToPool>();
        GameManager.OnGameStatesChanged += FindMatches;
    }

    private void OnDisable()
    {
        GameManager.OnGameStatesChanged += FindAdjacentItems;
        GameManager.OnGameStatesChanged -= FindMatches;
    }

    private void FindAdjacentItems(GameState state)
    {
        if(state == GameState.AdjacentsFounding)
        {
            itemsArray = GameObject.FindGameObjectsWithTag("Item");
            foreach (GameObject item in itemsArray)
            {
                items.Add(item.transform.position, item);
            }

            foreach (var item in items)
            {
                if (item.Key.x != -7 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x - 2, item.Key.y)))
                    {
                        left = items[new Vector2(item.Key.x - 2, item.Key.y)];
                    }
                }
                if (item.Key.x != 7 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x + 2, item.Key.y)))
                    {
                        right = items[new Vector2(item.Key.x + 2, item.Key.y)];
                    }
                }
                if (item.Key.y != -7 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y - 2)))
                    {
                        bottom = items[new Vector2(item.Key.x, item.Key.y - 2)];
                    }
                }
                if (item.Key.y != 7 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y + 2)))
                    {
                        up = items[new Vector2(item.Key.x, item.Key.y + 2)];
                    }
                }
                if (item.Key.x != -5 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x - 4, item.Key.y)))
                    {
                        secondLeft = items[new Vector2(item.Key.x - 4, item.Key.y)];
                    }
                }
                if (item.Key.x != 5 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x + 4, item.Key.y)))
                    {
                        secondRight = items[new Vector2(item.Key.x + 4, item.Key.y)];
                    }
                }
                if (item.Key.y != -5 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y - 4)))
                    {
                        secondBottom = items[new Vector2(item.Key.x, item.Key.y - 4)];
                    }
                }
                if (item.Key.y != 5 && item.Key == (Vector2)gameObject.transform.position)
                {
                    if (items.ContainsKey(new Vector2(item.Key.x, item.Key.y + 4)))
                    {
                        secondUp = items[new Vector2(item.Key.x, item.Key.y + 4)];
                    }
                }
            }

            GameManager.Instance.UpdateGameStates(GameState.MatchChecking);
        }
    }

    private void FindMatches(GameState state)
    {
        if(state == GameState.MatchChecking)
        {
            /*if ((bottom != null && up != null && secondBottom != null && secondUp != null) && 
                (bottom.name == gameObject.name || up.name == gameObject.name))
            {
                if(secondBottom.name == gameObject.name)
                {
                    itemsToPool.ReturnItem(secondBottom);
                }
                if(secondUp.name == gameObject.name)
                {
                    itemsToPool.ReturnItem(secondUp);
                }
                itemsToPool.ReturnItem(bottom);
                itemsToPool.ReturnItem(up);
                itemsToPool.ReturnItem(gameObject);
            }

            if ((left != null && right != null && secondLeft != null && secondRight != null) &&
               (left.name == gameObject.name || right.name == gameObject.name))
            {
                if (secondLeft.name == gameObject.name)
                {
                    itemsToPool.ReturnItem(secondLeft);
                }
                if (secondRight.name == gameObject.name)
                {
                    itemsToPool.ReturnItem(secondRight);
                }
                itemsToPool.ReturnItem(left);
                itemsToPool.ReturnItem(right);
                itemsToPool.ReturnItem(gameObject);
            }*/

            if ((left != null && right != null) && (left.name == right.name) &&
            (left.name == gameObject.name || right.name == gameObject.name))
            {
                itemsToPool.ReturnItem(left);
                itemsToPool.ReturnItem(right);
                itemsToPool.ReturnItem(gameObject);
            }

            if ((bottom != null && up != null) && (bottom.name == up.name) &&
                (bottom.name == gameObject.name || up.name == gameObject.name))
            {
                itemsToPool.ReturnItem(bottom);
                itemsToPool.ReturnItem(up);
                itemsToPool.ReturnItem(gameObject);
            }
        }

        GameManager.Instance.UpdateGameStates(GameState.EmptyTilesFounding);
        
    }
        
}
