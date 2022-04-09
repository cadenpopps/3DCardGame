using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{

    public static readonly int HandSize = 6;

	public Hand hand;

    public void init(Hand handC){
        hand = handC;
        GameObject card1 = new GameObject("card1inhand");
        Text name = card1.AddComponent<Text>();
        name.text = hand.cards[0].name;
    }




}
