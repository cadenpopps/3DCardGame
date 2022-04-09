using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{

    public Text idText;
	public Text rarityText; 
	public Text nameText;
	public Text healthText;
	public Text attackText;
	public Text manaText;

    public static readonly int HandSize = 6;

    public List<Card> handList;
   
   
    public void init(Hand handC){
        for(int i = 0; i < HandSize; i++){
            handList.Add(handC.cards[i]);
        }


    }

    public void displayText(){
        nameText.text = " " + handList[0].name;
        healthText.text = " " + handList[0].health;
        attackText.text = " " + handList[0].attack;
        manaText.text = " " + handList[0].manaCost;
    }




}
