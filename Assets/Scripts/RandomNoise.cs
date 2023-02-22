using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoise : MonoBehaviour
{
    /// Array for AudioClips of random noises
    public AudioClip[] randomNoiseClips;
    ///	AudioSource to play the random noises.
   // public AudioSource randomNoiseSource;
    ///  trigger for random noise.
    public GameObject randomNoiseTrigger;

    private float randomTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (randomTimer < 0.0f)
        {
            transform.position = new Vector3(Random.Range(-77.0f,-87.0f),Random.Range(1.0f,6.0f),Random.Range(-6.0f,116.0f));

            PlayRandomNoiseClip();
            randomTimer = Random.Range(0.2f, 2.0f);
        }

        randomTimer -= 1.0f * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            randomNoiseTrigger.GetComponent<AudioSource>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            randomNoiseTrigger.GetComponent<AudioSource>().enabled = false;
        }
    }

    void PlayRandomNoiseClip()
    {
        randomNoiseTrigger.GetComponent<AudioSource>().PlayOneShot(randomNoiseClips[Random.Range(0, randomNoiseClips.Length)]);
    }
}
