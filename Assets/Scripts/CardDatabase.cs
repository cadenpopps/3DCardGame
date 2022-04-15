using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum CardID
{
    Null,

    DrMario,
    LittleMac,
    DonkeyKong,
    Steve,
    Link,
    Fox,
    CaptainFalcon,
    Peach,
    Roy,
    Kirby,
    Yoshi,

    MewTwo,
    Pikachu,
    Ike,
    Ness,
    Bowser,
    Wolf,

    Falco,
    Jigglypuff,
    Cloud,

    Byleth,
    ROB,
    Samus,

    Joker
};

public enum Rarity
{
    Null,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
};

public class CardConfig {
    public Rarity rarity;
    public string name;
    public int health;
    public int attack;
    public int manaCost;
    public CardConfig(Rarity rarity, string name, int health, int attack, int manaCost) {
        this.rarity = rarity;
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.manaCost = manaCost;
    }
}


public class CardDatabase : MonoBehaviour {

    public static int ProbabilityMax = 100;
    public static List<Rarity> Probability = new List<Rarity>();

    public static CardID[] Common = {
        CardID.DrMario,
        CardID.LittleMac,
        CardID.DonkeyKong,
        CardID.Steve,
        CardID.Link,
        CardID.Fox,
        CardID.CaptainFalcon,
        CardID.Peach,
        CardID.Roy,
        CardID.Kirby,
        CardID.Yoshi
    };

    public static CardID[] Uncommon = {
        CardID.MewTwo,
        CardID.Pikachu,
        CardID.Ike,
        CardID.Ness,
        CardID.Bowser,
        CardID.Wolf,
    };

    public static CardID[] Rare = {
        CardID.Falco,
        CardID.Jigglypuff,
        CardID.Cloud,
    };

    public static CardID[] Epic = {
        CardID.Byleth,
        CardID.ROB,
        CardID.Samus,
    };

    public static CardID[] Legendary = {
        CardID.Joker
    };

    public static readonly Dictionary<CardID, CardConfig> CardConfigs = new Dictionary<CardID, CardConfig> {
        //Common
        {CardID.DrMario, new CardConfig(Rarity.Common, "Dr. Mario", 1, 1, 1)},
        {CardID.LittleMac, new CardConfig(Rarity.Common, "Little Mac", 1, 1, 1)},
        {CardID.DonkeyKong, new CardConfig(Rarity.Common, "Donkey Kong", 2, 1, 1)},
        {CardID.Steve, new CardConfig(Rarity.Common, "Steve", 1, 1, 1)},
        {CardID.Link, new CardConfig(Rarity.Common, "Link", 1, 1, 1)},
        {CardID.Fox, new CardConfig(Rarity.Common, "Fox", 2, 1, 1)},
        {CardID.CaptainFalcon, new CardConfig(Rarity.Common, "Captain Falcon", 1, 1, 1)},
        {CardID.Peach, new CardConfig(Rarity.Common, "Peach", 1, 1, 1)},
        {CardID.Roy, new CardConfig(Rarity.Common, "Roy", 2, 1, 1)},
        {CardID.Kirby, new CardConfig(Rarity.Uncommon, "Kirby", 2, 2, 2)},
        {CardID.Yoshi, new CardConfig(Rarity.Common, "Yoshi", 1, 1, 1)},
        //Uncommon
        {CardID.MewTwo, new CardConfig(Rarity.Uncommon, "MewTwo", 1, 3, 2)},
        {CardID.Pikachu, new CardConfig(Rarity.Common, "Pikachu", 1, 1, 1)},
        {CardID.Ike, new CardConfig(Rarity.Uncommon, "Ike", 3, 2, 2)},
        {CardID.Ness, new CardConfig(Rarity.Common, "Ness", 2, 1, 1)},
        {CardID.Bowser, new CardConfig(Rarity.Common, "Bowser", 1, 1, 1)},
        {CardID.Wolf, new CardConfig(Rarity.Common, "Wolf", 1, 1, 1)},
        //Rare
        {CardID.Falco, new CardConfig(Rarity.Rare, "Falco", 2, 3, 3)},
        {CardID.Jigglypuff, new CardConfig(Rarity.Rare, "Jigglypuff", 2, 4, 3)},
        {CardID.Cloud, new CardConfig(Rarity.Common, "Cloud", 1, 1, 1)},
        //Epic
        {CardID.Byleth, new CardConfig(Rarity.Epic, "Byleth", 3, 4, 4)},
        {CardID.ROB, new CardConfig(Rarity.Epic, "R.O.B", 4, 3, 4)},
        {CardID.Samus, new CardConfig(Rarity.Common, "Samus", 1, 1, 1)},
        //Legendary
        {CardID.Joker, new CardConfig(Rarity.Legendary, "Joker", 5, 4, 5)},
        //Null
        {CardID.Null, new CardConfig(Rarity.Null, "Null", 0, 0, 0)}
    };


    public static void init() {
        for (int numTickets = 0; numTickets < ProbabilityMax; numTickets++) {
            switch (numTickets) {
                case int n when (numTickets < 50):
                    Probability.Add(Rarity.Common);
                    break;
                case int n when (numTickets < 70):
                    Probability.Add(Rarity.Uncommon);
                    break;
                case int n when (numTickets < 85):
                    Probability.Add(Rarity.Rare);
                    break;
                case int n when (numTickets < 95):
                    Probability.Add(Rarity.Epic);
                    break;
                case int n when (numTickets < 100):
                    Probability.Add(Rarity.Legendary);
                    break;
                // EQUAL VALUES FOR TESTING
                // case int n when (numTickets < 20):
                //     Probability.Add(Rarity.Common);
                //     break;
                // case int n when (numTickets < 40):
                //     Probability.Add(Rarity.Uncommon);
                //     break;
                // case int n when (numTickets < 60):
                //     Probability.Add(Rarity.Rare);
                //     break;
                // case int n when (numTickets < 80):
                //     Probability.Add(Rarity.Epic);
                //     break;
                // case int n when (numTickets < 100):
                //     Probability.Add(Rarity.Legendary);
                //     break;
                default:
                    Probability.Add(Rarity.Null);
                    break;
            }
        }
    }

    public static Card generateCard(CardID cardId, GameObject CardPrefab) {
        GameObject cardGameObject = Instantiate(CardPrefab, Vector3.one, Quaternion.identity);
        Card card = cardGameObject.GetComponent<Card>() as Card;
        card.init(cardGameObject, cardId, CardConfigs[cardId]);
        return card;
    }

    public static Card generateRandomCard(GameObject CardPrefab) {
        Rarity selectedRarity = Probability[Random.Range(0, ProbabilityMax)];
        CardID cardIdSelected = CardID.Null;

        switch (selectedRarity) {
            case Rarity.Common:
                cardIdSelected = ((CardID) Common[Random.Range(0, Common.Length)]);
                break;
            case Rarity.Uncommon:
                cardIdSelected = ((CardID) Uncommon[Random.Range(0, Uncommon.Length)]);
                break;
            case Rarity.Rare:
                cardIdSelected = ((CardID) Rare[Random.Range(0, Rare.Length)]);
                break;
            case Rarity.Epic:
                cardIdSelected = ((CardID) Epic[Random.Range(0, Epic.Length)]);
                break;
            case Rarity.Legendary:
                cardIdSelected = ((CardID) Legendary[Random.Range(0, Legendary.Length)]);
                break;
        }
        return generateCard(cardIdSelected, CardPrefab);
    }
}