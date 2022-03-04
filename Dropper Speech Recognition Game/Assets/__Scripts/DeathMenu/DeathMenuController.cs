using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public void GoMainMenu()
    {
        // Loads the Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
