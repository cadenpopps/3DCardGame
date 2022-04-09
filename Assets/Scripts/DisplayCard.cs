using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCard : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
	public int rarity;
	public string name;
	public int health;
	public int attack;
	public int manaCost;

    void Start()
    {
        displayCard[0] = CardDatabase.cardList[1];
        id = displayCard[0].id;
        rarity = displayCard[0].rarity;
        name = displayCard[0].name;
        health = displayCard[0].health;
        attack = displayCard[0].attack;
        manaCost = displayCard[0].manaCost;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
