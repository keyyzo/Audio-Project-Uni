using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorOpen : MonoBehaviour
{
    /// Used to move the door.
	public Transform doorTransform;

    /// The speed at which the door opens/closes.
    [Range(0.0f, 10.0f)]
    public float doorSpeed = 0.1f;

    ///	Used to play the door open/close sound.
    public AudioSource doorSound;
    ///	The door open AudioClip.
    public AudioClip doorOpen;

    private bool isOpening;
    private int buttonsNeeded = 6;

    // Start is called before the first frame update
    void Start()
    {
        isOpening = false;
    }

    // Update is called once per frame
    void Update()
    {
        //int checkNum = ButtonsPressedManager.instance.GetNumOfButtonsPressed();

        if (isOpening && (doorTransform.position.y > -4.1f))
        {

            doorTransform.position -= Vector3.up * doorSpeed * Time.deltaTime;


            //isOpening = true;
        }

        //if (isOpening && (doorTransform.position.y <= -4.1f))
        //{
        //    doorSound.PlayOneShot(doorOpen);
        //    isOpening = false;
        //}
    }

    public void OpenDoor()
    {
        isOpening = true;
        doorSound.PlayOneShot(doorOpen);
    }
}
