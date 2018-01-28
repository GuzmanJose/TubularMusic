using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetteSC : MonoBehaviour {

	private float staticSound;
	private float music;
	private Vector3 currentPosition;
	private bool isCassette;

	public static int cassetteCountTotal;
	public float distanceMagnitude;
	public static float volume;
	public GameObject player;
	public string song;
	public string powerUp;

	// Use this for initialization
	void Start () {
		CassetteCount ();
		currentPosition = transform.position;
		staticSound = GetComponent <SpriteRenderer> ().bounds.size.x * 75;
		music = GetComponent <SpriteRenderer> ().bounds.size.x * 40;
	}
	
	// Update is called once per frame
	void Update () {
		distanceMagnitude = Vector3.Distance (currentPosition, player.transform.position);
		volume =  Vector3.Distance (currentPosition, player.transform.position);


		if (distanceMagnitude <= staticSound && distanceMagnitude >= music -1.5f) {
			Debug.Log ("Static Sound!!" + staticSound);
			player.GetComponentInChildren <WalkManSc> ().staticOn = true;
			player.GetComponentInChildren <WalkManSc> ().PickingUpSingal(song);
		} else if(distanceMagnitude >= staticSound || distanceMagnitude <= music){
			player.GetComponentInChildren <WalkManSc> ().staticOn = false;
		}
		if (distanceMagnitude <= music + .5f) {
			player.GetComponentInChildren <WalkManSc> ().musicOn = true;
			player.GetComponentInChildren <WalkManSc> ().PickingUpSingal(song);
		} else if (distanceMagnitude >= music){
			player.GetComponentInChildren <WalkManSc> ().musicOn = false;
		} if (distanceMagnitude >= staticSound) {
			player.GetComponentInChildren <WalkManSc> ().PickingUpSingal(song);
		}
			

	}

	public void CassetteCount() {
		isCassette = (this.tag == "Cassette");
		if (isCassette) {
			cassetteCountTotal++;
		}
	}

}
