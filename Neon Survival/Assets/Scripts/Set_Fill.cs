using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Set_Fill : MonoBehaviour
{
    public Image img;

    void Start()
    {
        
    }

    void Update()
    {
        if (Score_Script.multTimer / Score_Script.timeTillDecrease != 1 && Score_Script.multiplier > 1)
        {
            img.fillAmount = (Score_Script.multTimer / Score_Script.timeTillDecrease);
        }
        else {
            img.fillAmount = 0;
        }
    }
}
