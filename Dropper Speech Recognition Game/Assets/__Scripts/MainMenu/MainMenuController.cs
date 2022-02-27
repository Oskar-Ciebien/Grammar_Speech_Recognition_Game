using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static void Play()
    {
        // Reset Lives
        PlayerPrefs.SetInt("Lives", PlayerBehaviour.startLives);

        // Reset Score
        PlayerPrefs.SetInt("Score", PlayerBehaviour.startScore);

        // Loads the gamescene and begins the game
        SceneManager.LoadScene("GameScene");

        print("Game Started!");
    }

    public static void Exit()
    {
        // Quits the game
        Application.Quit();

        print("Quit the game!");
    }
}
