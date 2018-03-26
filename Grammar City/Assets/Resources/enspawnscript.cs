using UnityEngine;
using System.Collections;

public class enspawnscript : MonoBehaviour {
	public GameObject gameMaster;
	public GameObject Player;
	public Transform enSpawnPoint;
	public GameObject enemy;
	//bool spawn = true;
	playerwalk pw;

	// Use this for initialization
	void Start () {
		pw = Player.GetComponent<playerwalk>();
		Debug.Log (pw.respawn);
	}

	void Update()
	{
		if (pw.respawn) {
			Spawn();
		}

	}


	void Spawn()
	{
		GameObject sphere = Instantiate(enemy, enSpawnPoint.position, enSpawnPoint.rotation) as GameObject;
		aiquest aiQuest = sphere.GetComponent<aiquest>();
		aiQuest.GM = gameMaster;
		aiQuest.PW = Player;
	}
}
