using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    private ObjectPooler objectPooler;
    [SerializeField] private Camera cam = null;
    [SerializeField] private GameObject gameOver = null;

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
