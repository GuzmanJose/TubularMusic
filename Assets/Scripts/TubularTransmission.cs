using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubularTransmission : MonoBehaviour {

	SpriteRenderer spriteRen;



	// Use this for initialization
	void Start () {
		spriteRen = GetComponent <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			CheckCassettes (PlayerSC.CassetteCount);
		}
	}

	void CheckCassettes(int cassettes) {
		switch (cassettes) {
		case 3:

			Debug.Log ("MixTape");
			break;
		case 2:

			break;
		case 1:

			break;
		default: 
			
			break;
		}
	}

	void MixTape(){
		
	}


}
