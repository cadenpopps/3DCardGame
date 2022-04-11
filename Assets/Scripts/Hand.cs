using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class Hand : MonoBehaviour
{
    public static readonly int HandSize = 5;
    public static readonly int InitialHandSize = 5;
	public GameObject CardPrefab;

	public Card[] cards;
	
	public bool displayingHand = false;
	public bool displayingSelected = false;
	public int currentlyHovered = 0;
	public int currentlySelected = -1;
	
	public GameObject HandObject;

	public void init(Deck deck) {
		cards = new Card[HandSize];
		fillHandFromDeck(deck);
	}

	private void fillHandFromDeck(Deck deck) {
		for(int i = 0; i < InitialHandSize; i++) {
			if(isHandFull()) {
				return;
			}
			else {
				Card drawnCard = deck.drawTop();
				if(addCardToHand(deck.drawTop())) {
					Debug.Log("Added card " + drawnCard.name);
				}
				else {
					Debug.Log("Couldn't add card");
				}
			}
		}

		cards[currentlyHovered].currentlyHovered = true;
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

	private bool isHandFull() {
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] == null) {
				return false;
			}
		}
		return true;
	}
	
	private bool isHandScrollable() {
		int counter = 0;
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] != null) {
				counter++;
			}
		}
		return counter >= 2;
	}

	private bool addCardToHand(Card card) {
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] == null) {
				cards[i] = card;
				card.CardObject.transform.parent = HandObject.transform;
				card.CardObject.transform.localPosition = Vector3.one;
				card.CardObject.transform.localRotation = Quaternion.identity;
				card.CardObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
				return true;
			}
		}
		return false;
	}
	
	private void removeCardFromHand(int cardIndex) {
		if(cards[cardIndex] != null) {
			cards[cardIndex] = null;
			for(int i = 0; i < HandSize; i++) {
				if(cards[i] == null) {
					for(int j = i; j < HandSize - 1; j++) {
						cards[j] = cards[j + 1];
					}
					cards[HandSize - 1] = null;
					break;
				}
			}
		}
	}

	public void display(){
		displayingHand = true;
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] != null) {
				Card card = cards[i];
				card.enableHandPrefab();
				card.CardObject.transform.localPosition = Vector3.one;
				card.CardObject.transform.localRotation = Quaternion.identity;
				card.CardObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			}
		}
	}

	public void hide(){
		displayingHand = false;
		for(int i = 0; i < HandSize; i++) {
			if(cards[i] != null) {
				cards[i].disableHandPrefab();
			}
		}
	}

	public void playCard(Board board) {
		board.addCard(cards[currentlySelected], cards[currentlySelected].selectedBoardSpace);
		this.removeCardFromHand(currentlySelected);
		this.deselectCard();
		this.resetHover();
	}

	public void selectCard(Board board) {
		if(cards[currentlyHovered] != null && board.getFirstAvailableSpacePlayer() != null) {
			displayingSelected = true;
			currentlySelected = currentlyHovered;
			cards[currentlySelected].currentlySelected = true;
			cards[currentlySelected].selectedBoardSpace = board.getFirstAvailableSpacePlayer();
		}
	}
	
	public void deselectCard() {
		if(cards[currentlySelected] != null) {
			cards[currentlySelected].currentlySelected = false;
		}
		displayingSelected = false;
		currentlyHovered = currentlySelected;
		this.updateHover();
		currentlySelected = -1;
	}
	
    public void hoverCard(Direction d) {
		int newHovered;
		if(!isHandScrollable()) {
			Debug.Log("Not enough cards in hand to scroll");
			return;
		}
		else if(d == Direction.Left) {
			cards[currentlyHovered].currentlyHovered = false;
			newHovered = currentlyHovered - 1;
			if(newHovered < 0) {
				newHovered = HandSize - 1;
			}
			while(cards[newHovered] == null) {
				newHovered = newHovered - 1;
				if(newHovered < 0) {
					newHovered = HandSize - 1;
				}
			}
			currentlyHovered = newHovered;
		}
		else if(d == Direction.Right) {
			cards[currentlyHovered].currentlyHovered = false;
			newHovered = currentlyHovered + 1;
			if(newHovered >= HandSize) {
				newHovered = 0;
			}
			while(isHandScrollable() && cards[newHovered] == null) {
				newHovered = newHovered + 1;
				if(newHovered >= HandSize) {
					newHovered = 0;
				}
			}
			currentlyHovered = newHovered;
		}
		else {
			Debug.Log("Unrecognized direction");
		}
		this.updateHover();
    }

	public void updateHover() {
		for(int i = 0; i < HandSize; i++) {
			if(i == currentlyHovered && cards[i] != null) {
				cards[i].currentlyHovered = true;
			}
			else if(cards[i] != null) {
				cards[i].currentlyHovered = false;
			}
		}
	}

	public void resetHover() {
		currentlyHovered = 0;
		this.updateHover();
	}

	void Update() {
		if(displayingSelected) {
			for(int i = 0; i < HandSize; i++) {
				if(cards[i] != null) {
					cards[i].updatePosition(i);
					cards[i].cardDisplay.updatePosition();
					cards[i].cardDisplay.updateSelected();
				}
			}
		}
		else if(displayingHand) {
			for(int i = 0; i < HandSize; i++) {
				if(cards[i] != null) {
					cards[i].updatePosition(i);
					cards[i].cardDisplay.updatePosition();
					cards[i].cardDisplay.updateHover();
				}
			}
		}
	}
}
