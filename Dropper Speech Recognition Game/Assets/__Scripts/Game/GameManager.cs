using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // == Public Fields ==
    public static float startingLives = 3;
    public static float startingScore = 0;

    public static void Listen(string value)
    {
        // If command is to move left
        if (value == "left")
        {
            // Call MoveLeft method
            PlayerBehaviour.MoveLeft();
        }
        // Otherwise if command is to move right
        else if (value == "right")
        {
            // Call MoveRight method
            PlayerBehaviour.MoveRight();
        }
        // Otherwise if command is to start the game
        else if (value == "start")
        {
            // Call the play method in main menu
            MainMenuController.Play();
        }
        // Otherwise if command is to quit the game
        else if (value == "quit")
        {
            // Call the play method in main menu
            MainMenuController.Exit();
        }
    }
}
