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
            // If Game is not paused
            if (GameManager.paused == false)
            {
                // Set the new game speed
                Time.timeScale = GameManager.levelTwoSpeed;
            }
            // Otherwise if game is paused
            else if (GameManager.paused == true)
            {
                // Freeze the game
                Time.timeScale = 0f;
            }

            // Set new spawn rate
            GameManager.resetSpawnTime = 2.5f;

            // Set current level test
            currentLevel = "Level 2";
        }
        else // Otherwise
        {
            // If the game is not paused
            if (GameManager.paused == false)
            {
                // Set game speed
                Time.timeScale = GameManager.levelOneSpeed;
            }
            // Otherwise if the game is paused
            else if (GameManager.paused == true)
            {
                // Freeze the game
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
} // Class - END
