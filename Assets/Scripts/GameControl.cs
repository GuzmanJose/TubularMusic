using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {


	public static GameObject won;
	public static GameObject died;
	// Use this for initialization
	void Start () {
		won = GameObject.Find ("Won");
		died = GameObject.Find ("Dead");
		won.SetActive (false);
		died.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public static void PlayerDied () {
		died.SetActive (true);
	}
	void PlayerZombiFied () {
	
	}
	public static void playerWin() {
		won.SetActive (true);
	}
}
