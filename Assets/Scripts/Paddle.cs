﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float xmin;
	public float xmax;

	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse() {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(mousePosInBlocks,xmin,xmax), this.transform.position.y, 0f);
		//paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;
	}

	void AutoPlay(){
		Vector3 ballPos = ball.transform.position;
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(ballPos.x,xmin,xmax), this.transform.position.y, 0f);
		//paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
}
