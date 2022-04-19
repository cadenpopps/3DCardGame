using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]

public class Player : MonoBehaviour
{
    public Deck deck;
    public Hand hand;
    public int health;
    public int mana;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;

    public void init(){
		this.reset();
    }

    public void reset() {
        health = Config.StartingHealth;
        mana = Config.StartingMana;
        deck.init();
        hand.init(deck);
        this.resetUI();
    }

    public void beginTurn(Board b) {
        Debug.Log("--- Player turn ---");
        this.resetUI();
        hand.draw(deck);
        hand.resetDisplay();
    }

    public void updateUI()
    {
        manaText.text = mana.ToString();
        healthText.text = health.ToString();
        if (health < 10)
        {
            healthText.color = Color.red;
        }
    }

    public void resetUI()
    {
        manaText.color = Color.white;
        healthText.color = Color.white;
        manaText.text = mana.ToString();
        healthText.text = health.ToString();
    }

    public void toggleDisplayHand()
    {
        if (hand.displayingHand)
        {
            hand.hide();
        }
        else
        {
            hand.display();
        }
    }



    public void hoverCard(Direction d)
    {
        hand.hoverCard(d);
    }

    public void moveSelected(Direction d, Board board)
    {
        hand.moveSelected(d, board);
    }

    public void selectCard(Board b)
    {
        hand.selectCard(0, b);
    }

    public void deselectCard()
    {
        hand.deselectCard();
    }

    public bool playCard(Board board)
    {
        if (mana >= hand.cards[hand.currentlySelected].manaCost)
        {
            mana -= hand.cards[hand.currentlySelected].manaCost;
            hand.playCard(board);
            this.updateUI();
            return true;
        }
        else
        {
            Debug.Log("Not enough mana to play this card!");
            manaText.color = Color.red;
            return false;
        }
    }

    public void drawCard()
    {
        // if(mana >= GameConfig.DrawCardManaCost) {
        if (mana < 3)
        {
            Debug.Log("Not enough mana to draw a card!");
            manaText.color = Color.red;
        }
        else if (mana >= 3 && !hand.isHandFull())
        {
            mana -= 3;
            // mana -= GameConfig.DrawCardManaCost;
            hand.draw(deck);
        }
    }

    public void endTurn() {
        hand.resetDisplay();
    }
}
