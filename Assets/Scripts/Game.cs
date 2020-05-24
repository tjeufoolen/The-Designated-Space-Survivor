using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject GameOverObject = null;
    [SerializeField] private Camera Camera = null;
    [SerializeField] private Text TraveledDistanceText = null;

    private int distance = 0;

    void Start()
    {
        TraveledDistanceText.text = "0";
    }

    void Update()
    {
        updateDistanceTraveled();
    }

    private void updateDistanceTraveled()
    {
        if (!GameOverObject.activeSelf)
        {
            distance = (int)Mathf.Ceil(Mathf.Abs(Camera.transform.position.x));
            TraveledDistanceText.text = distance.ToString();
        }
    }

    public void Die()
    {
        GameOverObject.SetActive(true);
        PlayerPrefs.SetInt("Highscore", distance);
        ((GameOver)GameOverObject.GetComponent(typeof(GameOver))).UpdateScoreText(distance);
    }
}
