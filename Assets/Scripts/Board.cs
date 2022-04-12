using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Board : MonoBehaviour
{

    public static readonly int BoardWidth = 4;
	public static readonly int BoardHeight = 2;

	public BoardSpace[,] spaces;

	public Texture2D tex;

	void Awake() { }

    // Start is called before the first frame update
    void Start() { }

    public void init() {
        spaces = new BoardSpace[BoardHeight, BoardWidth];
		for(int row = 0; row < BoardHeight; row++) {
			for(int col = 0; col < BoardWidth; col++) {
				spaces[row, col] = GameObject.Find("BoardSpace" + ((row * BoardWidth) + col + 1).ToString()).GetComponent<BoardSpace>() as BoardSpace;
				spaces[row, col].init();
			}
		} 
    }
    
    public bool addCard(Card card, BoardSpace selectedBoardSpace) {
		if(!selectedBoardSpace.occupied) {
			selectedBoardSpace.card = card;
			selectedBoardSpace.occupied = true;
			card.CardObject.transform.parent = selectedBoardSpace.boardSpaceObject.transform; 
            card.CardObject.transform.localScale = new Vector3(UIConstants.CardOnBoardSize, UIConstants.CardOnBoardSize, UIConstants.CardOnBoardSize);
            card.CardObject.transform.localPosition = new Vector3(0, 0, 0);
            card.CardObject.transform.localRotation = Quaternion.identity;
			return true;
		}
		else {
			return false;
		}
	}

	public int cardsOnRow(int row) {
		int counter = 0;
		for(int i = 0; i < BoardWidth; i++) {
			if(spaces[row, i].occupied) {
				counter++;
			}
		}
		return counter;
	}
	
	public int getOpenSpaces(int row) {
		int counter = 0;
		for(int i = 0; i < BoardWidth; i++) {
			if(!spaces[row, i].occupied) {
				counter++;
			}
		}
		return counter;
	}
	
	public BoardSpace getFirstAvailableSpace(int row) {
		for(int col = 0; col < BoardWidth; col++) {
			if(!spaces[row, col].occupied) {
				return spaces[row, col];
			}
		}
		return null;
	}

	public int getIndexOfBoardSpace(int row, BoardSpace s) {
		for(int col = 0; col < BoardWidth; col++) {
			if(spaces[row, col] == s) {
				return col;
			}
		}
		return -1;
	}

	public BoardSpace getFirstSpaceLeft(int row, BoardSpace s) {
		int boardSpaceIndex = getIndexOfBoardSpace(row, s);
		if(boardSpaceIndex == -1) {
			Debug.Log("Cannot find the board space referenced by card.");
		}
		else {
			int newIndex = boardSpaceIndex - 1;
			if(newIndex < 0) {
				newIndex = BoardWidth - 1;
			}
			while(spaces[row, newIndex].occupied) {
				newIndex = newIndex - 1;
				if(newIndex < 0) {
					newIndex = BoardWidth - 1;
				}
			}
			return spaces[row, newIndex];
		}
		return null;
	}
	
	public BoardSpace getFirstSpaceRight(int row, BoardSpace s) {
		int boardSpaceIndex = getIndexOfBoardSpace(row, s);
		if(boardSpaceIndex == -1) {
			Debug.Log("Cannot find the board space referenced by card.");
		}
		else {
			int newIndex = boardSpaceIndex + 1;
			if(newIndex >= BoardWidth) {
				newIndex = 0;
			}
			while(spaces[row, newIndex].occupied) {
				newIndex = newIndex + 1;
				if(newIndex >= BoardWidth) {
					newIndex = 0;
				}
			}
			return spaces[row, newIndex];
		}
		return null;
	}

	public void runGameLogic(CPU cpu, Player player) {
		for(int column = 0; column < BoardWidth; column++) {
			BoardSpace CPUBoardSpace = spaces[1, column];
			BoardSpace PlayerBoardSpace = spaces[0, column];
			if(!CPUBoardSpace.occupied && !PlayerBoardSpace.occupied) {
				continue;
			}
			else if(!CPUBoardSpace.occupied) {
				cpu.health -= PlayerBoardSpace.card.attack;
			}
			else if(!PlayerBoardSpace.occupied) {
				player.health -= CPUBoardSpace.card.attack;
			}
			else {
				int[] leftoverDamage = this.battleCards(CPUBoardSpace, PlayerBoardSpace);
				player.health += leftoverDamage[0];
				cpu.health += leftoverDamage[1];
			}

		}

	}

	private int[] battleCards(BoardSpace cpuSpace, BoardSpace playerSpace) {
		Card cpuCard = cpuSpace.card;
		Card playerCard = playerSpace.card;
		int[] sum = {0, 0};
		int cpuHealth = cpuCard.health;
		int cpuAttack = cpuCard.attack;
		int playerHealth = playerCard.health;
		int playerAttack = playerCard.attack;
		sum[0] = playerHealth - cpuAttack;
		sum[1] = cpuHealth - playerAttack;
		if(sum[0] > 0) {
			playerCard.health = sum[0];
			playerCard.cardDisplay.updateDisplay();
		}
		else {
			this.destroy(playerSpace);
		}
		if(sum[1] > 0) {
			cpuCard.health = sum[1];
			cpuCard.cardDisplay.updateDisplay();
		}
		else {
			this.destroy(cpuSpace);
		}
		return sum;
	}

	private void destroy(BoardSpace space) {
		space.occupied = false;
        Destroy(space.card.cardDisplay.inHandPrefab);
		space.card = null;
	}

    void Update()
    { }
}
