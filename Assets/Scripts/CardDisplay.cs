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
	public Sprite sprite;
	public GameObject handPrefabResource;
	public GameObject boardPrefabResource;
	public GameObject handPrefab;
	public GameObject boardPrefab;
   

    public void updateDisplay(string[] cardInfo) {
        nameText.text = " " + cardInfo[0];
        healthText.text = " " + cardInfo[1];
        attackText.text = " " + cardInfo[2];
        manaText.text = " " + cardInfo[3];
    }

    // public void displayText(){
    //     nameText.text = " " + handList[0].name;
    //     healthText.text = " " + handList[0].health;
    //     attackText.text = " " + handList[0].attack;
    //     manaText.text = " " + handList[0].manaCost;
    // }




}
