using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTriggeredCount : MonoBehaviour
{

    private int numberOfButtonsTriggered = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberOfButtonsTriggered);
    }

    public void IncreaseTriggerCount(int num)
    {
        numberOfButtonsTriggered += num;
    }

    public int GetNumOfButtonsTriggered()
    {
        return numberOfButtonsTriggered;
    }

}
