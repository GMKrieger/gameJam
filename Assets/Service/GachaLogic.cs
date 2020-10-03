using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;


public class GachaLogic : MonoBehaviour
{

    public GachaCharacter GetCharacter()
    {
        GachaCharacter gachaCharacter = new GachaCharacter();
        int roll = UnityEngine.Random.Range(1, 1000);

        if (roll <= 500) { //1 estrela
            gachaCharacter.setCharacterName("1 estrela");
        }
        else if (roll <= 750) { //2 estrelas

        }
        else if (roll <= 900) { //3 estrelas

        }
        else if (roll <= 999) { //4 estrelas

        }
        else { //BRASIL-CHAN FTW

        }

        return gachaCharacter;
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}