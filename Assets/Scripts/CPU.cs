using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
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
        Debug.Log("CPU Turn");
        hand.drawOne(deck);
        hand.resetDisplay();
        hand.display();
        this.selectCard(b);
        if(hand.currentlySelected > -1) {
            this.playCard(b);
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
