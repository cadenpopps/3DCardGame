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
    
    public void beginTurn() {
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
        hand.selectCard(b);
    }
    
    public void deselectCard() {
        hand.deselectCard();
    }

}