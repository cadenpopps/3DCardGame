using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
	public CardID id;
	public Rarity rarity;
	public string name;
	public int health;
	public int attack;
	public int manaCost;
	
	public int positionInHand;
	public bool currentlyHovered;
	
	public CardDisplay cardDisplay;
	
	public GameObject CardInHandObject;
	public GameObject CardObject;

	public void init(GameObject cardObject, CardID CardId, Rarity Rarity, string Name, int Health, int Attack, int ManaCost) {
		CardObject = cardObject;
		id = CardId;
		rarity = Rarity;
		name = Name;
		health = Health;
		attack = Attack;
		manaCost = ManaCost;

		cardDisplay = CardInHandObject.GetComponent<CardDisplay>() as CardDisplay;
		cardDisplay.init(this);

		// .init(this);
	}
	
	public void enableHandPrefab() {
		cardDisplay.inHandPrefab.SetActive(true); 
	}
	
	public void disableHandPrefab() {
		cardDisplay.inHandPrefab.SetActive(false); 
	}

	public void updatePosition(int pos) {
		positionInHand = pos;
	}

    public void print() {
		Debug.Log(this.name);
	}



}

// public class Jinx : Card {
// 	public Jinx(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Jinx;
// 		rarity = Config.Rarity.Common;
// 		//color = Config.CardColors[rarity];
// 		name = "Jinx";
// 	}
// }

// public class Tristana : Card {
// 	public Tristana(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Tristana;
// 		rarity = Config.Rarity.Common;
// 		//color = Config.CardColors[rarity];
// 		name = "Tristana";
// 	}
// }

// public class Caitlyn : Card {
// 	public Caitlyn(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Caitlyn;
// 		rarity = Config.Rarity.Common;
// 		//color = Config.CardColors[rarity];
// 		name = "Caitlyn";
// 	}
// }

// public class Samira : Card {
// 	public Samira(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Samira;
// 		rarity = Config.Rarity.Rare;
// 		//color = Config.CardColors[rarity];
// 		name = "Samira";
// 	}
// }

// public class Xayah : Card {
// 	public Xayah(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Xayah;
// 		rarity = Config.Rarity.Epic;
// 		//color = Config.CardColors[rarity];
// 		name = "Xayah";
// 	}
// }

// public class Ashe : Card {
// 	public Ashe(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Ashe;
// 		rarity = Config.Rarity.Epic;
// 		//color = Config.CardColors[rarity];
// 		name = "Ashe";
// 	}
// }

// public class Vayne : Card {
// 	public Vayne(Player owner, Config.CardConfig config) : base(owner, config) {
// 		id = Config.CardID.Vayne;
// 		rarity = Config.Rarity.Legendary;
// 		//color = Config.CardColors[rarity];
// 		name = "Vayne";
// 	}
// }

