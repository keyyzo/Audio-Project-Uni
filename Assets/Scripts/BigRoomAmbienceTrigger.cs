using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRoomAmbienceTrigger : MonoBehaviour
{
    public GameObject bigRoomAmbience;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            bigRoomAmbience.GetComponent<AudioSource>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            bigRoomAmbience.GetComponent<AudioSource>().enabled = false;
        }
    }
}
