using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image image;
    public static float health;
    private float maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = health / maxHealth;
    }

    public static void TakeDamage(float damage)
    {
        health -= damage;
    }
}
