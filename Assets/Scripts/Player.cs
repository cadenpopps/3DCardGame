using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Player : MonoBehaviour
{
    public Deck deck;
    public Hand hand;
    public int health;

    public void init(){
        health = 30;
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
    
    public void beginTurn(Board b) {
        Debug.Log("--- Player turn ---");
        hand.drawOne(deck);
        hand.resetDisplay();
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
        hand.selectCard(0, b);
    }
    
    public void deselectCard() {
        hand.deselectCard();
    }

}