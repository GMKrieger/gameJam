using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    public void playGame()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject panel = canvas.transform.Find("Panel").gameObject;
        panel.gameObject.SetActive(true);
        Animator anim = panel.gameObject.GetComponent<Animator>();
        anim.SetBool("FadeOutBool", true);
    }

    public void changeScene() {
        SceneManager.LoadScene("Intro");
    }

    public void gameScene() {
        SceneManager.LoadScene("CellphoneBedMorning");
    }

    public void about()
    {
        SceneManager.LoadScene("About");
    }

    public void title()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject panel = GameObject.Find("Panel");
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
