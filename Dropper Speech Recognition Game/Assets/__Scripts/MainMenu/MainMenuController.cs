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
    // == Private Fields ==
    private static float r;
    private static float g;
    private static float b;

    private void Start()
    {
        // Set the main menu, options and player prefab menu objects
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = FindIncludingInactive("OptionsMenu"); // Disabled by default, so have to go through all objects in game
        playerPrefab = GameObject.Find("Player");
    }

    public static void Play()
    {
        // If the main menu is active and options menu is not active
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            // Reset Lives
            PlayerPrefs.SetInt("Lives", GameManager.startingLives);

            // Reset Score
            PlayerPrefs.SetInt("Score", GameManager.startingScore);

            // Loads the gamescene and begins the game
            SceneManager.LoadScene("GameScene");

            print("Game Started!");
        }
    }

    public static void Options()
    {
        // If the main menu is active and options menu is not active
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            // Disable Main Menu
            mainMenu.SetActive(false);

            // Enable options menu
            optionsMenu.SetActive(true);

            print("Options Menu!");
        }
    }

    public static void ChangeColour()
    {
        // If the main menu is not active and options menu is active
        if (mainMenu.activeSelf == false && optionsMenu.activeSelf == true)
        {
            // Get random RGB
            r = (Random.Range(50.0f, 150.0f)) / 255;
            g = (Random.Range(50.0f, 150.0f)) / 255;
            b = (Random.Range(50.0f, 150.0f)) / 255;

            // Set them to Player Prefs
            PlayerPrefs.SetFloat("ColourR", r);
            PlayerPrefs.SetFloat("ColourG", g);
            PlayerPrefs.SetFloat("ColourB", b);

            // Set the player colour on the MainMenu Scene
            playerPrefab.GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1.0f);

            // Print out the colour
            // print("Player Colour " + playerPrefab.GetComponent<SpriteRenderer>().color);

            print("Changed Colour!");
        }
    }

    public static void Back()
    {
        // If the main menu is not active and options menu is active
        if (mainMenu.activeSelf == false && optionsMenu.activeSelf == true)
        {
            // Enable Main Menu
            mainMenu.SetActive(true);

            // Disable Options Menu
            optionsMenu.SetActive(false);

            print("Back to Main Menu!");
        }
    }

    public static void Exit()
    {
        // If the main menu is active and options menu is not active
        if (mainMenu.activeSelf == true && optionsMenu.activeSelf == false)
        {
            // Quits the game
            Application.Quit();

            print("Quit the game!");
        }
    }

    // Adapted from https://www.codedojo.com/?p=2155
    // The next two methods go through all the objects in the Main Menu scene and try to find the right game object by the name
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
