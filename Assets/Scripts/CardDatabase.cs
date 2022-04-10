using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static Card generateCard(CardID cardId) {
        switch(cardId) {
            case CardID.Gragas:
                return new Card(CardID.Gragas, Rarity.Common, "Gragas", 2, 1, 1);
            case CardID.Jinx:
                return new Card(CardID.Jinx, Rarity.Uncommon, "Jinx", 1, 2, 1);
            case CardID.Lux:
                return new Card(CardID.Lux, Rarity.Rare, "Lux", 1, 3, 2);
            case CardID.Darius:
                return new Card(CardID.Darius, Rarity.Epic, "Darius", 3, 3, 3);
            case CardID.Vladimir:
                return new Card(CardID.Vladimir, Rarity.Legendary, "Vladimir", 4, 5, 5);
            default:
                return new Card(CardID.Null, Rarity.Null, "Null", 0, 0, 0);
        }
    }
    
    public static Card generateRandomCard() {
        var cardIds = System.Enum.GetValues(typeof(CardID));
        return generateCard((CardID) cardIds.GetValue(Random.Range(1, cardIds.Length)));
    }
}
