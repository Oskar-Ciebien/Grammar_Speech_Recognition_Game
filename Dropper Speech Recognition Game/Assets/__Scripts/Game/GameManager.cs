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
        // Otherwise if command is to change the colour of the player
        else if (value == "color")
        {
            // Call the play method in main menu
            MainMenuController.ChangeColour();
        }
        // Otherwise if command is to go to the options menu
        else if (value == "options")
        {
            // Call the play method in main menu
            MainMenuController.Options();
        }
        // Otherwise if command is to move back out of options menu
        else if (value == "back")
        {
            // Call the play method in main menu
            MainMenuController.Back();
        }
    }
}
