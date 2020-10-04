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
        RealLifeMoney.money -= 20;
        SceneManager.LoadScene("Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject textGO = GameObject.Find("Money");
        Text text = textGO.GetComponent<Text>();
        text.text = "$" + RealLifeMoney.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
