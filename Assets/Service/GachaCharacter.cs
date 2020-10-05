using Assets.Service;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using System.IO;
using System.Linq;

public class GachaCharacter : MonoBehaviour
{
    private List<Character> AllCharacters;
    public GachaCharacter()
    {
        AllCharacters = File.ReadAllLines(@"Assets\Resources\Characters\characters.txt")
            .Select(linha => Character.fromText(linha))
            .ToList();
    }

    public Character getRandomCharacterByRarity(string rarity)
    {
        var character = AllCharacters.Where(c => c.Raridade == rarity).ToList();
        return character[Random.Range(0, character.Count)];
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
