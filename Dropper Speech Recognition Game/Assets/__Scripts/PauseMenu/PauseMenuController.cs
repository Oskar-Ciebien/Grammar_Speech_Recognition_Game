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
        pauseMenu = FindIncludingInactive("PauseMenu"); // Disabled by default, so have to go through all objects in game
        gameMusic = GameObject.Find("GameMusic");

        music = gameMusic.GetComponent<AudioSource>();
    }

    public static void PauseGame()
    {
        // Set paused to true - Game Paused
        GameManager.paused = true;

        // Show the PauseMenu
        pauseMenu.SetActive(true);

        // Pause the Game
        Time.timeScale = 0f;
    }

    public static void ResumeGame()
    {
        // Set paused to false - Game UnPaused
        GameManager.paused = false;

        // Disable the PauseMenu
        pauseMenu.SetActive(false);

        // Resume the Game
        Time.timeScale = 1f;
    }

    public static void Mute()
    {
        if (music.mute == false)
        {
            music.mute = true;
        }
    }

    public static void unMute()
    {
        if (music.mute == true)
        {
            music.mute = false;
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
}
