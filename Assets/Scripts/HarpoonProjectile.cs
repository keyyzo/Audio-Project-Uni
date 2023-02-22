﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Class governing the motion of the harpoon projectile.
public class HarpoonProjectile : MonoBehaviour
{
	/// The GunController that fired this projectile.
	public GunController controller;
	/// The BoxPicker script we'll use to let the Player carry any received boxes.
	public BoxPicker boxPicker;

	/// Transform of the object we use to anchor the rope.
	public Transform anchorTransform;

	///	AudioSource to play the harpoon travel sound.
	public AudioSource harpoonTravelSound;
	///	AudioSource to play any harpoon one shot sounds.
	public AudioSource harpoonOneShotSound;
	///	Harpoon collide-cube sound.
	public AudioClip collideCubeSound;
	///	Harpoon collide-other sound.
	public AudioClip collideOtherSound;

	/// True if the harpoon is firing away from the gun; false if it's returning to the gun.
	private bool firing = true;
	///	The speed to move the harpoon at.
	private float speed = 1.0f;

	///	True if we've triggered the return sound.
	private bool triggeredReturnSound = false;

	///	The direction to fire the harpoon in.
	private Vector3 direction;

	/// The key cube we're grabbing if we've grabbed one.
	private GameObject keyCube;
	/// The key cube's original parent transform.
	private Transform originalCubeParent;

	/// Used to set our direction.
	void Start()
	{
		direction = transform.forward;

		harpoonTravelSound.Play();
	}
	
	/// Update is called once per frame
	void Update()
	{
		if(firing)
		{
			//If we're too far from the player, return.
			if(Vector3.Distance(controller.gameObject.transform.position, transform.position) > 75.0f)
			{
				firing = false;

				if(!triggeredReturnSound)
				{
					//Trigger harpoon return sound/event?

					triggeredReturnSound = true;
				}
			}

			//Move the projectile forward.
			transform.localPosition += direction * -speed;
		}
		else
		{
			if(Vector3.Distance(anchorTransform.position, transform.position) < speed)
			{
				//We've returned to the gun.
				controller.ProjectileReturned();

				harpoonTravelSound.Stop();

				//Update the cube if we have one.
				if(keyCube != null)
				{
					keyCube.transform.parent = originalCubeParent;
					boxPicker.PickupBox(keyCube.GetComponent<Rigidbody>());

					controller.droppingBox = true;
				}
			}
			else
			{
				//We need to move towards the gun.
				Vector3 dir = (anchorTransform.position - transform.position).normalized;

				transform.localPosition += dir * speed;
			}
		}

		//Rotate so we're always pointing away from the gun.
		transform.LookAt(transform.position);
	}

	/// Used to grab key cubes or return to the gun if we've collided with a wall.
	void OnTriggerEnter(Collider other)
	{
		if(!other.isTrigger)
		{
			if(firing)
			{
				if(other.name == "Key Cube")
				{
					//Grab cube.
					keyCube = other.gameObject;

					originalCubeParent = keyCube.transform.parent;
					keyCube.transform.parent = transform;

					harpoonOneShotSound.PlayOneShot(collideCubeSound);
				}
				else
				{
					harpoonOneShotSound.PlayOneShot(collideOtherSound);
				}

				firing = false;

				//Trigger harpoon return sound?
			}
		}
	}

	/// Called from GunController to return the harpoon when the player releases the mouse button.
	public void ReturnProjectile()
	{
		firing = false;

		if(!triggeredReturnSound)
		{
			//Trigger harpoon return sound?

			triggeredReturnSound = true;
		}
	}
}
