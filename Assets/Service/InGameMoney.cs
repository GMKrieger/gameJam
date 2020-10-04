using UnityEngine;

public class InGameMoney{
    static public int money = 100;
    static public Color color = new Color(0.5f, 0.9f, 0.2f, 1f);

    public void dailyIncome(){
        money += 20;
    }

    public void expenses() {
        // Food/Normal expenses
        money -= 5;

        // Bought something cheap
        int percentage = Random.Range(1, 101);
        if(percentage <= 50) {
            money -= 3;        
        }

        // Bought something medium
        percentage = Random.Range(1, 101);
        if (percentage <= 30)
        {
            money -= 5;
        }

        // Ate out
        percentage = Random.Range(1, 101);
        if (percentage <= 20)
        {
            money -= 5;
        }

        // Something broke
        percentage = Random.Range(1, 101);
        if (percentage <= 5)
        {
            money -= 10;
        }
    }
}
