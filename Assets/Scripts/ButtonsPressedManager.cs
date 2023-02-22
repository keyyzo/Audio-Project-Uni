using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonsPressedManager : MonoBehaviour
{
    public static ButtonsPressedManager instance;
    public UnityEvent secretDoorUnlocked;
    public Text buttonsPressed;
    int numOfButtonsPressed = 0;
    bool openThedoor = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonsPressed.text = "Buttons Pressed: " + numOfButtonsPressed.ToString() + " out of 6";
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfButtonsPressed == 6 && !openThedoor)
        {
            UnlockDoor();
        }
    }

    public void IncreaseButtonsPressed()
    {
        numOfButtonsPressed += 1;
        buttonsPressed.text = "Buttons Pressed: " + numOfButtonsPressed.ToString() + " out of 6";
    }

    public int GetNumOfButtonsPressed()
    {
        return numOfButtonsPressed;   
    }

    void UnlockDoor()
    {
        secretDoorUnlocked.Invoke();
        openThedoor = true;
    }
}
