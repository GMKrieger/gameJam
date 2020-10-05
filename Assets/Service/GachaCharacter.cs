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

        //AllCharacters = File.ReadAllLines(@"Assets\Resources\Characters\characters.txt");
        string[] arquivo = new string[] { "1;Caipirinha;1Estrela/Caipirinha",
                                            "1;Feijoada;1Estrela/Feijoada",
                                            "1;Pastel;1Estrela/Pastel",
                                            "1;Catupiry;1Estrela/Catupiry",
                                            "1;Açaí;1Estrela/Acai",
                                            "1;Farofa;1Estrela/Farofa",
                                            "1;Picanha;1Estrela/Picanha",
                                            "1;Côco Verde;1Estrela/Coco",
                                            "1;Coxinha;1Estrela/Coxinha",
                                            "1;Brigadeiro;1Estrela/Brigadeiro",
                                            "2;Vira Lata Caramelo (♂);2Estrelas/ViraLataCaramelo",
                                            "2;Lobo guará (♀);2Estrelas/LoboGuara",
                                            "2;Crocodilo Papo-Amarelo (♂);2Estrelas/JacareDePapoAmarelo",
                                            "2;Mico Leão Dourado;2Estrelas/MicoLeaoDourado",
                                            "2;Arara Azul;2Estrelas/AraraAzul",
                                            "2;Capivara;2Estrelas/Capivara",
                                            "3;Cristo Redentor;3Estrelas/CristoRedentor",
                                            "3;Cataratas do Iguaçu;3Estrelas/CataratasDoIguacu",
                                            "3;Floresta amazônica;3Estrelas/FlorestaAmazonica",
                                            "3;Gruta da Lagoa Azul;3Estrelas/GrutaDaLagoaAzul",
                                            "4;Machado de Assis;4Estrelas/MachadoDeAssis",
                                            "4;Alberto Santos-Dumont;4Estrelas/SantosDumont",
                                            "4;Dercy Gonçalves;4Estrelas/DercyGoncalves",
                                            "5;Brasil-Chan;5Estrelas/BrasilChan" };
        AllCharacters = arquivo.Select(linha => Character.fromText(linha))
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
