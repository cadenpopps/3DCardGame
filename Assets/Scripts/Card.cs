using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
	public int id;
	public int rarity;
	public string name;
	public int health;
	public int attack;
	public int manaCost;
	public Sprite sprite;


	public Card(){}

	public Card(int Id, int Rarity, string Name, int Health, int Attack, int ManaCost, string PathToTexture) {
		id = Id;
		rarity = Rarity;
		name = Name;
		health = Health;
		attack = Attack;
		manaCost = ManaCost;
		sprite = generateSprite(PathToTexture);
	}

	private Sprite generateSprite(string PathToTexture) {
		Texture2D tex = Resources.Load<Texture2D>(PathToTexture);
		Sprite temp = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 800);
		// temp.transform.Rotate(new Vector3(90, 0, 0));
		return temp;
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

