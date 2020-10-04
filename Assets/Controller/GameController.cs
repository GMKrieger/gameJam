using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text text;
    private Image tenRolls;
    private Image oneRoll;

    public void startGacha() {

        GameObject textGO = GameObject.Find("TicketNumber");
        GameObject tenRollsGO = GameObject.Find("10rolls");
        GameObject oneRollGO = GameObject.Find("1roll");
        text = textGO.GetComponent<Text>();
        tenRolls = tenRollsGO.GetComponent<Image>();
        oneRoll = oneRollGO.GetComponent<Image>();

        //Turns on buttons
        Color c = tenRolls.color;
        c.a = 255;
        tenRolls.color = c;
        oneRoll.color = c;

        text.text = "100";
    }


    public void roll1Gacha() {
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = Int16.Parse(text.text);
        oldTicket = oldTicket - 1;
        text.text = oldTicket.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
