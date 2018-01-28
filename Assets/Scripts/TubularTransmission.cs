using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TubularTransmission : MonoBehaviour {

	SpriteRenderer spriteRen;

	AudioSource [] allSnippets;
	AudioSource firstSnippet;
	AudioSource secondSnippet;
	AudioSource thirdSnippet;

	private int highPitch = 3;
	private int lowPitch = -3;
	private int notNormalPitch = 2;
	private Transform currentTransform;


	private bool playMusicOn1;
	private bool playMusicOn2;
	private bool playMusicOn3;

	private int pitchsnippetA;
	private int pitchsnippetB;
	private int pitchsnippetC;

	public static bool mixTapeOn;
	public GameObject mixer;
	public GameObject pointer;
	private GameObject pointerClone;


	private int location;
	private int verticalLocation;

	void Awake () {
		location = 1;
		verticalLocation = 1;
		mixTapeOn = false;
		allSnippets = GetComponents<AudioSource> ();
		firstSnippet = allSnippets [0];
		secondSnippet = allSnippets [1];
		thirdSnippet = allSnippets [2];
	}

	// Use this for initialization
	void Start () {
		mixer.SetActive (false);
		spriteRen = GetComponent <SpriteRenderer> ();
		firstSnippet.pitch = highPitch;
		secondSnippet.pitch = lowPitch;
		thirdSnippet.pitch = notNormalPitch;

	}
	
	// Update is called once per frame
	void Update () {
		if (mixTapeOn) {
			if (Input.GetKeyDown (KeyCode.UpArrow) && location != 4) {
				//arrowUP
				verticalLocation--;
				if (verticalLocation <= 0) {
					verticalLocation = 3;
				}
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow) && location != 4) {
				//ArrowDown
				verticalLocation++;
				if (verticalLocation >= 4) {
					verticalLocation = 1;
				}
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				//Change cassette
				//ArrowRight
				location ++;
				if (location >= 5) {
					location = 1;
				}
			}
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				//Change Cassette
				//ArrowLeft
				location --;
				if (location <= 0) {
					location = 3;
				}
			}
			if (Input.GetKeyDown ("a")) {
				Debug.Log ("something");
				pointerClone.transform.parent.GetComponent <Button>().onClick.Invoke ();
			}

			MovePointer ();
		}

	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			CheckCassettes (PlayerSC.CassetteCount);
			coll.gameObject.GetComponentInChildren <WalkManSc>().StopJam();
		}
	}


	void MovePointer() {
		switch (location) {
		case 4:
			pointerClone.transform.SetParent (mixer.transform.GetChild (4).transform.GetChild (0));
			pointerClone.transform.localPosition = new Vector3 (-110, -10, 0);
			//check button
			break;
		case 3:
			playMusicOn1 = true;
			playMusicOn2 = false;
			playMusicOn3 = false;
			pointerClone.transform.SetParent (mixer.transform.GetChild (3).transform.GetChild (1));
			pointerClone.transform.localPosition = new Vector3 (-110, -10, 0);
			firstSnippet.Pause ();
			secondSnippet.Pause ();
			thirdSnippet.loop = true;
			if (playMusicOn1 && thirdSnippet.isPlaying == false) {
				thirdSnippet.Play ();				
			}
			else if (!playMusicOn1 && thirdSnippet.isPlaying == true) {
				thirdSnippet.Pause ();
			}

			//third snippet
			break;
		case 2:
			playMusicOn1 = false;
			playMusicOn2 = true;
			playMusicOn3 = false;
			pointerClone.transform.SetParent (mixer.transform.GetChild (2).transform.GetChild (1));
			pointerClone.transform.localPosition = new Vector3 (-110, -10, 0);
			firstSnippet.Pause ();
			thirdSnippet.Pause ();
			secondSnippet.loop = true;
			if (playMusicOn2 && secondSnippet.isPlaying == false) {
				secondSnippet.Play ();
			}else if (!playMusicOn2 && secondSnippet.isPlaying == true) {
				secondSnippet.Pause ();
			}
			// second snippet
			break;
		case 1:
			playMusicOn1 = false;
			playMusicOn2 = false;
			playMusicOn3 = true;
			pointerClone.transform.SetParent (mixer.transform.GetChild (1).transform.GetChild (1));
			pointerClone.transform.localPosition = new Vector3 (-110, -10, 0);
			secondSnippet.Pause ();
			thirdSnippet.Pause ();
			firstSnippet.loop = true;
			if (playMusicOn3 && firstSnippet.isPlaying == false) {
				firstSnippet.Play ();	
			}else if (!playMusicOn3 && firstSnippet.isPlaying == true) {
				firstSnippet.Pause ();
			}

			//pointer first column
			//play firs snippet
			break;

		default :
			pointerClone.transform.SetParent (mixer.transform.GetChild (1).transform.GetChild (1)); 
			break;
		}

		switch (verticalLocation) {
		case 3:
			currentTransform = pointerClone.transform.parent.parent;
			pointerClone.transform.SetParent (currentTransform.GetChild (3));
			pointerClone.transform.localPosition = new Vector3 (- 110, -10, 0);
			// pointer bottom
			break;
		case 2:
			currentTransform =  pointerClone.transform.parent.parent;
			pointerClone.transform.SetParent (currentTransform.GetChild (2));
			pointerClone.transform.localPosition = new Vector3 (- 110, -10, 0);
			// pointer middle
			break;
		case 1:
			currentTransform =  pointerClone.transform.parent.parent;
			pointerClone.transform.SetParent (currentTransform.GetChild (1));
			pointerClone.transform.localPosition = new Vector3 (- 110, -10, 0);
			// pointer beginnig
			break;
		default:
			break;
		}
	}
		
	void CheckCassettes(int cassettes) {
		switch (cassettes) {
		case 3:
			MixTape ();
			Debug.Log ("3");
			break;
		case 2:
			Debug.Log ("2");
			break;
		case 1:
			
			Debug.Log ("1");
			break;
		default: 
			Debug.Log ("0");
			break;
		}
	}

	void MixTape(){
		mixTapeOn = true;
		mixer.SetActive (true);
		pointerClone = Instantiate (pointer,mixer.transform.GetChild (1).transform.GetChild (1));
		pointerClone.transform.localPosition = new Vector3 (- 110, -7, 0);

	}

	public void CreateMixtape() {
		if (firstSnippet.pitch == 1 && secondSnippet.pitch ==1 && thirdSnippet.pitch == 1) { // if the 3 snippets have pitch == 1; send message!
			GameControl.playerWin ();
			Debug.Log("You won!!!!!!");
		} else {
			Debug.Log ("Try Again!!!!");
		}
	}

	public void ColumnAHigh () {
		pitchsnippetA = 3;
		firstSnippet.pitch = pitchsnippetA;
	}
	public void ColumnAMedium () {
		pitchsnippetA = 2;
		firstSnippet.pitch = pitchsnippetA;
	}
	public void ColumnALow () {
		pitchsnippetA = 1;
		firstSnippet.pitch = pitchsnippetA;
	}
	public void ColumnBHigh () {
		pitchsnippetB = 2;
	secondSnippet.pitch = pitchsnippetB;
	}
	public void ColumnBMedium () {
		pitchsnippetB = 1;
		secondSnippet.pitch = pitchsnippetB;
	}
	public void ColumnBLow () {
		pitchsnippetB = -2;
		secondSnippet.pitch = pitchsnippetB;
	}
	public void ColumnCHigh () {
		pitchsnippetC = 1;
		thirdSnippet.pitch = pitchsnippetC;
	}
	public void ColumnCMedium () {
		pitchsnippetC = -1;
		thirdSnippet.pitch = pitchsnippetC;
	}
	public void ColumnCLow () {
		pitchsnippetC = -2;
		thirdSnippet.pitch = pitchsnippetC;
	}


}
