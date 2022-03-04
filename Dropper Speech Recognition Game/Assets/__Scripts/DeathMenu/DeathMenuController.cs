using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public static void GoMainMenu()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "DeathScene")
        {
            // Loads the Main Menu
            SceneManager.LoadScene("MainMenu");
        }
    }
}
