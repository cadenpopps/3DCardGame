using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum CardID {
    Null,
    Gragas,
    Jinx,
    Lux,
    Darius,
    Vladimir
};

public enum Rarity {
    Null,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
};

public class CardDatabase : MonoBehaviour
{
    public static Card generateCard(CardID cardId, GameObject CardPrefab) {
        GameObject cardObject;
        Card card;
        switch(cardId) {
            case CardID.Gragas:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Gragas, Rarity.Common, "Gragas", 2, 1, 1);
                return card;
            case CardID.Jinx:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Jinx, Rarity.Uncommon, "Jinx", 1, 2, 1);
                return card;
            case CardID.Lux:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Lux, Rarity.Rare, "Lux", 1, 3, 2);
                return card;
            case CardID.Darius:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Darius, Rarity.Epic, "Darius", 3, 3, 3);
                return card;
            case CardID.Vladimir:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Vladimir, Rarity.Legendary, "Vladimir", 4, 5, 5);
                return card;
            default:
                cardObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
                card = cardObject.GetComponent<Card>() as Card;
                card.init(cardObject, CardID.Null, Rarity.Null, "Null", 0, 0, 0);
                return card;
        }
    }
    
    public static Card generateRandomCard(GameObject CardPrefab) {
        var cardIds = System.Enum.GetValues(typeof(CardID));
        return generateCard((CardID) cardIds.GetValue(Random.Range(1, cardIds.Length)), CardPrefab);
    }
}
