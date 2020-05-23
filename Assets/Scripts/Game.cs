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

    private int distance = 0;

    void Update()
    {
        updateDistanceTraveled();
    }

    private void updateDistanceTraveled()
    {
        if (!GameOver.activeSelf)
        {
            distance = (int)Mathf.Ceil(Mathf.Abs(Camera.transform.position.x));
            TraveledDistanceText.text = distance.ToString();
        }
    }

    public void Die()
    {
        GameOver.SetActive(true);
        ((GameOver) GameOver.GetComponent(typeof(GameOver))).UpdateScoreText(distance);
    }
}
