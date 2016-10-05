using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//Load a new level
	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}

	//Quit the game
	public void QuitRequest(){
		//Only use on Consoles and Computers!
		//Not on phones,web, or debug!!
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			print ("NEXT LEVEL!");
			LoadNextLevel();
		}
	}
}
