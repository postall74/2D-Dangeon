using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Ressource
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> experienceTable;

    // References
    public Player player;

    public FloatingTextManager floatingTextManager;

    // Logic
    public int coins;
    public int experience;

    //Floating Text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    /// <summary>
    /// int preferdSkin
    /// int coins
    /// int experience
    /// int weaponLevel
    /// </summary>
    public void SaveState()
    {

        string data = "";

        data += "0" + "|";
        data += coins.ToString() + "|";
        data += experience.ToString() + "|";
        data += "0";

        PlayerPrefs.SetString("SaveState", data);
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("SaveState");
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change palyer skin
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change weapon level
    }

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

}
