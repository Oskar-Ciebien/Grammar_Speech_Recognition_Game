using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    // Goes back to the main menu
    public static void GoMainMenu()
    {
        // Set current scene
        Scene scene = SceneManager.GetActiveScene();

        // If on DeathScene
        if (scene.name == "DeathScene")
        {
            // Load the Main Menu
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Quits the Game and Editor
    public static void Quit()
    {
        // Set current scene
        Scene scene = SceneManager.GetActiveScene();

        // If on DeathScene
        if (scene.name == "DeathScene")
        {
            // print("Quit the game from Death Scene!"); // Used for testing

            // Quits the game
            Application.Quit();

            // Quits the editor
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
} // Class - END
