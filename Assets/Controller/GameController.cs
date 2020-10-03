using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
