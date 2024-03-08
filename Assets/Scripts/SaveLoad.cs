using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    

    // Update is called once
    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerScore", SaveSystem.PlayerScore);
        PlayerPrefs.SetInt("PlayerLevel", SaveSystem.PlayerLevel);
        PlayerPrefs.SetInt("skill",SaveSystem.skill);
        PlayerPrefs.Save(); // Optionally, call Save to write changes immediately
    }
    
    public void Load()
    {
        SaveSystem.PlayerScore = PlayerPrefs.GetFloat("PlayerScore", 0);
        SaveSystem.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
        SaveSystem.skill = PlayerPrefs.GetInt("skill", 10);
    }
}
