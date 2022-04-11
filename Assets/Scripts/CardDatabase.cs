using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum CardID {
    Null,

    DrMario,
    LittleMac,
    DonkeyKong,

    MewTwo,
    Kirby,
    Ike,

    Falco,
    Jigglypuff,

    Byleth,
    ROB,

    Joker
};

public enum Rarity {
    Null,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
};

// health/attack/mana cost


public class CardDatabase : MonoBehaviour
{

    public static List<Rarity> probabilityStruct = new List<Rarity>();


    public static Card generateCard(CardID cardId, GameObject CardPrefab) {
        GameObject cardObject;
        Card card;
        switch(cardId) {
            case CardID.DrMario:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.DrMario, Rarity.Common, "Dr. Mario", 1, 2, 1);
                return card;
            case CardID.LittleMac:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.LittleMac, Rarity.Common, "Little Mac", 1, 1, 1);
                return card;
            case CardID.DonkeyKong:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.DonkeyKong, Rarity.Common, "Donkey Kong", 2, 1, 1);
                return card;
            case CardID.MewTwo:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.MewTwo, Rarity.Uncommon, "MewTwo", 1, 3, 2);
                return card;
            case CardID.Kirby:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Kirby, Rarity.Uncommon, "Kirby", 2, 2, 2);
                return card;
            case CardID.Ike:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Ike, Rarity.Uncommon, "Ike", 3, 2, 2);
                return card;
            case CardID.Falco:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Falco, Rarity.Rare, "Falco", 2, 3, 3);
                return card;
            case CardID.Jigglypuff:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Jigglypuff, Rarity.Rare, "Jigglypuff", 2, 4, 3);
                return card;
            case CardID.Byleth:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Byleth, Rarity.Epic, "Byleth", 3, 4, 4);
                return card;
            case CardID.ROB:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.ROB, Rarity.Epic, "R.O.B", 4, 3, 4);
                return card;
            case CardID.Joker:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Joker, Rarity.Legendary, "Joker", 5, 4, 5);
                return card;
            default:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Null, Rarity.Null, "Null", 0, 0, 0);
                return card;
        }
    }
    
    public static void probInit(){
        for(int i = 0; i < 110; i++){
            switch(i) {
                case int n when (i < 45):
                    probabilityStruct.Add(Rarity.Common);
                    break;
                case int n when i < 68:
                    probabilityStruct.Add(Rarity.Uncommon);
                    break;
                case int n when i < 84:
                    probabilityStruct.Add(Rarity.Rare);
                    break;
                case int n when i < 99:
                    probabilityStruct.Add(Rarity.Epic);
                    break;
                case int n when i < 110:
                    probabilityStruct.Add(Rarity.Legendary);
                    break;
                default:
                    probabilityStruct.Add(Rarity.Null);
                    break;
            }
        }
    }

    public static Card generateRandomCard(GameObject CardPrefab) {

        
        var rarityIndex = System.Enum.GetValues(typeof(CardID));
        Rarity selectedRarity = probabilityStruct[Random.Range(1, rarityIndex.Length)];


        // CardID selectedRarity = (CardID) cardIds.GetValue(Random.Range(1, cardIds.Length))
        // Rarity selectedRarity = probabilityStruct[rarityIndex];
        // CardID temp = CardID.Epic;
        // if(selectedRarity == Rarity.Common){

        // }

        var cardIds = System.Enum.GetValues(typeof(CardID));
        return generateCard((CardID) cardIds.GetValue(Random.Range(1, cardIds.Length)), CardPrefab);
    }
}