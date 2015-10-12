using UnityEngine;
using System.Collections;

public class Guide : MonoBehaviour {

	public SerialEuler ship;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = ship.direction;
	}
}
