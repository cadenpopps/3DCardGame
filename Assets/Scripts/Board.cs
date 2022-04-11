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
			selectedBoardSpace.cardReference = card;
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

	public BoardSpace getFirstAvailableSpacePlayer() {
		for(int col = 0; col < BoardWidth; col++) {
			if(!spaces[0, col].occupied) {
				return spaces[0, col];
			}
		}
		return null;
	}

    void Update()
    { }
}
