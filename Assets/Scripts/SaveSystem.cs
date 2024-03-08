using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static float PlayerScore;
    public static int PlayerLevel = 1;
    public TMP_Text money;
    public TMP_Text level;
    public static int skill = 10;


    // Update is called once per frame
    void Update()
    {
        money.text = $"{PlayerScore}";
        level.text = $"Level {PlayerLevel}";
    }

    
    
    public static void IncrementScore(float value)
    {
        PlayerScore = PlayerScore + value;
    }

    public static void IncrementLevel(int value)
    {
        PlayerLevel = PlayerLevel + value;
    }

    public static void IncrementSkill(int value)
    {
        if (PlayerScore >= 20)
        {
            skill += value;
            PlayerScore -= 20;
        }
    }
}