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
            gachaCharacter.getRandomCharacterByRarity("1");
        }
        else if (roll <= 750) { //2 estrelas
            gachaCharacter.getRandomCharacterByRarity("2");
        }
        else if (roll <= 900) { //3 estrelas
            gachaCharacter.getRandomCharacterByRarity("3");
        }
        else if (roll <= 999) { //4 estrelas
            gachaCharacter.getRandomCharacterByRarity("4");
        }
        else {
            gachaCharacter.getRandomCharacterByRarity("5");
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