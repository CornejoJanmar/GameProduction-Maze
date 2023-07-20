using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLightOff : MonoBehaviour
{
    public GameObject TerminalScreenLight;
    public GameObject SurfaceLight;
    public bool isTerminalOn = true;
    [SerializeField] private GameObject Screen;
    [SerializeField] private Material ScreenColorOn;
    [SerializeField] private Material ScreenColorOff;
    public void TurnOffTerminal()
    {
        TerminalScreenLight.SetActive(false);
        SurfaceLight.SetActive(false);
        Screen.GetComponent<Renderer>().material = ScreenColorOff;
        isTerminalOn = false;
    }

    public bool isTerminalScreenOff()
    {
        if (!isTerminalOn)
        {
            TerminalScreenLight.SetActive(false);
            SurfaceLight.SetActive(false);
        }
        return isTerminalOn;
    }
}
