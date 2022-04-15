using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Deck : MonoBehaviour {

	public static int DeckSize = 30;
	public List<Card> deck;
	public GameObject DeckObject;
    public GameObject DeckPrefab;
	public GameObject CardPrefab;
	
    public void init() {
		deck = new List<Card>();
		for(int i = 0; i < DeckSize; i++){ 
			Card randomCard = CardDatabase.generateRandomCard(CardPrefab);
			deck.Add(randomCard); 
			randomCard.CardObject.transform.parent = DeckObject.transform;
			randomCard.CardObject.transform.localPosition = new Vector3(0, 0, 0);
			
		} 
    }

	public void reset() {
		Card[] cardObjects = DeckObject.GetComponentsInChildren<Card>();
		for(int i = 0; i < cardObjects.Length; i++) {
			cardObjects[i].CardObject.transform.parent = null;
			Destroy(cardObjects[i].CardObject);
		}
	}

	public Card drawTop() {
		Card temp = deck[0];
		deck.RemoveAt(0);
		return temp;
	}
}
