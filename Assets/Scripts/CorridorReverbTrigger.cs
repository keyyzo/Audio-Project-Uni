using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorReverbTrigger : MonoBehaviour
{

    public GameObject reverbZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            reverbZone.GetComponent<AudioReverbZone>().enabled = true;
        }
    }
}
