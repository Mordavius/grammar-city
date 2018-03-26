using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject Player;
    public bool player_Spawned = false;

	
	void Start () {
	
	}
	
	
	void Update () {
        if (player_Spawned == false) {
            Instantiate(Player, spawnpoint.position, spawnpoint.rotation);
            player_Spawned = true;
        }
        if (GameObject.Find("ThirdPersonController(Clone)") == null)
        {
            player_Spawned = false;
        }
        else
        {
            player_Spawned = true;
        }
	
	}
}
