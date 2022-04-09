using UnityEngine;

public class Hand : MonoBehaviour
{
    public static readonly int HandSize = 6;

	public Card[] cards;

	public void init(Deck deck) {
		cards = new Card[HandSize];
		for(int i = 0; i < HandSize; i++) {
			cards[i] = deck.drawTop();
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

	public void displayHand(){
		Debug.Log("Hand: " + cards[0].name + " " + cards[1].name + " " + cards[2].name + " " + cards[3].name + " " + cards[4].name + " " + cards[5].name);
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
