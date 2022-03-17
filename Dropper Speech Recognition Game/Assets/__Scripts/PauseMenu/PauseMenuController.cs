using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject pauseMenu;
    public static GameObject gameMusic;
    public static AudioSource music;

    private void Start()
    {
        // Set the pause menu and game music game objects
        pauseMenu = FindIncludingInactive("PauseMenu"); // Disabled by default, so have to go through all objects in game
        gameMusic = GameObject.Find("GameMusic");

        // Set the music to the AudioSource of GameMusic object
        music = gameMusic.GetComponent<AudioSource>();
    }

    // Pauses the game
    public static void PauseGame()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If pause menu is deactivated
            if (pauseMenu.activeSelf == false)
            {
                // Set paused to true - Game Paused
                GameManager.paused = true;

                // Show the PauseMenu
                pauseMenu.SetActive(true);

                // Pause the Game
                Time.timeScale = 0;
            }
        }
    }

    // Unpauses / Resumes the game
    public static void ResumeGame()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If pause menu is active
            if (pauseMenu.activeSelf == true)
            {
                // Set paused to false - Game UnPaused
                GameManager.paused = false;

                // Disable the PauseMenu
                pauseMenu.SetActive(false);

                // Resume the Game
                Time.timeScale = 1;
            }
        }
    }

    // Mutes the game sounds / music
    public static void Mute()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If pause menu is active
            if (pauseMenu.activeSelf == true)
            {
                // If the music is not muted
                if (music.mute == false)
                {
                    // Mute the music
                    music.mute = true;
                }
            }
        }
    }

    // Unmutes the game sounds / music
    public static void unMute()
    {
        // If on the GameScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            // If pause menu is active
            if (pauseMenu.activeSelf == true)
            {
                // If the music is muted
                if (music.mute == true)
                {
                    // Unmute the music
                    music.mute = false;
                }
            }
        }
    }

    // Adapted from https://www.codedojo.com/?p=2155
    // The next two methods go through all the objects in the Game Menu scene and try to find the right game object by the name
    public static GameObject FindInChildrenIncludingInactive(GameObject go, string objName)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            if (go.transform.GetChild(i).gameObject.name == objName) return go.transform.GetChild(i).gameObject;

            GameObject found = FindInChildrenIncludingInactive(go.transform.GetChild(i).gameObject, objName);

            if (found != null) return found;
        }

        return null;
    }

    public static GameObject FindIncludingInactive(string objName)
    {
        Scene scene = SceneManager.GetActiveScene();
        var game_objects = new List<GameObject>();
        scene.GetRootGameObjects(game_objects);

        foreach (GameObject obj in game_objects)
        {
            if (obj.transform.name == objName) return obj;

            GameObject found = FindInChildrenIncludingInactive(obj, objName);

            if (found) return found;
        }

        return null;
    }
} // Class - END
