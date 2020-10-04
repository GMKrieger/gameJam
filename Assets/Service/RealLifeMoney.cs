using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealLifeMoney
{
    static public int money = 1000;

    public void gachaPurchase(){
        money -= 20;
    }

    public void income(){
        money += 20;
    }
}
