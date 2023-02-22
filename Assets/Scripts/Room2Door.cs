﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Door : MonoBehaviour
{
	/// Used to move the door.
	public Transform doorTransform;

	/// The speed at which the door opens/closes.
	[Range(0.0f, 5.0f)]
	public float doorSpeed = 0.1f;

	///	Used to play the door open/close sound.
	public AudioSource doorSound;
	///	The door open AudioClip.
	public AudioClip doorOpen;
	///	The door close AudioClip.
	public AudioClip doorClose;

	/// True if the door should be open.
	private bool open = false;
	
	/// Update is called once per frame
	void Update()
	{
		if(open && (doorTransform.position.y > -3.1f))
		{
			doorTransform.position -= Vector3.up * doorSpeed * Time.deltaTime;
		}
		else if(!open && (doorTransform.position.y < 3.0f))
		{
			doorTransform.position += Vector3.up * doorSpeed * Time.deltaTime;
		}
	}

	/// Tells the door to open.
	public void OpenDoor()
	{
		open = true;

		doorSound.PlayOneShot(doorOpen);
	}

	/// Tells the door to close.
	public void CloseDoor()
	{
		open = false;
		
		doorSound.PlayOneShot(doorClose);
	}
}
