using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject Player;

    // == Private Fields ==
    private static float leftBorder = -2f;
    private static float rightBorder = 2f;
    private static float playerPosition;

    void Start()
    {
        // Set player to this Game Object
        Player = this.gameObject;

        // Set position to 0
        playerPosition = 0f;
    }

    void OnCollisionEnter2D()
    {
        
    }

    public static void Move(string direction)
    {
        // If command is to move left
        if (direction == "left")
        {
            // Call MoveLeft method
            MoveLeft();
        }
        // Otherwise if command is to move right
        else if (direction == "right")
        {
            // Call MoveRight method
            MoveRight();
        }
    }

    static void MoveRight()
    {
        // Check if player is at the right border
        if (playerPosition < rightBorder)
        {
            // Move player to the right
            Player.transform.Translate(new Vector2(0, -2));

            // Change player position
            playerPosition += 2f;

            Debug.Log("Player moved right."); // Used for testing
        }
        else // If player is at the border
        {
            Debug.Log("Player has reached the right border");
        }
    }

    static void MoveLeft()
    {
        // Check if player is at the left border
        if (playerPosition > leftBorder)
        {
            // Move player to the left
            Player.transform.Translate(new Vector2(0, 2));

            // Change player position
            playerPosition -= 2f;

            Debug.Log("Player moved left."); // Used for testing
        }
        else // If player is at the border
        {
            Debug.Log("Player has reached the left border");
        }
    }
}
