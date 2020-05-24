using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    /**
     * Code from;
     * https://www.youtube.com/watch?v=Mp6BWCMJZH4&t=32s
     */

    [SerializeField] private GameObject[] levels = new GameObject[0];
    private Camera mainCamera;
    private Vector2 screenBounds;
    [SerializeField] private float choke = 0.25f;

    [Space]
    [Header("ScrollSpeed")]
    [SerializeField] private float scrollSpeed = 15f;
    [SerializeField] private float maxScrollSpeed = 30f;
    [Tooltip("The amount of seconds in which the scrollspeed should be increased")]
    [SerializeField] private float scrollSpeedIncreaseSeconds = 3;
    [Tooltip("The amount in which the scrollspeed should be increased")]
    [SerializeField] private float scrollSpeedIncreaseAmount = 1;

    private Vector3 lastScreenPosition;
    private long startTime;

    void Start()
    {
        InvokeRepeating("increaseScrollSpeed", 0, scrollSpeedIncreaseSeconds);

        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
        lastScreenPosition = transform.position;
    }

    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;
    }


    private void increaseScrollSpeed()
    {
        if (scrollSpeed < maxScrollSpeed)
        {
            scrollSpeed += scrollSpeedIncreaseAmount;
        }
    }

    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);
            float parallaxSpeed = 1 - Mathf.Abs(transform.position.z / obj.transform.position.z);
            float difference = transform.position.x - lastScreenPosition.x;
            obj.transform.Translate(Vector3.right * difference * parallaxSpeed);
        }
        lastScreenPosition = transform.position;
    }
}
