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
    public GameObject card;
	public Sprite sprite;
	public GameObject handPrefabResource;
	public GameObject boardPrefabResource;
	public GameObject handPrefab;
	public GameObject boardPrefab;
   

    public void updateDisplay(string[] cardInfo, Rarity rarity) {
        nameText.text = " " + cardInfo[0];
        healthText.text = " " + cardInfo[1];
        attackText.text = " " + cardInfo[2];
        manaText.text = " " + cardInfo[3];
        switch(rarity) {
            case Rarity.Common:
                card.GetComponent<Image>().color = new Color32(0,208,255, 255);
                break;
            case Rarity.Uncommon:
                card.GetComponent<Image>().color = new Color32(115,15,255, 255);
                break;
            case Rarity.Rare:
                card.GetComponent<Image>().color = new Color32(255,15,239, 255);
                break;
            case Rarity.Epic:
                card.GetComponent<Image>().color = new Color32(255,7,40, 255);
                break;
            case Rarity.Legendary:
                card.GetComponent<Image>().color = new Color32(255,189,7, 255);
                break;
            default:
                card.GetComponent<Image>().color = new Color32(255,255,255, 255);
                break;
        }
    }

    // public void displayText(){
    //     nameText.text = " " + handList[0].name;
    //     healthText.text = " " + handList[0].health;
    //     attackText.text = " " + handList[0].attack;
    //     manaText.text = " " + handList[0].manaCost;
    // }




}
