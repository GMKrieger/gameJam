using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CellphoneController : MonoBehaviour
{

    public float timeLeft = 15.0f;

    public void showSmartphone()
    {
        GameObject eyecon = GameObject.Find("Eyecon");
        GameObject cellphone = GameObject.Find("Cellphone");
        eyecon.gameObject.SetActive(false);
        Animator anim = cellphone.gameObject.GetComponent<Animator>();
        anim.SetBool("moveCellphone", true);
    }

    public void changeScene() {
        SceneManager.LoadScene("Game");
    }


    public void loadScene() {
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
            if (RealLifeMoney.failCount == 4)
            {
                SceneManager.LoadScene("BadEnding");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Fades in
        GameObject panel = GameObject.Find("Panel");
        Animator anim = panel.gameObject.GetComponent<Animator>();
        anim.SetBool("FadeInBool", true);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject panel = canvas.transform.Find("Panel").gameObject;
            panel.gameObject.SetActive(true);
            Animator anim = panel.gameObject.GetComponent<Animator>();
            anim.SetBool("FadeOutBool", true);
            SceneManager.LoadScene("BadEnding");
        }
    }
}
