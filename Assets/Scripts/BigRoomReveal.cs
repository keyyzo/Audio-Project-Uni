using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRoomReveal : MonoBehaviour
{
	/// The transform for the objects we'll lower once we've been triggered.
	public Transform revealTransform;
	/// The button we'll depress and turn green once we've been triggered.
	public GameObject button;
	/// The button light we'll turn green once we've been triggered.
	public Light buttonLight;

	/// The speed at which the objects lower.
	[Range(0.0f, 1.0f)]
	public float revealSpeed = 0.1f;

	///	AudioSource for the button sound.
	public AudioSource buttonSound;
	///	AudioSource for the reveal.
	public AudioSource revealSound;

	/// True if the button's been pressed.
	private bool pressed = false;
	
	// Update is called once per frame
	void Update()
	{
		if(pressed)
		{
			if(button.transform.position.y > (0.12f/8.0f))
			{
				button.transform.position -= Vector3.up * (0.01f/8.0f);
			}

			if(revealTransform.position.y > -16.1f)
			{
				revealTransform.position -= Vector3.up * revealSpeed;
			}
		}
	}

	/// Called when the player triggers us.
	void OnTriggerEnter(Collider other)
	{
		if(!pressed && (other.gameObject.name == "Player"))
		{
			pressed = true;

			Color col = new Color(0.0f, 0.33f, 0.0f);
			button.GetComponent<Renderer>().material.SetColor("_Color", col);
			button.GetComponent<Renderer>().material.SetColor("_EmissionColor", col);

			buttonLight.color = col;

			buttonSound.Play();
			revealSound.Play();
		}
	}
}
