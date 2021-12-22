using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text currencyText;
    public static int currency = 50;

    private void Start()
    {
        currencyText = GetComponent<Text>();
    }

    void Update()
    {
        currencyText.text = currency + "€";
    }
    public int getCurrency()
    {
        return currency;
    }
    public void addCurrency(int x)
    {
        currency += x;
    }

    public void removeCurrency(int x)
    {
        currency -= x;
    }
}
