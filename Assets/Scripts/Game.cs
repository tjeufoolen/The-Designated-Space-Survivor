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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateDistanceTraveled();

        //TEMP
        if (Input.GetButtonDown("Jump"))
        {
            GameOver.SetActive(!GameOver.activeSelf);
        }
        //END TEMP
    }

    private void updateDistanceTraveled()
    {
        int distance = (int) Mathf.Ceil(Mathf.Abs(Camera.transform.position.x));
        TraveledDistanceText.text = distance.ToString();
    }
}
