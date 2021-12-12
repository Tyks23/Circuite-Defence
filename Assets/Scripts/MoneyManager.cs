using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    private int currentPlayerMoney;

    [SerializeField] public int starterMoney;


    public void Start()
    {
        currentPlayerMoney = starterMoney;
        GetCurrentMoney();
    }


    public int GetCurrentMoney(){
        return currentPlayerMoney;
    }

    public void AddMoney(int amount){
        currentPlayerMoney += amount;
        Debug.Log("Added " + amount + "to resourcepool");
    }

    public void RemoveMoney(int amount){
        currentPlayerMoney -= amount;
        Debug.Log("Removed " + amount + "from resourcepool");
    }
}
