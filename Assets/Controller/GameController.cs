using Assets.Service;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Text text;
    private Image tenRolls;
    private Image oneRoll;
    private Image ticket;
    private Color a255 = new Color();
    private Color a0 = new Color();
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


        setColorVariables();

        //Turns on buttons
        tenRolls.color = oneRoll.color = ticket.color = a255;

        //Sets text value
        text.text = "x " + InGameMoney.money.ToString();
    }

    // Rolls 1 gacha
    public void roll1Gacha() {
        setColorVariables();
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = InGameMoney.money;
        int newTicket = oldTicket - 10;
        GameObject characterContainer = GameObject.Find("CharacterContainerSingle");
        if (newTicket < 0)
        {
            GameObject purchaseScreen = GameObject.Find("PurchaseScreen");
            purchaseScreen.GetComponent<Image>().enabled = true;
        }
        else
        {
            InGameMoney.money = newTicket;
            text.text = "x " + InGameMoney.money.ToString();
            cleanScreen();
            GachaLogic Logic = gameObject.AddComponent<GachaLogic>();
            Character character = Logic.GetSingleCharacter();
            characterContainer.transform.GetChild(1).gameObject.GetComponent<Text>().text = character.Nome;
            Sprite characterImage = Resources.Load<Sprite>("Characters/" + character.Arquivo);
            characterContainer.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = characterImage;
            characterContainer.transform.GetChild(0).gameObject.GetComponent<Image>().color = a255;
        }
    }

    // Rolls 10 gacha
    public void roll10Gacha()
    {
        setColorVariables();
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = InGameMoney.money;
        int newTicket = oldTicket - 100;
        if (newTicket < 0)
        {
            GameObject purchaseScreen = GameObject.Find("PurchaseScreen");
            purchaseScreen.GetComponent<Image>().enabled = true;
        }
        else
        {
            InGameMoney.money = newTicket;
            text.text = "x " + InGameMoney.money.ToString();
            GameObject characterContainerGroup = GameObject.Find("CharacterContainerGroup");
            cleanScreen();
            GachaLogic Logic = gameObject.AddComponent<GachaLogic>();
            foreach (Transform child in characterContainerGroup.transform)
            {
                Character character = Logic.GetSingleCharacter();
                child.GetChild(1).gameObject.GetComponent<Text>().text = character.Nome;
                Sprite characterImage = Resources.Load<Sprite>("Characters/" + character.Arquivo);
                child.GetChild(0).gameObject.GetComponent<Image>().sprite = characterImage;
                child.GetChild(0).gameObject.GetComponent<Image>().color = a255;
            }
        }
    }
    public void setColorVariables()
    {
        //Setup button turn on/off bodge
        a255.a = 255;
        a255.r = a255.g = a255.b = 1;
        a0.a = 0;
        a0.r = a0.g = a0.b = 1;
    }
    public void cleanScreen()
    {
        GameObject characterContainerSingle = GameObject.Find("CharacterContainerSingle");
        GameObject characterContainerGroup = GameObject.Find("CharacterContainerGroup");
        characterContainerSingle.transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
        characterContainerSingle.transform.GetChild(0).gameObject.GetComponent<Image>().color = a0;
        foreach(Transform child in characterContainerGroup.transform)
        {
            child.GetChild(1).gameObject.GetComponent<Text>().text = "";
            child.GetChild(0).gameObject.GetComponent<Image>().color = a0;
        }
    }

    public void expendingRealMoney() {
        RealLifeMoney.money -= 20;
        InGameMoney.money += 100;
        GameObject purchaseScreen = GameObject.Find("PurchaseScreen");
        purchaseScreen.GetComponent<Image>().enabled = false;
    }

    public void closeCellphone() {
        SceneManager.LoadScene("Cellphone");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject purchaseScreen = GameObject.Find("PurchaseScreen");
        purchaseScreen.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
