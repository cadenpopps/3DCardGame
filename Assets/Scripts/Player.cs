using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Player : MonoBehaviour
{
    public Deck deck;
    public Hand hand;

    public void init(){
        deck.init();
        hand.init(deck); 
    }

    public void playCard(Board board) {
        hand.playCard(board);
    }

    public void toggleDisplayHand() {
        if(hand.displayingHand) {
            hand.hide();
        }
        else {
            hand.display();
        }
    }

    public void hoverCard(Direction d) {
        hand.hoverCard(d);
    }

    public void selectCard() {
        hand.selectCard();
    }
    
    public void deselectCard() {
        hand.deselectCard();
    }

}






//     public Config.PlayerType id;
// 	public Hand hand;
// 	public Deck deck;
// 	public string name;
// 	//public UnityEngine.color color;

// 	public int mana;
// 	public int health; 


// 	public Player(Config.PlayerType pType, string pName) {
// 		id = pType;
// 		name = pName;
// 	}

// 	public void initPlayer(Hand pHand, Deck pDeck, int pHealth, int pMana) {
// 		hand = pHand;
// 		deck = pDeck;
// 		health = pHealth;
// 		mana = pMana;
// 	}

// 	public void removeCardFromHand(int cardIndex) {
// 		for(int i = cardIndex; i < Hand.HandSize - 1; i++) {
// 			hand.cards[i] = hand.cards[i + 1];
// 		}
// 		hand.cards[Hand.HandSize - 1] = null;
// 	}

// 	public void drawCardFromDeck() {

// 	}

// 	public void print(bool hidden) {
// 		if(id == Config.PlayerType.CPU) {
// 			System.Console.Write("CPU: ");
// 		}
// 		else {
// 			System.Console.Write("Player: ");
// 		}
// 		System.Console.WriteLine(name);
// 		System.Console.WriteLine("Health: {0}   Mana: {1}", health, mana);
// 		if(hidden) {
// 			System.Console.WriteLine("[?]   [?]   [?]   [?]   [?]");
// 		}
// 		else {
// 			hand.print();
// 		}
// 		System.Console.WriteLine();
// 	}
// }
