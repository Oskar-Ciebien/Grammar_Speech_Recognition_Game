using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCountdown : MonoBehaviour
{
    // == Public Fields ==
    public Text countdownText;

    // == Private Fields ==
    private int timeNextLevel = 0;

    void Start()
    {
        // If countdownText is not active and not enabled
        if (countdownText.isActiveAndEnabled == false)
        {
            // Set active
            countdownText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        // If the score away from level two is 3
        if (GameManager.levelTwoScore - PlayerPrefs.GetInt("Score") == 3)
        {
            // Set the time to 3
            timeNextLevel = 3;
        }
        // If the score away from level two is 2
        else if (GameManager.levelTwoScore - PlayerPrefs.GetInt("Score") == 2)
        {
            // Set the time to 2
            timeNextLevel = 2;
        }
        // If the score away from level two is 1
        else if (GameManager.levelTwoScore - PlayerPrefs.GetInt("Score") == 1)
        {
            // Set the time to 1
            timeNextLevel = 1;
        }
        else // Otherwise
        {
            // Set the time back to 0
            timeNextLevel = 0;
        }


        // If the time to next level is equal to 0
        if (timeNextLevel == 0)
        {
            // Disable countdown text object
            countdownText.gameObject.SetActive(false);
        }
        else // Otherwise
        {
            // Enable countdown text object
            countdownText.gameObject.SetActive(true);

            // Display text
            countdownText.text = "Next Level in: " + timeNextLevel.ToString();
        }
    }
}
