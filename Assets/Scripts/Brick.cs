using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip Break;
	public GameObject smoke;

	private int timesHit;
	private LevelManager lm;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		lm = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (isBreakable){
			AudioSource.PlayClipAtPoint (Break, transform.position,0.7f);
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			breakableCount--;
			lm.BrickDestroyed();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	// Update is called once per frame
	void Update () {
	}

	//TODO: Remove this method once we can actually win!
	void SimulateWin(){
		lm.LoadNextLevel ();
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
