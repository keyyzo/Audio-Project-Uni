using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRoomAmbienceTrigger : MonoBehaviour
{
    public GameObject boxRoomAmbience;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            boxRoomAmbience.GetComponent<AudioSource>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            boxRoomAmbience.GetComponent<AudioSource>().enabled = false;
        }
    }


}
