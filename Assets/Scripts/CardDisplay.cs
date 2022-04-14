using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class CardDisplay : MonoBehaviour
{
    
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI attackText;
	public TextMeshProUGUI manaText;
	public GameObject inHandPrefab;
	public GameObject onBoardPrefab;
	public Card card;

    public void init(Card c) {
        card = c;
        this.addHandPrefab();
    }
    
	public void addHandPrefab() {
		this.updateDisplay();
		inHandPrefab.transform.SetParent(card.CardObject.transform);
        inHandPrefab.transform.localPosition = Vector3.zero;
		inHandPrefab.SetActive(false); 
	}

	private Sprite generateSprite(string PathToTexture) {
		Texture2D tex = Resources.Load<Texture2D>(PathToTexture);
		Sprite temp = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 800);
		return temp;
	}

    public void updateDisplay() {
        nameText.text = card.name.ToString();
        healthText.text = card.health.ToString();
        attackText.text = card.attack.ToString();
        manaText.text = card.manaCost.ToString();
        this.updateRarity();
    }

    public void updateRarity() {
        switch(card.rarity) {
            case Rarity.Common:
                inHandPrefab.GetComponent<Image>().color = new Color32(0,208,255, 255);
                break;
            case Rarity.Uncommon:
                inHandPrefab.GetComponent<Image>().color = new Color32(115,15,255, 255);
                break;
            case Rarity.Rare:
                inHandPrefab.GetComponent<Image>().color = new Color32(255,15,239, 255);
                break;
            case Rarity.Epic:
                inHandPrefab.GetComponent<Image>().color = new Color32(255,7,40, 255);
                break;
            case Rarity.Legendary:
                inHandPrefab.GetComponent<Image>().color = new Color32(255,189,7, 255);
                break;
            default:
                inHandPrefab.GetComponent<Image>().color = new Color32(255,255,255, 255);
                break;
        }
    }
    
    public void updatePosition(int totalCards) {
        int handWidth = (UIConstants.CardWidth * totalCards) + UIConstants.HandPadding;
        int handLeftBorder = UIConstants.LeftBorder + ((UIConstants.FullHandWidth - handWidth) / 2);
        float cardX = handLeftBorder + (card.positionInHand * (UIConstants.CardWidth + UIConstants.CardPadding)) + (UIConstants.CardPadding / 2);
        card.transform.localPosition = new Vector3(cardX, UIConstants.PlayerHandVerticalOffset, 0);
    }

    public void updateDisplay(int totalCards) {
        if(card.currentlySelected) {
            this.updatePosition(totalCards);
            card.transform.parent = card.selectedBoardSpace.boardSpaceObject.transform;
            card.CardObject.transform.localScale = new Vector3(UIConstants.SelectedCardOnBoardSize, UIConstants.SelectedCardOnBoardSize, UIConstants.SelectedCardOnBoardSize);
            card.CardObject.transform.localPosition = new Vector3(0, 0, UIConstants.SelectedCardOnBoardZOffset);
            card.CardObject.transform.localRotation = Quaternion.identity;
        }
        else if(card.currentlyHovered) {
            this.updatePosition(totalCards);
            card.transform.localScale = new Vector3(UIConstants.CardInHandHoveredSize, UIConstants.CardInHandHoveredSize, UIConstants.CardInHandHoveredSize);
        }
        else {
            card.transform.localScale = new Vector3(UIConstants.CardInHandDefaultSize, UIConstants.CardInHandDefaultSize, UIConstants.CardInHandDefaultSize);
            this.updatePosition(totalCards);
        }
    }

}
