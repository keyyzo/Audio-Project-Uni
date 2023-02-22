using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1ButtonTrigger : MonoBehaviour
{
	/// The door we're going to open once we've been triggered.
	public Transform door;
	/// The button we'll depress and turn green once we've been triggered.
	public GameObject button;
	/// The button light we'll turn green once we've been triggered.
	public Light buttonLight;
    /// Array for AudioClips of button clicks
    public AudioClip[] buttonClickClips;
    /// The speed at which the door opens.
    [Range(0.0f, 5.0f)]
	public float doorSpeed = 0.1f;

	///	AudioSource to play the button pressed sound.
	public AudioSource buttonSound;
	///	AudioSource to play the door open sound.
	public AudioSource doorSound;

	/// True if the button's been pressed.
	private bool pressed = false;
	
	// Update is called once per frame
	void Update()
	{
		if(pressed)
		{
			if(button.transform.position.y > 0.12f)
			{
				button.transform.position -= Vector3.up * 0.01f;
			}

			if(door.position.y > -2.8f)
			{
				door.position -= Vector3.up * doorSpeed * Time.deltaTime;
			}
		}
	}

	/// Called when the player triggers us.
	void OnTriggerEnter(Collider other)
	{
		if (!pressed && (other.gameObject.name == "Player"))
		{
			pressed = true;

			Color col = new Color(0.0f, 0.33f, 0.0f);
			button.GetComponent<Renderer>().material.SetColor("_Color", col);
			button.GetComponent<Renderer>().material.SetColor("_EmissionColor", col);

			buttonLight.color = col;
            ButtonsPressedManager.instance.IncreaseButtonsPressed();
            buttonSound.PlayOneShot(buttonClickClips[Random.Range(0, buttonClickClips.Length)]);
			doorSound.Play();
		}
	}
}
