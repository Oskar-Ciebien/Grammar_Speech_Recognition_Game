using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
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
}
