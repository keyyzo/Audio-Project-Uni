using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor1ReverbTrigger : MonoBehaviour
{
    public GameObject corridorReverb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            corridorReverb.GetComponent<AudioReverbZone>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            corridorReverb.GetComponent<AudioReverbZone>().enabled = false;
        }
    }
}
