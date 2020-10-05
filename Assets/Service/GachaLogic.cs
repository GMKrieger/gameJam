using Assets.Service;
using System;
using System.Collections;
using UnityEngine;


public class GachaLogic : MonoBehaviour
{

    public Character GetSingleCharacter()
    {
        GachaCharacter gachaCharacter = gameObject.AddComponent<GachaCharacter>();
        int roll = UnityEngine.Random.Range(1, 1000);
        Character character;

        if (roll <= 500)
        { //1 estrela
            character = gachaCharacter.getRandomCharacterByRarity("1");
        }
        else if (roll <= 750)
        { //2 estrelas
            character = gachaCharacter.getRandomCharacterByRarity("2");
        }
        else if (roll <= 900)
        { //3 estrelas
            character = gachaCharacter.getRandomCharacterByRarity("3");
        }
        else if (roll <= 999)
        { //4 estrelas
            character = gachaCharacter.getRandomCharacterByRarity("4");
        }
        else
        {//5 estrela sortudo da porra vai pra puta que pariu
            character = gachaCharacter.getRandomCharacterByRarity("5");
        }

        return character;
    }

    public Stack<Character> GetMultipleCharacters(int quantity)
    {
        GachaCharacter gachaCharacter = gameObject.AddComponent<GachaCharacter>();
        Stack<Character> characterList = new Stack<Character>();
        for (int i = 0; i < quantity; i++)
        {
            int roll = UnityEngine.Random.Range(1, 1000);
            Character character;

            if (roll <= 500)
            { //1 estrela
                character = gachaCharacter.getRandomCharacterByRarity("1");
            }
            else if (roll <= 750)
            { //2 estrelas
                character = gachaCharacter.getRandomCharacterByRarity("2");
            }
            else if (roll <= 900)
            { //3 estrelas
                character = gachaCharacter.getRandomCharacterByRarity("3");
            }
            else if (roll <= 999)
            { //4 estrelas
                character = gachaCharacter.getRandomCharacterByRarity("4");
            }
            else
            {//5 estrela sortudo da porra vai pra puta que pariu
                character = gachaCharacter.getRandomCharacterByRarity("5");
            }
            characterList.Push(character);
        }
        return characterList;
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