using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // == Public Fields ==
    public GameObject Player;

    // == Private Fields ==
    private float leftBorder = -2f;
    private float rightBorder = 2f;
    private float playerPositon;

    void Start()
    {

    }

    private void Update()
    {
        // Update player position
        playerPositon = Player.transform.position.x;
        Debug.Log("Player Position: " + playerPositon); // Used for testing
    }

    void OnCollisionEnter2D()
    {

    }

    void Move(string direction)
    {
        // If command is to move left
        if (direction == "left")
        {
            // Check if player is at the left border
            if (playerPositon > leftBorder)
            {
                // Move player to the left
                transform.Translate(new Vector2(-2, 0));
                Debug.Log("Player moved left."); // Used for testing
            }
        }
        // Otherwise if command is to move right
        else if (direction == "right")
        {
            // Check if player is at the right border
            if (playerPositon < rightBorder)
            {
                // Move player to the right
                transform.Translate(new Vector2(2, 0));
                Debug.Log("Player moved right."); // Used for testing
            }
        }
    }
}
