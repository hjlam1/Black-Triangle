﻿using System;
using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialEuler : MonoBehaviour {

	public float xOffset = 0;
	public float yOffset = 0;
	public float zOffset = 0;
	string serialInput;
	public bool forward0 = false;
	public bool forward1 = false;
	public bool forward2 = false;
	public Quaternion direction;
	public GameObject forwardZero;
	public GameObject forwardOne;
	public GameObject forwardTwo;
	public bool play = false;
	private AudioSource playMusic;
	private AudioSource stageMusic;
	private AudioSource startSound;
	public GameObject startScreen;
	public float stagedTime;
	public bool end = false;
	public TextMesh timeKeeper;
	public float timeToPlay;
	public AudioSource ambience;

	SerialPort stream = new SerialPort("COM3", 9600); //Set the port and the baud rate
	Vector3 inputRotation;
	
	// Use this for initialization
	void Start () {
		timeToPlay = 75.0f;
		AudioSource[] audios = this.GetComponents<AudioSource>();
		playMusic = audios[2];
		stageMusic = audios[1];
		startSound = audios[0];
		//startSound.loop = false;
		try{
//			string[] portList = System.IO.Ports.SerialPort.GetPortNames();
//			for (int x = 0; x < portList.Length; x++) {
//				Debug.Log (portList[x]);
//			}
			//stream = new SerialPort(portList[0], 9600);
			//stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

			StartCoroutine (SerialOperation());
			//Debug.Log ("Open");
		}
		catch(Exception e){
			Debug.Log("Could not open serial port: " + e.Message);
			
		}
		//stream.WriteLine("a");
	}

		// Update is called once per frame
	void Update () {
		if (play) {

			if (!ambience) {
				ambience.Play();
			}
			if (!playMusic.isPlaying) {
				playMusic.Play();
				stageMusic.Stop ();
			}
			float playedTime = Time.timeSinceLevelLoad - stagedTime;
			if (playedTime > timeToPlay) {
				end = true;
				play = false;
				startScreen.GetComponent<MeshRenderer>().enabled = true;
			} else {
				int timeyTime = (int)timeToPlay -(int)playedTime;
				timeKeeper.text = "Time Left: " + timeyTime.ToString();
			}
		} else if (!end) {
			if (!stageMusic.isPlaying) {
				stageMusic.Play();
				playMusic.Stop();
				Debug.Log ("Stage");
			}
		} else {

			if (!stageMusic.isPlaying) {
				Debug.Log ("End");
				stageMusic.Play ();
				playMusic.Stop ();
				ambience.Stop ();
			}
			timeKeeper.text = "Time Left: 0";
		}

	}

	IEnumerator SerialOperation() {


		//bool start = true;
		while(true) {

			forward0 = false;
			forward1 = false;
			forward2 = false;
			stream.Open();
			string serialInput = stream.ReadLine();
			//Debug.Log(serialInput);
		
			string[] strEul= serialInput.Split (',');
			if (strEul.Length > 5) {
//				if (start) {
//					//zOffset = -float.Parse (strEul[3]);
//					start = ! start;
//				}
				if ((strEul[0].Equals ("1")) && (strEul[1].Equals ("1"))) {
					zOffset = 60;
					direction = Quaternion.Euler (new Vector3( forwardTwo.transform.rotation.eulerAngles.x, -forwardTwo.transform.rotation.eulerAngles.z, 0.0f));
					forward2 = true;
				} else if ((strEul[2].Equals ("1")) && (strEul[1].Equals ("1"))) {
					direction = Quaternion.Euler (new Vector3( -float.Parse(strEul[5]), -float.Parse (strEul[4]), 0.0f));
					zOffset = 180;
					forward0 = true;
				} else if ((strEul[0].Equals ("1")) && (strEul[2].Equals ("1"))) {
					direction = Quaternion.Euler (new Vector3( forwardOne.transform.rotation.eulerAngles.x, -forwardOne.transform.rotation.eulerAngles.z, 0.0f));
					zOffset = -60;
					forward1 = true;
				}
				if ((strEul[0].Equals ("1")) && (strEul[1].Equals ("1")) && (strEul[2].Equals ("1"))) {
					forward0 = false;
					forward1 = false;
					forward2 = false;
					//Debug.Log ("All buttons");
					if (!play) {
						if (!startSound.isPlaying) {
							startSound.Play();

							stagedTime = Time.timeSinceLevelLoad;
							Debug.Log ("Start Time: " + stagedTime.ToString());
						}
						startScreen.GetComponent<MeshRenderer>().enabled = false;
						play = true;
					}
					if (end) {
						Application.LoadLevel(0);
					}

				}
				if ((strEul[3] != "") && (strEul[4] != "") && (strEul[5] != "")) {

					//float.Parse(strEul[3])
					inputRotation = new Vector3(float.Parse(strEul[5]),zOffset,-float.Parse (strEul[4]));
					this.transform.rotation = Quaternion.Euler (inputRotation);

				}

			}


			stream.BaseStream.Flush();
			stream.Close ();
			yield return null;


		}
	}


}
