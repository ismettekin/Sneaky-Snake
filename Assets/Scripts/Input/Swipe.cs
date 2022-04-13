using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    //public SwipeManager swipeManager;
    public Vector3 snakePos;
    public Vector3 desiredPos;

    private void Awake()
    {
        snakePos = transform.position;
        desiredPos = transform.localPosition;
    }
    private void Update()
    {
        if(SwipeManager.Instance != null)
        {
            if (SwipeManager.Instance.SwipeLeft)
                desiredPos += Vector3.left;
            if (SwipeManager.Instance.SwipeRight)
                desiredPos += Vector3.right;
            if (SwipeManager.Instance.SwipeUp)
                desiredPos += Vector3.up;
            if (SwipeManager.Instance.SwipeDown)
                desiredPos += Vector3.down;

            transform.position = Vector3.MoveTowards(transform.position, desiredPos, 3f * Time.deltaTime);

            if (SwipeManager.Instance.Tap)
                Debug.Log("Tapping!");
        }
    }

    //private void Movement()
    //{
    //    if (swipeManager.SwipeLeft)
    //        desiredPos += Vector3.left;
    //    if (swipeManager.SwipeRight)
    //        desiredPos += Vector3.right;
    //    if (swipeManager.SwipeUp)
    //        desiredPos += Vector3.up;
    //    if (swipeManager.SwipeDown)
    //        desiredPos += Vector3.down;
    //
    //    transform.position = Vector3.MoveTowards(transform.position, desiredPos, 3f * Time.deltaTime);
    //}

}
