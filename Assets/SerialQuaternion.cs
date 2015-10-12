using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialQuaternion : MonoBehaviour {

	SerialPort stream = new SerialPort("\\\\.\\COM17", 115200); //Set the port and the baud rate
	Quaternion inputRotation;

	// Use this for initialization
	void Start () {
		//stream.Open ();
		//stream.WriteLine("a");
	}
	
	// Update is called once per frame
	void Update () {
		stream.Open ();
		string serialInput = stream.ReadLine();
		Debug.Log (serialInput);
//		string[] strQuat = serialInput.Split (',');
//		if ((strQuat[0] != "") && (strQuat[1] != "") && (strQuat[2] != "") && (strQuat[3] != "")) {
//			inputRotation = new Quaternion(float.Parse(strQuat[0]),float.Parse(strQuat[1]),float.Parse (strQuat[2]), float.Parse(strQuat[3]));
//			this.transform.rotation = inputRotation; //Quaternion.Slerp(this.transform.rotation, inputRotation, Time.deltaTime);
//
//		}
		stream.BaseStream.Flush();
		stream.Close();
	}
}
