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
        mana = 10;
        deck.init();
        hand.init(deck); 
        this.updateUI();

    }

	public void updateUI() {
        healthText.text = health.ToString();
        manaText.text = mana.ToString();
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
    
    public void beginTurn(Board board) {
        Debug.Log("--- CPU turn ---");
        hand.drawOne(deck);
        hand.resetDisplay();
        hand.display();
        while(hand.getNumCardsInHand() > 1 && board.cardsOnRow(1) < board.cardsOnRow(0)) {
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


}
