using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	private LevelManager levelmanager;

	void Start() {
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D Trig){
	}

	void OnCollisionEnter2D (Collision2D Coll){
		levelmanager.LoadLevel ("Lose");
	}
}
