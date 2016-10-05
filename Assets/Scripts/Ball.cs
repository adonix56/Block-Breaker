using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private bool start = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = (this.transform.position - paddle.transform.position);	
	}

	void OnCollisionEnter2D(){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (start) {
			this.rigidbody2D.velocity += tweak;
			audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!start) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		

			if (Input.GetMouseButtonDown (0)) {
				this.rigidbody2D.velocity = new Vector2 (5f, 5f);
				start = true;
			}
		}
	}
}
