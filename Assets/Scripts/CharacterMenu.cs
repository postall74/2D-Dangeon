using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text fields
    public Text levelText;
    public Text hitpointText;
    public Text coinsText;
    public Text upgradedCostText;
    public Text experienceText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform experienceBar;

    //Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            //if we went too far away
            if (currentCharacterSelection == GameManager.Instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            //if we went too far away
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.Instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.Instance.playerSprites[currentCharacterSelection];
        GameManager.Instance.player.SwapSprite(currentCharacterSelection);
    }

    //Weapon upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.Instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //Update the character information
    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.Instance.weaponSprites[GameManager.Instance.weapon.weaponLevel];

        if (GameManager.Instance.weapon.weaponLevel == GameManager.Instance.weaponPrices.Count)
            upgradedCostText.text = "MAX";
        else
            upgradedCostText.text = GameManager.Instance.weaponPrices[GameManager.Instance.weapon.weaponLevel].ToString();

        //Meta
        levelText.text = GameManager.Instance.GetCurrentLevel().ToString();
        hitpointText.text = $" {GameManager.Instance.player.hitPoint.ToString()} / {GameManager.Instance.player.maxHitPoint.ToString()}";
        coinsText.text = GameManager.Instance.coins.ToString();
        int currentLevel = GameManager.Instance.GetCurrentLevel();

        //Experience Bar
        if (currentLevel == GameManager.Instance.experienceTable.Count)
        {
            experienceText.text = $"{GameManager.Instance.experience} / total experience points";
            experienceBar.localScale = Vector3.one;
        }
        else
        {
            int previousLevelExperience = GameManager.Instance.GetExprienceToLevel(currentLevel - 1);
            int currentLevelExperience = GameManager.Instance.GetExprienceToLevel(currentLevel);

            int differenceLevelExperience = currentLevelExperience - previousLevelExperience;
            int currentExperienceIntoLevel = GameManager.Instance.experience - previousLevelExperience;

            float completionRatio = (float)currentExperienceIntoLevel / (float)differenceLevelExperience;
            experienceBar.localScale = new Vector3(completionRatio, 1, 1);
            experienceText.text =$"{currentExperienceIntoLevel} / {differenceLevelExperience}";
        }
        //experienceText.text = "NOT IMPLEMENTED";

    }
}
