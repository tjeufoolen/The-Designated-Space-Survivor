using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TEMP
        if (Input.GetButtonDown("Jump"))
        {
            GameOver.SetActive(!GameOver.activeSelf);
        }
        //END TEMP
    }
}
