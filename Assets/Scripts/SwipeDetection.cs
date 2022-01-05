using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetection : MonoBehaviour
{
    public static SwipeDetection Instance;

    private Vector2 startPos;
    private float startTime;
    private Vector2 endPos;
    private float endTime;
    private float directionThreshold = .9f;

    private float minDist = .2f;
    private float maxTime = 1f;

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
    }

    private void OnEnable()
    {
        InputManager.OnStartTouch += SwipeStart;
        InputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= SwipeStart;
        InputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPos = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPos = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if(Vector3.Distance(startPos,endPos) >= minDist &&
            (endTime - startTime) <= maxTime)
        {
            Debug.DrawLine(startPos, endPos, Color.red, 5f);
            Vector3 dir = endPos - startPos;
            Vector2 dir2D = new Vector2(dir.x, dir.y).normalized;
            SwipeDirection(dir2D);
        }
    }

    public void SwipeDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(startPos).x, Camera.main.ScreenToWorldPoint(startPos).y), Vector2.zero, 0f);

        if (hit)
        {
            Debug.Log("Hit " + hit.transform.gameObject.name);
            if (hit.transform.gameObject.tag == "Item")
            {
                if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
                {
                    GameObject item = hit.transform.gameObject;
                    Vector3 temp = item.transform.position;
                    item.transform.position = item.GetComponent<Item>().up.transform.position;
                    item.GetComponent<Item>().up.transform.position = temp;
                    Debug.Log("Swipe Up");
                }
                else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
                {
                    GameObject item = hit.transform.gameObject;
                    Vector3 temp = item.transform.position;
                    item.transform.position = item.GetComponent<Item>().bottom.transform.position;
                    item.GetComponent<Item>().bottom.transform.position = temp;
                    Debug.Log("Swipe Down");
                }
                else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
                {
                    GameObject item = hit.transform.gameObject;
                    Vector3 temp = item.transform.position;
                    item.transform.position = item.GetComponent<Item>().right.transform.position;
                    item.GetComponent<Item>().right.transform.position = temp;
                    Debug.Log("Swipe Right");
                }
                else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
                {
                    GameObject item = hit.transform.gameObject;
                    Vector3 temp = item.transform.position;
                    item.transform.position = item.GetComponent<Item>().left.transform.position;
                    item.GetComponent<Item>().left.transform.position = temp;
                    Debug.Log("Swipe Left");
                }
            }
        }
        else
        {
            Debug.Log("No hit");
        }
    }

}
