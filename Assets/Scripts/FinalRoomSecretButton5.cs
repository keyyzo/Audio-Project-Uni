using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomSecretButton5 : MonoBehaviour
{
    /// The button we'll depress and turn green once we've been triggered.
    public GameObject button;
    /// The button light we'll turn green once we've been triggered.
    public Light buttonLight;

    ///	AudioSource to play the button pressed sound.
    public AudioSource buttonSound;
    /// Array for AudioClips of button clicks
    public AudioClip[] buttonClickClips;
    /// True if the button's been pressed.
    private bool pressed = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            if (button.transform.position.x < -127.550f)
            {
                button.transform.position += Vector3.right * 0.01f;
            }

        }
    }

    /// Called when the player triggers us.
    void OnTriggerEnter(Collider other)
    {
        if (!pressed && ((other.gameObject.name == "Player") || (other.gameObject.tag == "Harpoon")))
        {
            pressed = true;

            Color col = new Color(0.0f, 0.33f, 0.0f);
            button.GetComponent<Renderer>().material.SetColor("_Color", col);
            button.GetComponent<Renderer>().material.SetColor("_EmissionColor", col);

            buttonLight.color = col;


            buttonSound.PlayOneShot(buttonClickClips[Random.Range(0, buttonClickClips.Length)]);
            ButtonsPressedManager.instance.IncreaseButtonsPressed();
        }
    }
}
