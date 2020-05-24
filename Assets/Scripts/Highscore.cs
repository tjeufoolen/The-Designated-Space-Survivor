using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Header;
    [SerializeField] private TextMeshProUGUI Value;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", -1);

        if (highscore == -1)
        {
            Header.text = "";
            Value.text = "";
        }  else
        {
            Value.text = highscore.ToString();
        }
    }
}
