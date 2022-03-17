using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterLivesText : MonoBehaviour
{
    void Start()
    {
        // Calls RegisterLives
        RegisterLives();
    }

    // Registers the lives to the text component
    public void RegisterLives()
    {
        // Display the Lives from GameData on Screen
        GameData.singleton.livesText = this.GetComponent<Text>();
    }
} // Class - END
