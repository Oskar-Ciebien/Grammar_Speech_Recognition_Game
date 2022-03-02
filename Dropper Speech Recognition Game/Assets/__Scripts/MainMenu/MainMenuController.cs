using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // == Public Fields ==
    public static GameObject mainMenu;
    public static GameObject optionsMenu;
    public static GameObject playerPrefab;

    private void Start()
    {
        // Set the main menu and options menu objects
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = FindIncludingInactive("OptionsMenu"); // Disabled by default, so have to go through all objects in game
        playerPrefab = GameObject.Find("Player");
    }

    public static void Play()
    {
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            // Reset Lives
            PlayerPrefs.SetInt("Lives", PlayerBehaviour.startLives);

            // Reset Score
            PlayerPrefs.SetInt("Score", PlayerBehaviour.startScore);

            // Loads the gamescene and begins the game
            SceneManager.LoadScene("GameScene");

            print("Game Started!");
        }
    }

    public static void Options()
    {
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);

            print("Options Menu!");
        }
    }

    public static void ChangeColour()
    {
        if (mainMenu.activeSelf == false && optionsMenu.activeSelf == true)
        {
            playerPrefab.GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            //PlayerPrefs.SetString("myColor", playerPrefab.GetComponent<SpriteRenderer>().material.color);

            print("Changed Colour!");
        }
    }

    public static void Back()
    {
        if (mainMenu.activeSelf == false && optionsMenu.activeSelf == true)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);

            print("Back to Main Menu!");
        }
    }

    public static void Exit()
    {
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            // Quits the game
            Application.Quit();

            print("Quit the game!");
        }
    }

    // Adapted from https://www.codedojo.com/?p=2155
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
