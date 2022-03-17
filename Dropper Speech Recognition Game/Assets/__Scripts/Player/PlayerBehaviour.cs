using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject Player;

    // == Private Fields ==
    private static float leftBorder = -2f;
    private static float rightBorder = 2f;
    private static float playerPosition;
    private int lives;
    private float reloadTime = 1.0f;
    private string playerColourStr;
    private float r;
    private float g;
    private float b;

    void Start()
    {
        // Set player to this Game Object
        Player = this.gameObject;

        // Set position to 0
        playerPosition = 0f;

        // Get Lives Left from the PlayerPrefs
        lives = PlayerPrefs.GetInt("Lives");

        // Get RGB Colours from Player Prefs
        r = PlayerPrefs.GetFloat("ColourR");
        g = PlayerPrefs.GetFloat("ColourG");
        b = PlayerPrefs.GetFloat("ColourB");

        // Set the colour to the prefab
        Player.GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1f);
    }

    // Resets the player statistics and other needed variables for a new game
    void ResetPlayer()
    {
        // Set the lives left to the default amount
        PlayerPrefs.SetInt("Score", GameManager.startingScore);

        // Set the lives left to the default amount
        PlayerPrefs.SetInt("Lives", GameManager.startingLives);

        // Reset spawn time
        GameManager.resetSpawnTime = GameManager.startingSpawnTime;
    }

    // Moves player to the right
    public static void MoveRight()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If game is not paused
            if (GameManager.paused == false)
            {
                // Check if player is at the right border
                if (playerPosition < rightBorder)
                {
                    // Move player to the right
                    Player.transform.Translate(new Vector2(2, 0));

                    // Change player position
                    playerPosition += 2f;

                    // print("Player moved right."); // Used for testing
                }
                else // If player is at the border
                {
                    // print("Player has reached the right border"); // Used for testing
                }
            }
        }
    }

    // Moves player to the left
    public static void MoveLeft()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If Game is not paused
            if (GameManager.paused == false)
            {
                // Check if player is at the left border
                if (playerPosition > leftBorder)
                {
                    // Move player to the left
                    Player.transform.Translate(new Vector2(-2, 0));

                    // Change player position
                    playerPosition -= 2f;

                    // print("Player moved left."); // Used for testing
                }
                else // If player is at the border
                {
                    // print("Player has reached the left border"); // Used for testing
                }
            }
        }
    }

    // On Collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        // print("Collision! " + other); // Used for testing

        // If player collided with the obstacle
        if (other.gameObject.tag == "Obstacle")
        {
            // Take one life
            lives--;

            // Set the new lives
            PlayerPrefs.SetInt("Lives", lives);

            // print("Lives: " + lives); // Used for testing

            // If no more lives left
            if (lives <= 0)
                // Show death scene after reload time
                Invoke("DeathScene", reloadTime);
            else // Otherwise
            {
                // print("Player Died"); // Used for testing

                // Call a method to restart the scene
                Invoke("RestartScene", reloadTime);
            }
        }
    }

    // Restart the Game Scene
    public void RestartScene()
    {
        // Load the Game Scene
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Show the DeathScene - Player Died
    public void DeathScene()
    {
        // Load the Death Scene
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
    }
} // Class - END
