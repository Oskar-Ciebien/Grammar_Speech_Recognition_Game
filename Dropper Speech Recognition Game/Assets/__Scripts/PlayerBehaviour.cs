using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject Player;
    public static Vector2 playerPosition;

    // == Private Fields ==
    private static float leftBorder = -2f;
    private static float rightBorder = 2f;
    private static float position;

    void Start()
    {
        Player = this.gameObject;

        playerPosition = transform.position;
        position = 0f;
    }

    void OnCollisionEnter2D()
    {

    }

    public static void Move(string direction)
    {
        // If command is to move left
        if (direction == "left")
        {
            MoveLeft();
        }
        // Otherwise if command is to move right
        else if (direction == "right")
        {
            MoveRight();
        }
    }

    static void MoveRight()
    {
        // Check if player is at the right border
        if (position < rightBorder)
        {
            // Move player to the right
            Player.transform.Translate(new Vector2(2, 0));

            position += 2f;

            Debug.Log("Player moved right."); // Used for testing
        }
        else
        {
            Debug.Log("Player has reached the right border");
        }
    }

    static void MoveLeft()
    {
        // Check if player is at the left border
        if (position > leftBorder)
        {
            // Move player to the left
            Player.transform.Translate(new Vector2(-2, 0));

            position -= 2f;

            Debug.Log("Player moved left."); // Used for testing
        }
        else
        {
            Debug.Log("Player has reached the left border");
        }
    }
}
