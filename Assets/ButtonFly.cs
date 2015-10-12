using UnityEngine;
using System.Collections;

public class ButtonFly : MonoBehaviour {

	public SerialEuler ship;
	public float speed = 5.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ship.forward0) {


			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
		if (ship.forward1) {

			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
		if (ship.forward2) {

			this.transform.Translate(ship.direction*Vector3.forward*Time.deltaTime*speed);
		}
	}
}
