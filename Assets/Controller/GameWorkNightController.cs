using Assets.Service;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWorkNightController : MonoBehaviour
{
    private Text text;
    private Image tenRolls;
    private Image oneRoll;
    private Image ticket;
    private Color a255 = new Color();
    private Color a0 = new Color();
    private Stack<Character> listaPersonagens = new Stack<Character>();
    private bool brasilChan = false;
    // Called when animation ends, loads gacha interface
    public void startGacha()
    {

        //Instances objects
        GameObject textGO = GameObject.Find("TicketNumber");
        GameObject tenRollsGO = GameObject.Find("10rolls");
        GameObject oneRollGO = GameObject.Find("1roll");
        GameObject ticketGO = GameObject.Find("TicketNumberImage");
        GameObject panel = GameObject.Find("Panel");
        panel.gameObject.SetActive(false);

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
    public void roll1Gacha()
    {
        setColorVariables();
        GameObject textGO = GameObject.Find("TicketNumber");
        text = textGO.GetComponent<Text>();
        int oldTicket = InGameMoney.money;
        int newTicket = oldTicket - 10;
        GameObject characterContainer = GameObject.Find("CharacterContainerSingle");
        if (newTicket < 0)
        {
            GameObject.Find("Canvas").transform.Find("PurchaseScreen").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PurchaseClose").gameObject.SetActive(true);
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
            characterContainer.transform.GetChild(0).gameObject.GetComponent<Image>().preserveAspect = true;
            characterContainer.transform.GetChild(0).gameObject.GetComponent<Image>().color = a255;
            handleUI(false);
            GameObject.Find("GachaUI").transform.Find("Return").gameObject.SetActive(true);
            if (character.Raridade == "5")
            {
                brasilChan = true;
            }
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
            GameObject.Find("Canvas").transform.Find("PurchaseScreen").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PurchaseClose").gameObject.SetActive(true);
        }
        else
        {
            InGameMoney.money = newTicket;
            text.text = "x " + InGameMoney.money.ToString();
            GameObject characterContainerGroup = GameObject.Find("CharacterContainerGroup");
            cleanScreen();
            GachaLogic Logic = gameObject.AddComponent<GachaLogic>();
            listaPersonagens = Logic.GetMultipleCharacters(10);
            foreach (Transform child in characterContainerGroup.transform)
            {
                Character currentCharacter = listaPersonagens.Pop();
                child.GetChild(1).gameObject.GetComponent<Text>().text = currentCharacter.Nome;
                Sprite characterImage = Resources.Load<Sprite>("Characters/" + currentCharacter.Arquivo);
                child.GetChild(0).gameObject.GetComponent<Image>().sprite = characterImage;
                child.GetChild(0).gameObject.GetComponent<Image>().preserveAspect = true;
                child.GetChild(0).gameObject.GetComponent<Image>().color = a255;
                if (currentCharacter.Raridade == "5")
                {
                    brasilChan = true;
                }
            }
            handleUI(false);
            GameObject.Find("GachaUI").transform.Find("Next").gameObject.SetActive(true);
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
        foreach (Transform child in characterContainerGroup.transform)
        {
            child.GetChild(1).gameObject.GetComponent<Text>().text = "";
            child.GetChild(0).gameObject.GetComponent<Image>().color = a0;
        }
    }

    public void expendingRealMoney()
    {
        if (RealLifeMoney.money - 20 < 0)
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject noMoney = canvas.transform.Find("NoMoney").gameObject;
            noMoney.gameObject.SetActive(true);
            Animator anim = noMoney.gameObject.GetComponent<Animator>();
            anim.SetBool("OutOfMoney", true);
            RealLifeMoney.failCount += 1;

        }
        else
        {
            RealLifeMoney.money -= 20;
            InGameMoney.money += 100;
            text.text = "x " + InGameMoney.money.ToString();
            GameObject.Find("Canvas").transform.Find("PurchaseScreen").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PurchaseClose").gameObject.SetActive(false);
        }
    }

    public void changeScene()
    {
        if (RealLifeMoney.failCount >= 6)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if (RealLifeMoney.successCount >= 6)
        {
            SceneManager.LoadScene("GoodEnding");
        }
        else {
            SceneManager.LoadScene("CellphoneSubway");
        }
    }

    public void closeCellphone()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject panel = canvas.transform.Find("Panel").gameObject;
        panel.gameObject.SetActive(true);
        Animator anim = panel.gameObject.GetComponent<Animator>();
        anim.SetBool("FadeOutBool", true);
    }

    public void loadMoreGachaCharacters()
    {
        if (brasilChan)
        {
            SceneManager.LoadScene("ChanEnding");
        }
        else
        {
            checkCharacterList();
            GameObject characterContainerGroup = GameObject.Find("CharacterContainerGroup");
            cleanScreen();
            foreach (Transform child in characterContainerGroup.transform)
            {
                Character currentCharacter = listaPersonagens.Pop();
                child.GetChild(1).gameObject.GetComponent<Text>().text = currentCharacter.Nome;
                Sprite characterImage = Resources.Load<Sprite>("Characters/" + currentCharacter.Arquivo);
                child.GetChild(0).gameObject.GetComponent<Image>().sprite = characterImage;
                child.GetChild(0).gameObject.GetComponent<Image>().color = a255;
                checkCharacterList();
            }
        }
    }

    private void checkCharacterList()
    {
        if (listaPersonagens.Count == 0)
        {
            GameObject gachaUI = GameObject.Find("GachaUI");
            gachaUI.transform.Find("Next").gameObject.SetActive(false);
            gachaUI.transform.Find("Return").gameObject.SetActive(true);
            return;
        }
    }
    public void handleUI(bool visibility)
    {
        GameObject UI = GameObject.Find("UI");
        for (int i = 0; i < UI.transform.childCount; i++)
        {
            GameObject child = UI.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(visibility);
        }
    }

    public void handleGachaUI(bool visibility)
    {
        GameObject gachaUI = GameObject.Find("GachaUI");
        for (int i = 0; i < gachaUI.transform.childCount; i++)
        {
            GameObject child = gachaUI.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(visibility);
        }
    }

    public void resetScreen()
    {
        if (brasilChan)
        {
            SceneManager.LoadScene("ChanEnding");
        }
        else
        {
            cleanScreen();
            handleUI(true);
            handleGachaUI(false);
        }
    }

    public void closePurchase()
    {
        GameObject.Find("Canvas").transform.Find("PurchaseScreen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("PurchaseClose").gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        handleGachaUI(false);
        GameObject.Find("Canvas").transform.Find("PurchaseScreen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("PurchaseClose").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("NoMoney").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
