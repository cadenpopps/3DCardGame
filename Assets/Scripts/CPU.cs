using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class CPU : MonoBehaviour
{
    
    public Deck deck;
    public Hand hand;
    public int health;
    public int mana;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;

    public void init(){
        health = 30;
        mana = 3;
        // mana = GameConfig.StartingMana;
        deck.init();
        hand.init(deck); 
        this.resetUI();
        this.updateUI();
    }

    public void reset() {
        deck.reset();
        hand.reset();
    }

	public void updateUI() {
        manaText.color = Color.white;
        manaText.text = mana.ToString();
        healthText.text = health.ToString();
        if(health < 10) {
            healthText.color = Color.red;
        }
    }
    
	public void resetUI() {
        manaText.color = Color.white;
        healthText.color = Color.white;
        manaText.text = mana.ToString();
        healthText.text = health.ToString();
    }

    public void toggleDisplayHand() {
        if(hand.displayingHand) {
            hand.hide();
        }
        else {
            hand.display();
        }
    }
    
    public void beginTurn(Board board) {
        Debug.Log("--- CPU turn ---");
        hand.drawOne(deck);
        hand.resetDisplay();
        hand.display();
        if(mana >= 8) {
            this.drawCard();
        }
        int turnCounter = 0;
        while(turnCounter < 3 && mana >= 1 && hand.getNumCardsInHand() >= 1 && board.cardsOnRow(1) < board.cardsOnRow(0)) {
            turnCounter++;
            //make suer to make this random
            this.selectCard(board);
            if(hand.currentlySelected > -1) {
                this.playCard(board);
            }
        }
        this.endTurn();
    }

    public void endTurn() {
        hand.resetDisplay();
    }
    
    public void hoverCard(Direction d) {
        hand.hoverCard(d);
    }
    
    public void moveSelected(Direction d, Board board) {
        hand.moveSelected(d, board);
    }

    public void selectCard(Board b) {
        hand.selectCard(1, b);
    }
    
    public void deselectCard() {
        hand.deselectCard();
    }

    public bool playCard(Board board) {
        if(mana >= hand.cards[hand.currentlySelected].manaCost) {
            mana -= hand.cards[hand.currentlySelected].manaCost;
            hand.playCard(board);
            this.updateUI();
            return true;
        }
        else {
            Debug.Log("Not enough mana to play this card!");
            manaText.color = Color.red;
            return false;
        }
    }

    public void drawCard() {
        // if(mana >= GameConfig.DrawCardManaCost) {
        if(mana < 3) {
            Debug.Log("Not enough mana to draw a card!");
            manaText.color = Color.red;
        }
        else if(mana >= 3 && !hand.isHandFull()) {
            mana -= 3;
            // mana -= GameConfig.DrawCardManaCost;
            hand.drawOne(deck);
        }
    }
}
