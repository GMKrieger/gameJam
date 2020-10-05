using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CellphoneSubwayController : MonoBehaviour
{

    public float time = 0.0f;
    public float timeLeft = 15.0f;
    public bool didShow = false;
    public bool didHide = false;

    public void showSmartphone()
    {
        GameObject eyecon = GameObject.Find("Eyecon");
        GameObject cellphone = GameObject.Find("Cellphone");
        GameObject notification = GameObject.Find("Notification");
        eyecon.gameObject.SetActive(false);
        notification.gameObject.SetActive(false);
        Animator anim = cellphone.gameObject.GetComponent<Animator>();
        anim.SetBool("moveCellphone", true);
    }

    public void openGame()
    {
        SceneManager.LoadScene("GameSubway");
    }

    public void changeScene()
    {
        RealLifeMoney.successCount += 1;
        SceneManager.LoadScene("CellphoneBedNight");
    }

    public void loadScene()
    {
        GameObject panel = GameObject.Find("Panel");
        panel.gameObject.SetActive(false);
        GameObject textGO = GameObject.Find("Money");
        Text text = textGO.GetComponent<Text>();
        text.color = RealLifeMoney.color;
        text.text = "$" + RealLifeMoney.money.ToString();
        if (RealLifeMoney.money <= 0)
        {
            text.color = new Color(0.9f, 0.2f, 0.3f, 1.0f);
            RealLifeMoney.failCount += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Fades in
        GameObject panel = GameObject.Find("Panel");
        Animator anim = panel.gameObject.GetComponent<Animator>();
        anim.SetBool("FadeInBool", true);
        if (RealLifeMoney.failCount == 3)
        {
            SceneManager.LoadScene("BadEnding");
        }
        if (RealLifeMoney.successCount == 6)
        {
            SceneManager.LoadScene("GoodEnding");
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeLeft -= Time.deltaTime;
        GameObject notification = GameObject.Find("Notification");
        Animator animNoti = notification.gameObject.GetComponent<Animator>();

        if (time > 3 && !didShow)
        {
            didShow = true;
            animNoti.SetBool("Show", true);
            int lolrandom = Random.Range(1, 21);
            string notifFile = "notification" + lolrandom.ToString();
            Sprite notifImage = Resources.Load<Sprite>("Notifications/" + notifFile);
            notification.gameObject.GetComponent<Image>().sprite = notifImage;
        }

        if (time > 10 && !didHide)
        {
            didHide = true;
            animNoti.SetBool("Show", false);
            animNoti.SetBool("Hide", true);
        }

        if (timeLeft < 0)
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject panel = canvas.transform.Find("Panel").gameObject;
            panel.gameObject.SetActive(true);
            Animator anim = panel.gameObject.GetComponent<Animator>();
            anim.SetBool("FadeOutBool", true);
        }

    }
}
