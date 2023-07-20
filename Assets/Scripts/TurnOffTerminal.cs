using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTerminal : MonoBehaviour
{
    TerminalPC_Script Terminal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terminal")&& other.gameObject.GetComponent<TerminalLightOff>().isTerminalOn)
        {
            this.gameObject.GetComponent<TerminalPC_Script>().CountTerminalInteracted();
            other.GetComponent<TerminalLightOff>().TurnOffTerminal();
            FindObjectOfType<SoundManager>().Play("ButtonPress");
        }
    }
}
