using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Ressource
    public List<Sprite> _playerSprites;
    public List<Sprite> _weaponSprites;
    public List<int> _weaponPrices;
    public List<int> _experienceTable;

    // References
    public Player _player;

    // Logic
    public int _coins;
    public int _experience;

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
    
    /*
     * int preferdSkin
     * int coins
     * int experience
     * int weaponLevel
     */
    public void SaveState()
    {
       
        string data = "";

        data += "0" + "|";
        data += _coins.ToString() + "|";
        data += _experience.ToString() + "|";
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
        _coins = int.Parse(data[1]);
        _experience = int.Parse(data[2]);
        //Change weapon level
    }




}
