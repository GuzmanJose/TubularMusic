using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManSc : MonoBehaviour {

	AudioSource staticSound;
	AudioSource song1;
	AudioSource song2;
	AudioSource song3;
	AudioSource [] allSongs;

	public bool staticOn;
	public bool musicOn;

	private float volume;

	// Use this for initialization
	void Start () {
		allSongs = GetComponents <AudioSource> ();
		staticSound = allSongs[0];
		song1 = allSongs[1];
	}
	
	// Update is called once per frame
	void Update () {
		volume = Mathf.Clamp (CassetteSC.volume, 0f,1f);


	}

	public void PickingUpSingal(string songName) {

		if (staticOn && staticSound.isPlaying == false) {
			staticSound.Play();
		}
		else if (!staticOn && staticSound.isPlaying == true) {
			staticSound.Pause();
		}	
		if (musicOn && song1.isPlaying == false && songName == "song1") {
			song1.Play();
		}
		else if (!musicOn && song1.isPlaying == true) {
			song1.Pause();
		}
//		if (musicOn && song2.isPlaying == false && songName == "song2") {
//			song2.Play();
//		}
//		else if (!musicOn && song2.isPlaying == true) {
//			song2.Pause();
//		}
//		if (musicOn && song3.isPlaying == false && songName == "song3") {
//			song3.Play();
//		}
//		else if (!musicOn && song3.isPlaying == true) {
//			song3.Pause();
//		}
		
	}

	public void PlayJam(string song){
		if (song == "song1") {
			song1.loop = false;
			song1.Play();

		}
	}
	public void StopJam() {
		foreach (var item in allSongs) {
			item.Pause ();
		}
	}

}
