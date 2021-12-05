using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Currency : MonoBehaviour
{
    Text currencyText;
    public static int currency = 0;

    private void Start()
    {
        currencyText = GetComponent<Text>();
    }

    void Update()
    {
        currencyText.text = currency + "€";
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
