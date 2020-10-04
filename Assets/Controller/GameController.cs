using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text text;
    private Image tenRolls;
    private Image oneRoll;
    private Image ticket;

    // Called when animation ends, loads gacha interface
    public void startGacha() {

        //Instances objects
        GameObject textGO = GameObject.Find("TicketNumber");
        GameObject tenRollsGO = GameObject.Find("10rolls");
        GameObject oneRollGO = GameObject.Find("1roll");
        GameObject ticketGO = GameObject.Find("TicketNumberImage");

        text = textGO.GetComponent<Text>();
        tenRolls = tenRollsGO.GetComponent<Image>();
        oneRoll = oneRollGO.GetComponent<Image>();
        ticket = ticketGO.GetComponent<Image>();

        //Turns on buttons
        Color c = tenRolls.color;
        c.a = 255;
        tenRolls.color = c;
        oneRoll.color = c;
        ticket.color = c;

        //Sets text value
        text.text = "x 100";
    }

    // Rolls 1 gacha
    public void roll1Gacha() {
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = Int16.Parse(text.text.Remove(0, 1));
        int newTicket = oldTicket - 10;
        if (newTicket < 0)
        {

        }
        else
        {
            text.text = "x " + newTicket.ToString();
        }
    }

    // Rolls 10 gacha
    public void roll10Gacha()
    {
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = Int16.Parse(text.text.Remove(0, 1));
        int newTicket = oldTicket - 100;
        if (newTicket < 0)
        {

        }
        else
        {
            text.text = "x " + newTicket.ToString();
        }
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
