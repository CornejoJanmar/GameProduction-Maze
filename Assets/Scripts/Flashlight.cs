using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightLight;
    private bool LightIsOn = false;

    void Start()
    {
        flashlightLight.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<SoundManager>().Play("Switch");
            if (LightIsOn == false)
            {
                flashlightLight.gameObject.SetActive(true);
                LightIsOn = true;
            }
            else
            {
                flashlightLight.gameObject.SetActive(false);
                LightIsOn = false;
            }
        }
    }
}
