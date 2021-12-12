using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Computing : MonoBehaviour
{
    // Start is called before the first frame update
    Text CEText;
    public static int CEusage = 0;
    public static int CEcap = 20;

    private void Start()
    {
        CEText = GetComponent<Text>();
    }

    void Update()
    {
        CEText.text = CEusage + "/" + CEcap;
    }
    public void addCEusage(int x)
    {
        CEusage += x;
    }

    public void removeCEusage(int x)
    {
        CEusage -= x;
    }
    public void addCEcap(int x)
    {
        CEcap += x;
    }

    public void removeCEcap(int x)
    {
        CEcap -= x;
    }
}
