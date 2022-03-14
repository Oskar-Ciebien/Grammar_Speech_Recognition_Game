using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // == Public Fields ==
    public Text levelText;

    // == Private Fields ==
    private string currentLevel;

    private void Update()
    {
        // If score is above the set score for level two
        if (PlayerPrefs.GetInt("Score") >= GameManager.levelTwoScore)
        {
            // Increase game speed
            Time.timeScale = GameManager.levelTwoSpeed;

            currentLevel = "Level 2";
        }
        else
        {
            currentLevel = "Level 1";
        }

        // Display level on the Screen
        levelText.text = currentLevel.ToString();
    }
}
