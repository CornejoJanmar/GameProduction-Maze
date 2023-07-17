using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLightOff : MonoBehaviour
{
    public GameObject TerminalScreenLight;
    public GameObject SurfaceLight;
    public bool isTerminalOn = true;
    public void TurnOffTerminal()
    {
        TerminalScreenLight.SetActive(false);
        SurfaceLight.SetActive(false);
        isTerminalOn = false;
    }

    public void CheckTerminalScreen()
    {
        if (!isTerminalOn)
        {
            TerminalScreenLight.SetActive(false);
            SurfaceLight.SetActive(false);
        }
    }
}
