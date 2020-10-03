using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
