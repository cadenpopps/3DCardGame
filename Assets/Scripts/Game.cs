using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Turn {
    Player,
    CPU
};

public enum GameState {
    GameSetup,
    Running,
    Paused
};


public class Game : MonoBehaviour
{

    Player player;
    // CPU cpu;
    Board board;
    Turn turn;
    GameState gameState = GameState.GameSetup;


    void Start() {
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        // cpu = GameObject.Find("CPU").gameObject.GetComponent<cpu>();
        board = GameObject.Find("Board").gameObject.GetComponent<Board>();
        this.init();
    }

    void init() {
        player.init();
        // cpu.init();
        board.init();

        turn = Turn.Player;
        gameState = GameState.Running;
        this.run();
    }

    void run() {



    }

    void Update() {
        if(gameState == GameState.Running){
            if(this.turn == Turn.Player){
                   if(Input.GetKeyDown(KeyCode.Alpha1)){
                        player.playCard(1, board);
                   }
                   else if(Input.GetKeyDown(KeyCode.Alpha2)){
                        player.playCard(2, board);
                   }
                    else if(Input.GetKeyDown(KeyCode.Alpha3)){
                        player.playCard(3, board);
                   }
                    else if(Input.GetKeyDown(KeyCode.Alpha4)){
                        player.playCard(4, board);
                   }
                    else if(Input.GetKeyDown(KeyCode.Alpha5)){
                        player.playCard(5, board);
                   }
                   else if(Input.GetKeyDown(KeyCode.Alpha6)){
                        player.playCard(6, board);
                   }
                   else if(Input.GetKeyDown(KeyCode.Q)){
                        Debug.Log("Drawing top");
                        player.printHand();
                   }
            }
        }
    }

}

//     public static readonly int MaxPlayers = 2;
// 	private static readonly System.Text.RegularExpressions.Regex NumRegex = new System.Text.RegularExpressions.Regex(@"^[0-9]$");

// 	public enum GameMode {
// 		CPU,
// 		VS
// 	};

// 	public enum TurnCode {
// 		EndTurn,
// 		Restart,
// 		Start,
// 		Continue,
// 		EndGame
// 	};

// 	private Player[] players;
// 	private Board board;
// 	private bool running;
// 	private GameMode mode;

//     void Start()
//     {
//         mode = GameMode.CPU;
//         init();
//        // GameObject bo1 = GameObject.Find("Board").gameObject;
//         //Board bo2 = GameObject.Find("Board").gameObject.GetComponent<Board>();

//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void init() {
// 		players = new Player[MaxPlayers];
// 		players[0] = GameSetup.createPlayer(Config.PlayerType.Player1);
// 		if(mode == GameMode.CPU) {
// 			players[1] = GameSetup.createPlayer(Config.PlayerType.CPU);
// 		}
// 		else if(mode == GameMode.VS) {
// 			players[1] = GameSetup.createPlayer(Config.PlayerType.Player2);
// 		}
// 		board = GameObject.Find("Board").gameObject.GetComponent<Board>();
//         board.init();
//         Debug.Log(players[0].hand.cards[0]);
// 		running = true;
// 		// run();
// 	}

// 	private void unpause() {

// 	}

// 	private void pause() {

// 	}

// 	private void run() {
// 		if(running) {
// 			players[0].mana += 3;
// 			players[1].mana += 3;
// 			printGameArea();
// 			TurnCode code = TurnCode.Start;
// 			while(code == TurnCode.Start || code == TurnCode.Restart || code == TurnCode.Continue) {
// 				if(code == TurnCode.Restart) {
// 					printGameArea();
// 				}
// 				else if(code == TurnCode.Continue) {
// 					printGameArea();
// 					// Debug.Log("Remaining mana: {0}", players[0].mana);
// 				}
// 				code = turn(players[0]);
// 			}
// 			if(code == TurnCode.EndGame) {
// 				return;
// 			}
// 			printGameArea();
// 			Debug.Log("CPU's Turn");
// 			TurnCode CPUCode = TurnCode.Start;
// 			while(CPUCode == TurnCode.Start || CPUCode == TurnCode.Continue) {
// 				printGameArea();
// 				CPUCode = CPUTurn(players[1]);
// 			}
// 			/* runBoardLogic(players); */
// 			run();
// 		}
// 	}

// 	private void printGameArea() {
// 		players[1].print(true);
// 		board.print();
// 		players[0].print(false);
// 	}

// 	private TurnCode CPUTurn(Player player) {
// 		System.Random rng = new System.Random();
// 		int cardIndex = rng.Next(Hand.HandSize);
// 		while(player.hand.cards[cardIndex] == null) {
// 			cardIndex = rng.Next(Hand.HandSize);
// 		}
// 		Card selectedCard = player.hand.cards[cardIndex];
// 		// Debug.Log("CPU selected Card number {0}: ", (cardIndex + 1));
// 		selectedCard.print();
// 		// System.Threading.Thread.Sleep(1000);

// 		int colIndex = rng.Next(Board.BoardWidth);
// 		while(!board.placeCard(selectedCard, 0, colIndex)) {
// 			colIndex = rng.Next(Board.BoardWidth);
// 		}
// 		Debug.Log("CPU Placed ");
// 		selectedCard.print();
// 		// Debug.Log(" in row 1, column {0}", (colIndex + 1));
// 		player.removeCardFromHand(cardIndex);
// 		player.mana -= selectedCard.manaCost;
// 		if(player.mana > 0) {
// 			// System.Threading.Thread.Sleep(200);
// 			return TurnCode.Continue;
// 		}
// 		else {
// 			Debug.Log("CPU ended their turn. Press any key to continue to next round.");
// 			// System.Console.Read();
// 			return TurnCode.EndTurn;
// 		}
// 	}

// 	private TurnCode turn(Player player) {
// 		Debug.Log("It is your turn, please select a command and press enter.");
// 		Debug.Log("(Select h for help)");
// 		// string move = System.Console.ReadLine();
//         string move = "e";
// 		switch(move) {
// 			case "n":
// 				this.init();
// 				break;
// 			case "1": case "2": case"3": case "4": case "5":
// 				Card selectedCard = player.hand.cards[System.Int32.Parse(move) - 1];
// 				// Debug.Log("Selected Card number {0}: ", move);
// 				selectedCard.print();
// 				string col = "-1";
// 				int selectedCol = -1;
// 				while(selectedCol < 0 || selectedCol >= Board.BoardWidth) {
// 					// Debug.Log("Select column [1-{0}], select x to cancel: ", Board.BoardWidth);
// 					// col = System.Console.ReadLine();
// 					if(col == "x") {
// 						Debug.Log("Cancelling card placement");
// 						return TurnCode.Restart;
// 					}
// 					selectedCol = System.Int32.Parse(col) - 1;
// 					if(selectedCol < 0 || selectedCol >= Board.BoardWidth) {
// 						// Debug.Log("Selected column {0} is out of range or unrecognized.", col);
// 					}
// 				}
// 				Debug.Log("Placing ");
// 				selectedCard.print();
// 				// Debug.Log(" in row 1, column {0}", col);
// 				bool success = board.placeCard(selectedCard, 1, selectedCol);
// 				if(success) {
// 					player.removeCardFromHand(System.Int32.Parse(move) - 1);
// 					player.mana -= selectedCard.manaCost;
// 					// System.Threading.Thread.Sleep(500);
// 					if(player.mana > 0) {
// 						return TurnCode.Continue;
// 					}
// 					else {
// 						Debug.Log("Out of mana. Press any key to end your turn.");
// 						// System.Console.Read();
// 						return TurnCode.EndTurn;
// 					}
// 				}
// 				else {
// 					Debug.Log("Board space is occupied.");
// 					// System.Threading.Thread.Sleep(1000);
// 					return TurnCode.Restart;
// 				}
// 			case "e":
// 				// Debug.Log("Ending turn with {0} health and {1} mana.", player.health, player.mana);
// 				// System.Threading.Thread.Sleep(1000);
// 				return TurnCode.EndTurn;
// 			case "x":
// 				running = false;
// 				return TurnCode.EndGame;
// 			default:
// 				// Debug.Log("{0} is not a recognized command.", move);
// 				return TurnCode.Restart;
// 		}
// 		return TurnCode.EndTurn;
// 	}
// }

// public static class GameSetup {
// 	public static Player createPlayer(Config.PlayerType pType) {
// 		string pName;
		
//         GameObject h = null;
//         switch(pType) {
// 			case Config.PlayerType.Player1:
// 				Debug.Log("Enter name for player 1: ");
//                 //board = GameObject.Find("Board").gameObject.GetComponent<Board>();

//                 h = GameObject.Find("PlayerHand").gameObject;
// 				// pName = System.Console.ReadLine();
//                 pName = "vlad";
// 				break;
// 			case Config.PlayerType.Player2:

// 				Debug.Log("Enter name for player 2: ");
// 				// pName = System.Console.ReadLine();
//             pName = "vlad";
// 				break;
// 			case Config.PlayerType.CPU:
//                 h = GameObject.Find("CPUHand").gameObject;

// 				pName = "Final Boss";
// 				break;
// 			default:
// 				pName = "Default";
// 				break;
// 		}
// 		Player p = new Player(pType, pName);
		
//         if(h != null){
//             Hand pHand = createHand(p,h);  
//             Deck pDeck = createDeck(p,h);
//             p.initPlayer(pHand, pDeck, 10, 2);
//         }
//         else
//             Debug.Log("didnt find");
//         return p;
// 	}

// 	private static Hand createHand(Player owner, GameObject h) {
// 		Hand hand = h.AddComponent<Hand>();
// 		System.Random rng = new System.Random();
// 		var values = System.Enum.GetValues(typeof(Config.CardID));
// 		for(int i = 0; i < Hand.HandSize; i++) {
// 			hand.cards[i] = CardFactory.CreateCard((Config.CardID) values.GetValue(rng.Next(values.Length - 1)), owner);
// 		}
// 		return hand;
// 	}

// 	private static Deck createDeck(Player owner, GameObject h) {
// 		Deck deck = h.AddComponent<Deck>();
// 		System.Random rng = new System.Random();
// 		var values = System.Enum.GetValues(typeof(Config.CardID));
// 		for(int i = 0; i < Deck.DeckSize; i++) {
// 			deck.cards[i] = CardFactory.CreateCard((Config.CardID) values.GetValue(rng.Next(values.Length - 1)), owner);
// 		}
// 		return deck;
// 	}

// }


// public class CardFactory {
// 	public static Card CreateCard(Config.CardID id, Player owner) {
// 		switch(id) {
// 			case Config.CardID.Jinx:
// 				return new Jinx(owner, Config.CardConfigs[Config.CardID.Jinx]);
// 			case Config.CardID.Tristana:
// 				return new Tristana(owner, Config.CardConfigs[Config.CardID.Tristana]);
// 			case Config.CardID.Caitlyn:
// 				return new Caitlyn(owner, Config.CardConfigs[Config.CardID.Caitlyn]);
// 			case Config.CardID.Samira:
// 				return new Samira(owner, Config.CardConfigs[Config.CardID.Samira]);
// 			case Config.CardID.Xayah:
// 				return new Xayah(owner, Config.CardConfigs[Config.CardID.Xayah]);
// 			case Config.CardID.Ashe:
// 				return new Ashe(owner, Config.CardConfigs[Config.CardID.Ashe]);
// 			case Config.CardID.Vayne:
// 				return new Vayne(owner, Config.CardConfigs[Config.CardID.Vayne]);
// 			default:
// 				return new Card(owner, Config.CardConfigs[Config.CardID.Default]);
// 		}
// 	}
// }

// public static class Config
// {
//     public static readonly int NumberOfCards = 8;

// 	public struct CardConfig {
// 		public int health;
// 		public int attack;
// 		public int manaCost;
// 		public CardConfig(int h, int a, int m) {
// 			health = h;
// 			attack = a;
// 			manaCost = m;
// 		}
// 	}

// 	public enum PlayerType {
// 		Player1,
// 		Player2,
// 		CPU
// 	};

// 	public enum Rarity {
// 		Common,
// 		Rare,
// 		Epic,
// 		Legendary
// 	};

// 	public enum CardID {
// 		Jinx,
// 		Tristana,
// 		Caitlyn,
// 		Samira,
// 		Xayah,
// 		Ashe,
// 		Vayne,
// 		Default
// 	};

// 	public static System.Collections.Generic.Dictionary<CardID, CardConfig> CardConfigs = new System.Collections.Generic.Dictionary<CardID, CardConfig>(){
// 		{CardID.Jinx, new CardConfig(1, 2, 1)},
// 			{CardID.Tristana, new CardConfig(2, 1, 1)},
// 			{CardID.Caitlyn, new CardConfig(1, 3, 2)},
// 			{CardID.Samira, new CardConfig(2, 2, 2)},
// 			{CardID.Xayah, new CardConfig(2, 3, 2)},
// 			{CardID.Ashe, new CardConfig(3, 2, 2)},
// 			{CardID.Vayne, new CardConfig(2, 4, 3)},
// 			{CardID.Default, new CardConfig(1, 2, 1)},
// 	};
// }