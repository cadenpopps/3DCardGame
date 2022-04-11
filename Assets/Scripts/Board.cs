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
	public GameObject[,] physicalSpaces;

	public Texture2D tex;

	void Awake() { }

    // Start is called before the first frame update
    void Start() { }

	public Texture2D LoadTexture(string FilePath) {
		// Load a PNG or JPG file from disk to a Texture2D
		// Returns null if load fails
	
		Texture2D Tex2D;
		byte[] FileData;
	
		if (File.Exists(FilePath)){
		FileData = File.ReadAllBytes(FilePath);
		Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
		if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
			return Tex2D;                 // If data = readable -> return texture
		}  
		return null;                     // Return null if load failed
   	}

    public void init() {
		physicalSpaces = new GameObject[BoardHeight, BoardWidth];

        spaces = new BoardSpace[BoardHeight, BoardWidth];
		for(int row = 0; row < BoardHeight; row++) {
			for(int col = 0; col < BoardWidth; col++) {
				spaces[row, col] = new BoardSpace();
				physicalSpaces[row, col] = GameObject.Find("BoardSpace" + ((row * BoardWidth) + col + 1).ToString());
			}
		} 
    }
    
    public bool addCard(int row, int column, Card card) {
		if(row >= 0 && column >= 0 && row < BoardHeight && column < BoardWidth && !spaces[row, column].occupied) {
			spaces[row, column].cardReference = card;
			spaces[row, column].occupied = true;
			card.CardObject.transform.parent = physicalSpaces[row, column].transform; 
            card.CardObject.transform.localScale = new Vector3(UIConstants.CardOnBoardSize, UIConstants.CardOnBoardSize, UIConstants.CardOnBoardSize);
            card.CardObject.transform.localPosition = new Vector3(0, 0, 0);
            card.CardObject.transform.localRotation = Quaternion.identity;
			return true;
		}
		else {
			return false;
		}
	}

	public int getFirstAvailableSpot() {
		for(int row = 0; row < BoardHeight; row++) {
			for(int col = 0; col < BoardWidth; col++) {
				if(!spaces[row, col].occupied) {
					return (row * BoardWidth) + col;
				}
			}
		}
		return -1;
	}

	public void print() {
		System.Console.WriteLine();
		for(int row = 0; row < BoardHeight; row++) {
			for(int col = 0; col < BoardWidth; col++) {
				System.Console.Write(" ");
				spaces[row, col].print();
			}
			System.Console.WriteLine("\n");
		}
	}

    void Update()
    {
		// for(int row = 0; row < BoardHeight; row++) {
		// 	for(int col = 0; col < BoardWidth; col++) {
		// 		if(physicalSpaces[row, col] != null) {
		// 			physicalSpaces[row,col].cardDisplay.();
		// 		}
		// 	}
		// }
    }
}
