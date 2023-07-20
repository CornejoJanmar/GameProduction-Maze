using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPC_Script : Interactable
{
    public int TerminalCounted = 0;

    private void Start()
    {
        TerminalCounted = 0;
    }
    public void CountTerminalInteracted()
    {
        TerminalCounted++;

        if (TerminalCounted == 6) 
        {
            TurnOffAllTerminals();
            Debug.Log("Exit Unlocked");
        }
    }

    //Using Interactable Script for this one

    public override void OnFocus()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    public override void OnLoseFocus()
    {
        throw new System.NotImplementedException();
    }

    public void TurnOffAllTerminals()
    {
        GameObject[] Terminals = GameObject.FindGameObjectsWithTag("Terminal");
        foreach (GameObject Pc in Terminals)
        {
            Pc.GetComponent<TerminalLightOff>().TurnOffTerminal();
        }
    }
}
