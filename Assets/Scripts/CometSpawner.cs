using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public Camera cam;
    public GameObject gameOver;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if (!gameOver.activeSelf)
        {
            Vector2 position = cam.transform.position;
            position.y = Random.Range(CameraExtensions.BoundsMin(cam).y, CameraExtensions.BoundsMax(cam).y);
            position.x = CameraExtensions.BoundsMax(cam).x;

            objectPooler.SpawnFromPool("Comets", position, Quaternion.identity);
        }
    }
}
