using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private float gameSpeed = 1f;
	public float score;
	public bool spawnboss = false;
	public bool bossSpawned = false;
	public Transform target;
	
	public void SetScore(float setScore, int wl) {

		if (wl == 1) {
			score += setScore;
			Debug.Log (score);
		}
		if (wl == 0) {
			score -= setScore;
			Debug.Log (score);
		}
		if (score < 0) {
			score = 0;
		}
	}

	void Update(){
		if (score >= 500) {
			if (bossSpawned){
				spawnboss = false;
			}
			else{
				spawnboss = true;
			}
	
		}
	}
	void OnGUI(){
		Vector3 getPixelPos = Camera.main.WorldToScreenPoint (target.position);
		getPixelPos.y = Screen.height - getPixelPos.y;
		GUI.Label (new Rect (getPixelPos.x, getPixelPos.y, 200f, 100f), "" + score + "");
		//GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 20f, 200f, 100f), "A: " + option1);
		//GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 40f, 200f, 100f), "S: " + option2);
		//GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 60f, 200f, 100f), "D: " + option3);
	}
}
