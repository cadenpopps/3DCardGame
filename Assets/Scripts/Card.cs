using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
	public CardID id;
	public Rarity rarity;
	public string name;
	public int health;
	public int attack;
	public int manaCost;
	
	public int positionInHand;
	public bool currentlyHovered;
	public bool currentlySelected;
	public BoardSpace selectedBoardSpace; 
	
	public CardDisplay cardDisplay;
	
	public GameObject CardInHandObject;
	public GameObject CardObject;

	public void init(GameObject cardObject, CardID CardId, Rarity Rarity, string Name, int Health, int Attack, int ManaCost) {
		CardObject = cardObject;
		id = CardId;
		rarity = Rarity;
		name = Name;
		health = Health;
		attack = Attack;
		manaCost = ManaCost;

		currentlyHovered = false;
		currentlySelected = false;

		cardDisplay = CardInHandObject.GetComponent<CardDisplay>() as CardDisplay;
		cardDisplay.init(this);

	}
	
	public void enableHandPrefab() {
		cardDisplay.inHandPrefab.SetActive(true); 
	}
	
	public void disableHandPrefab() {
		cardDisplay.inHandPrefab.SetActive(false); 
	}

	public void updatePosition(int pos) {
		positionInHand = pos;
	}

}