using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text healthText;
    public static int health = 50;

    private void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        healthText.text = health + "♡";
    }

    public void removeHealth(int x) 
    {
        health -= x;
    }
}
