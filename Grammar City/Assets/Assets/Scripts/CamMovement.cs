using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

    Vector3 startPos;
    public float playerSpeed = 1.5f;
    public GameObject Player;
    public GameObject ResPos;
    private spawn spawn;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        spawn = ResPos.GetComponent<spawn>();
	}
	
	void Update () {
	    transform.localPosition += transform.right * playerSpeed * Time.deltaTime;

        if (spawn.player_Spawned == false)
        {
            transform.position = startPos;
        }
	}
}
