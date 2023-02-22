using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonsPressed : MonoBehaviour
{
    //public ButtonsTriggeredCount countedButtons;
    public Text uiText;
    //int buttonsTriggered = 0;
    //GameObject countedButtons;
    public GameObject btc;
    private int currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        // countedButtons = GameObject.FindGameObjectWithTag("ButtonsPressed");
        //countedButtons = GameObject.FindGameObjectWithTag("ButtonsPressed");
        //btc = countedButtons.GetComponent<ButtonsTriggeredCount>();

        //btc = FindObjectOfType<ButtonsTriggeredCount>();
        //uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //buttonsTriggered = countedButtons.GetComponent<ButtonsTriggeredCount>().GetNumOfButtonsTriggered();
        //uiText.text = "Buttons Pressed: " + btc.GetNumOfButtonsTriggered().ToString();
        //int tempNum = btc.GetNumOfButtonsTriggered();
        //uiText.text = "Buttons Pressed: " + currentScore.ToString();
        //currentScore += num;
        uiText.text = "Buttons Pressed: " + btc.GetComponent<ButtonsTriggeredCount>().GetNumOfButtonsTriggered();
    }

    public void UpdateButtonsPressed(int num)
    {
        currentScore += num;
        uiText.text = "Buttons Pressed: " + btc.GetComponent<ButtonsTriggeredCount>().GetNumOfButtonsTriggered();
    }
}
