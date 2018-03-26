using UnityEngine;
using System.Collections;

public class bossspawn : MonoBehaviour {
	public GameObject GM;
	public GameObject Player;
	private GameMaster gameMaster;
	public Transform bossSpawnpoint;
	public GameObject boss;
	public int spawned = 0;
	// Use this for initialization
	void Start () {
		gameMaster = GM.GetComponent<GameMaster> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (gameMaster.spawnboss){
			if (spawned < 1)
			spawnBoss();
			spawned++;
		}
	}

	void spawnBoss(){
		GameObject Boss = Instantiate(boss, bossSpawnpoint.position, bossSpawnpoint.rotation) as GameObject;
		BossQuest bossQuest = Boss.GetComponent<BossQuest>();
		bossQuest.GM = GM;
		bossQuest.Player = Player;
	}
}
