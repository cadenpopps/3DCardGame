using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class BoardSpace : MonoBehaviour
{
    public bool occupied;
	public Card cardReference;
	public GameObject boardSpaceObject;

	public void init() {
		occupied = false;
	}
}
