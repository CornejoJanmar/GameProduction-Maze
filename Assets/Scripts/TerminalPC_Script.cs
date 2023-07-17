using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPC_Script : MonoBehaviour
{
    public int TerminalCounted = 0;
    public void CountTerminalInteracted()
    {
        TerminalCounted++;

        if (TerminalCounted == 6) 
        {
            TurnOffAllTerminals();
        }
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
