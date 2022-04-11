using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Deck : MonoBehaviour
{
	public static int DeckSize = 10;
	public List<Card> deck;
    public int deckSize;
	

	public GameObject DeckObject;
    public GameObject DeckPrefab;
	public GameObject CardPrefab;
	
    // Start is called before the first frame update
    void Start() { } 
 
    // Update is called once per frame
    public void init()
    {
		deck = new List<Card>();
		for(int i = 0; i < DeckSize; i++){ 
			Card randomCard = CardDatabase.generateRandomCard(CardPrefab);
			deck.Add(randomCard); 
			randomCard.CardObject.transform.parent = DeckObject.transform;
			randomCard.CardObject.transform.localPosition = new Vector3(0, 0, 0);
			
		} 
    }

	public Card drawTop() {
		Card temp = deck[0];
		deck.RemoveAt(0);
		// //Add blank at top
		// for(int i = DeckSize - 2; i >= 0; i--) {
		// 	deck[i] = deck[i+1];
		// }
		// Debug.Log("New top card: ");
		// deck[0].print();
		return temp;
	}
}
