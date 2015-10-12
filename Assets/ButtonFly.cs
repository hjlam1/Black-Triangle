using UnityEngine;
using System.Collections;

public class ButtonFly : MonoBehaviour {

	public SerialEuler ship;
	public float speed = 5.0f;
	public NewRing ringColor;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((ship.forward0) && (ringColor.rndColor == 0)) {
			//Debug.Log ("0 Blue");
			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
		if ((ship.forward1) && (ringColor.rndColor == 1)) {
			//Debug.Log ("1 Red");
			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
		if ((ship.forward2) && (ringColor.rndColor == 2)) {
			//Debug.Log ("2 Green");
			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
	}
}
