using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BoardSpace : MonoBehaviour
{
    public bool occupied;
	public Card card;
	public GameObject boardSpaceObject;

	public void init() {
		occupied = false;
	}
	
	public void reset() {
		occupied = false;
        if (card != null)
        {
            card.CardObject.transform.parent = null;
            Destroy(card.CardObject);
            card = null;
        }
	}
}
