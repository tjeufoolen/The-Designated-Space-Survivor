using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void UpdateScoreText(int score)
    {
        TextMeshProUGUI scoreText =  GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
