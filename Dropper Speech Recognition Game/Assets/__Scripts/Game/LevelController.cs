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
            if (GameManager.paused == false)
            {
                // Set the new game speed
                Time.timeScale = GameManager.levelTwoSpeed;
            }
            else if (GameManager.paused == true)
            {
                // Game paused
                Time.timeScale = 0f;
            }

            // Set new spawn rate
            GameManager.resetSpawnTime = 2.5f;

            // Set current level test
            currentLevel = "Level 2";
        }
        else // Otherwise
        {
            if (GameManager.paused == false)
            {
                // Set game speed
                Time.timeScale = GameManager.levelOneSpeed;
            }
            else if (GameManager.paused == true)
            {
                // Game paused
                Time.timeScale = 0f;
            }

            // Set spawn rate
            GameManager.resetSpawnTime = 3f;

            // Set current level test
            currentLevel = "Level 1";
        }

        // Display level on the Screen
        levelText.text = currentLevel.ToString();
    }
}
