using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	public static int DeckSize = 30;
	public List<Card> deck;
    public int deckSize;


    public GameObject stack;

    // Start is called before the first frame update
    void Start()
    {
        stack = GameObject.Find("PlayerDeck/Cube");
        stack.SetActive(true);
        
    } 
 
    // Update is called once per frame
    public void init()
    {
		deck = new List<Card>();
		for(int i = 0; i < DeckSize; i++){ 
			int x = (int) Random.Range(0,CardDatabase.CardDatabaseSize);
			deck.Add(CardDatabase.cardList[x]); 
			
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
