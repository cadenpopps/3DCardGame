using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static int CardDatabaseSize = 10;
    public static List<Card> cardList = new List<Card>();
    
    void Awake(){
        cardList.Add(new Card(0, 1, "Gragas", 1, 1, 1, "CardFront"));
        cardList.Add(new Card(1, 1, "Jinx", 3, 1, 2, "CardFront"));
        cardList.Add(new Card(2, 2, "Lux", 3, 2, 2, "CardFront"));
        cardList.Add(new Card(3, 3, "Darius", 2, 4, 3, "CardFront"));
        cardList.Add(new Card(4, 3, "Vladimir", 4, 4, 4, "CardFront"));
        cardList.Add(new Card(5, 3, "Vladimir1", 4, 4, 4, "CardFront"));
        cardList.Add(new Card(6, 3, "Vladimir2", 4, 4, 4, "CardFront"));
        cardList.Add(new Card(7, 3, "Vladimir3", 4, 4, 4, "CardFront"));
        cardList.Add(new Card(8, 3, "Vladimir4", 4, 4, 4, "CardFront"));
        cardList.Add(new Card(9, 3, "Vladimir5", 4, 4, 4, "CardFront"));
    }

}
