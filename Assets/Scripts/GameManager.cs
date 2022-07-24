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
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    // Logic
    public int coins;
    public int experience;

    //Floating Text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    //Upgrade weapon
    public bool TryUpgradeWeapon()
    {
        //is a weapon max level?
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if (coins >= weaponPrices[weapon.weaponLevel])
        {
            coins -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    //Experience System
    public int GetCurrentLevel()
    {
        int returnValue = 0;
        int add = 0;

        while(experience >= add)
        {
            add += experienceTable[returnValue];
            returnValue++;

            //Max level
            if (returnValue == experienceTable.Count)
                return returnValue;
        }

        return returnValue;
    }

    public int GetExprienceToLevel(int level)
    {
        int returnValue = 0;
        int experience = 0;

        while (returnValue < level)
        {
            experience += experienceTable[returnValue];
            returnValue++;
        }

        return experience;
    }

    public void GrantExperience(int exp)
    {
        int currentLevel = GetCurrentLevel();
        experience += exp;

        if (currentLevel<GetCurrentLevel())
            OnLevelUp();
    }

    public void OnLevelUp()
    {
        Debug.Log("Level up!");
        player.OnLevelUp();
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
        data += weapon.weaponLevel.ToString();

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

        //Change player skin
        coins = int.Parse(data[1]);

        //Experience
        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());

        //Chage the weapon level
        weapon.SetLevelWeapon(int.Parse(data[3]));
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
