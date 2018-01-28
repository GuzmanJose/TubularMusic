using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.tag == "Player") {
			coll.GetComponent <PlayerSC>().Zombified (1);
			Debug.Log ("You are being Zombified");
		}
	}
}
