using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    public static readonly int HandSize = 5;
    public static readonly int InitialHandSize = 4;

	public Card[] cards;

	public void init(Deck deck) {
		cards = new Card[HandSize];
		fillHandFromDeck(deck);
	}

	private void fillHandFromDeck(Deck deck) {
		for(int i = 0; i < InitialHandSize; i++) {
			if(addCardToHand(deck.drawTop())) {
				Debug.Log("Added card");
			}
			else {
				Debug.Log("Couldn't add card");
			}
		}
	}
	
	public Card getCard(int cardNum) {
		try {
			return cards[cardNum];
		}
		catch {
			Debug.Log("Out of range card");
			return null;
		}
	}

	private bool addCardToHand(Card card) {
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] == null) {
				cards[i] = card;
				cards[i].addHandPrefab(i);	
				return true;
			}
		}
		return false;
	}

	public void displayHand(){
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] != null) {
				cards[i].enableHandPrefab();
			}
		}
	}

	// public void print() {
	// 	for(int i = 0; i < HandSize; i++) {
	// 		if(cards[i] != null) {
	// 			cards[i].print();
	// 			//System.Console.Write(" ");
	// 		}
	// 		else {
	// 			System.Console.Write("Empty ");
	// 		}
	// 	}
	// }
}
