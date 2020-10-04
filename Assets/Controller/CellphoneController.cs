using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;


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

    // Start is called before the first frame update
    void Start()
    {
        
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
