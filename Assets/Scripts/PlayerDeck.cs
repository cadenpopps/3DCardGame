using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public int x;
    public int deckSize;


    public GameObject stack;

    // Start is called before the first frame update
    void Start()
    {
        stack = GameObject.Find("PlayerDeck/Cube");
        stack.SetActive(false);
       
    } 

    // Update is called once per frame
    public void init()
    {
       x = 0;
       for(int i = 0; i < 30; i++){
           x = Random.Range(0,4);
           deck[i] = CardDatabase.cardList[1];
       } 

    }
}
