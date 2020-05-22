using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject GameOver;
    public Camera Camera;
    public Text TraveledDistanceText;

    void Update()
    {
        updateDistanceTraveled();
    }

    private void updateDistanceTraveled()
    {
        int distance = (int) Mathf.Ceil(Mathf.Abs(Camera.transform.position.x));
        TraveledDistanceText.text = distance.ToString();
    }
}
