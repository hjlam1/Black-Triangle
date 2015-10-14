using UnityEngine;
using System.Collections;

public class NewRing : MonoBehaviour {

	public GameObject redRing;
	public GameObject blueRing;
	public GameObject greenRing;
	public int score;
	public int rings = 1;
	public int rndColor;
	public TextMesh scoreCard;

	// Use this for initialization
	void Start () {
		rndColor = 0;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreCard.text = "Score: " + score.ToString();
	}

	void OnTriggerEnter(Collider other) {

		//Debug.Log ("Trigger Enter");
		if (other.tag == "Center") {
			score++;
			Debug.Log (score);
			if (!this.GetComponent<AudioSource>().isPlaying) {
				this.GetComponent<AudioSource>().Play();
			}
		}

	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Wall") {
			float interval = 30.0f;
			
			Debug.Log ("New Ring");
			rndColor = Random.Range (0,3);
			float randomX = Random.Range (-10.0f, 10.0f);
			float randomY = Random.Range (-5.0f, 10.0f);
			
			if (rndColor == 0) {
				Instantiate (blueRing, new Vector3( randomX, randomY, interval * rings), Quaternion.Euler (new Vector3(90f,0f,0f)));
			}else if (rndColor == 1) {
				Instantiate (redRing, new Vector3( randomX, randomY, interval * rings), Quaternion.Euler (new Vector3(90f,0f,0f)));
			}else {
				Instantiate (greenRing, new Vector3( randomX, randomY, interval * rings), Quaternion.Euler (new Vector3(90f,0f,0f)));
			}
			
			//Vector3 newPos = new Vector3(0f,0f,30f*rings);
			//Quaternion flatRot = Quaternion.Euler (new Vector3(90f,0f,0f));
			//Instantiate (blueRing, newPos, flatRot);
			//Instantiate (blueRing, new Vector3( 0f, 0f, 30f* rings), Quaternion.Euler (new Vector3(90f,0f,0f)));
			rings++;
		}
	}
}
