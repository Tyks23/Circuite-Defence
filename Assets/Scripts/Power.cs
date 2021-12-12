using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Power : MonoBehaviour
{
    // Start is called before the first frame update
    Text PowerText;
    public static int PowerUsage = 0;
    public static int PowerCap = 20;

    private void Start()
    {
        PowerText = GetComponent<Text>();
    }

    void Update()
    {
        PowerText.text = PowerUsage + "/" + PowerCap;
    }
    public void addPowerusage(int x)
    {
        PowerUsage += x;
    }

    public void removePowerusage(int x)
    {
        PowerUsage -= x;
    }
    public void addPowercap(int x)
    {
        PowerCap += x;
    }

    public void removePowercap(int x)
    {
        PowerCap -= x;
    }
}
