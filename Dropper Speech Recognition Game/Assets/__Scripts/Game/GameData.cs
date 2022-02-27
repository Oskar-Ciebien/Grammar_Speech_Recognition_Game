using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    // == Public Fields ==
    public static GameData singleton;
    public Text scoreText = null;

    // == Private Fields ==
    private static int score = 0;

    private void Update()
    {
        // If scoreText is not null
        if (scoreText != null)
        {
            // Set the score to the text
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }

    private void Awake()
    {
        // Create singleton
        GameObject[] go = GameObject.FindGameObjectsWithTag("GameData");

        // If there is more than one GameData
        if (go.Length > 1)
        {
            // Destroy it
            Destroy(this.gameObject);
        }
        else // Otherwise
        {
            // Don't destroy it
            DontDestroyOnLoad(this.gameObject);
            // Set it as Singleton
            singleton = this;
        }
        // Display score to the text
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();

        // print(score); // Used for testing
        print(PlayerPrefs.GetInt("Score")); // Used for testing
    } // Awake END

    // Updates the Score on the screen
    public static void UpdateScore(int s)
    {
        score = PlayerPrefs.GetInt("Score");
        // Update the score into PlayerPrefs
        PlayerPrefs.SetInt("Score", score += s);
    } // UpdateScore END
} // Class - END