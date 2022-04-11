using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Board : MonoBehaviour
{

    public static readonly int BoardWidth = 4;
	public static readonly int BoardHeight = 2;

	private BoardSpace[,] spaces;
	private GameObject[,] physicalSpaces;

	// public Sprite cardFace;
	// public SpriteRenderer sr;
	public Texture2D tex;

	void Awake() {

	}

    // Start is called before the first frame update
    void Start()
    {

		
		// GameObject img = GameObject.Find("Board_Space1_Image");
		// img.GetComponent<Image>().sprite = cardFace;
		// Debug.Log(physicalSpaces[0, 0].GetComponent<RawImage>().texture);
    	// cardFace = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), 100);

		// cardFace = Resources.Load<Sprite>("Sprites/Gragas_Render.png");

    }

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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void init() {
		physicalSpaces = new GameObject[BoardHeight, BoardWidth];

        spaces = new BoardSpace[BoardHeight, BoardWidth];
		for(int row = 0; row < BoardHeight; row++) {
			for(int col = 0; col < BoardWidth; col++) {
				spaces[row, col] = new BoardSpace();
				physicalSpaces[row, col] = GameObject.Find("Board_Space" + ((row * BoardWidth) + col + 1).ToString());
			}
		} 
    }
    
    public bool placeCard(Card card, int row, int column) {
		if(row < BoardHeight && column < BoardWidth && !spaces[row, column].occupied) {
			spaces[row, column].cardReference = card;
			spaces[row, column].occupied = true;
			// physicalSpaces[row, column].GetComponent<SpriteRenderer>().sprite = card.sprite;
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
}
