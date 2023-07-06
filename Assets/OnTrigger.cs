using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{

    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            Destroy(door);
        }
    }
}
