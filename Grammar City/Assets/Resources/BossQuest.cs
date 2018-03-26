using UnityEngine;
using System.Collections;
using System.Xml;

public class BossQuest : MonoBehaviour {
	public Transform target;
	public GameObject GM;
	GameMaster gameMaster;
	public GameObject Player;
	private playerwalk playerWalk;
	int hp = 0;
	int number;
	[SerializeField]
	TextAsset questions;
	bool engaged = false;
	bool hit = false;
	bool next = true;
	bool tick = false;
	string question;
	string option1;
	string option2;
	string option3;
	string answer;
	string attempt;
	XmlDocument doc;
	XmlNodeList xnList;
	XmlNode baseNode;



	// Use this for initialization
	void Start () {
		playerWalk = Player.GetComponent<playerwalk> ();
		gameMaster = GM.GetComponent<GameMaster> ();
		gameMaster.bossSpawned = true;
		number = Random.Range (1, 5);
		doc = new XmlDocument (); // create an empty doc
		doc.LoadXml (questions.text);
		xnList = doc.SelectNodes ("/Questions/Question[@id='" + number + "' and @type='sp']");
		//baseNode = doc.DocumentElement;// load the doc, dbPath is a string
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player") == true) {
			engaged = true;
			playerWalk.playerSpeed = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//while (tries > hp) {
			if (engaged){
			if (next){
				NewQuestion();
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				attempt = option1;
				tick = true;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				attempt = option2;
				tick = true;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				attempt = option3;
				tick = true;
			}
			if(tick){
				if (answer == attempt) {
					gameMaster.SetScore (100f, 1);
					tick = false;
					hp++;
					next = true;
				}
				if (answer != attempt) {
					gameMaster.SetScore (90f, 0);
					tick = false;
					next = true;
				}
			}
			}
		//}
		if (hp == 9) {
			Application.LoadLevel(0);
		}
	}

	void NewQuestion(){
		while (!hit) {
				number = Random.Range (1, 5);
				xnList = doc.SelectNodes ("/Questions/Question[@id='" + number + "' and @type='sp']");
			if (xnList.Count == 0) {
				hit = false;
			} else {
				hit = true;
			}
			if (hit) {
				foreach (XmlNode node in xnList) {
					question = (node.SelectSingleNode ("text").InnerText);
					option1 = (node.SelectSingleNode ("option1").InnerText);
					option2 = (node.SelectSingleNode ("option2").InnerText);
					option3 = (node.SelectSingleNode ("option3").InnerText);
					answer = (node.SelectSingleNode ("answer").InnerText);
				}
			}
		}
		next = false;
		hit = false;
	}

	void OnGUI(){
		if (engaged) {
			Vector3 getPixelPos = Camera.main.WorldToScreenPoint (target.position);
			getPixelPos.y = Screen.height - getPixelPos.y;
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y, 200f, 100f), question);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 20f, 200f, 100f), "A: " + option1);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 40f, 200f, 100f), "S: " + option2);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 60f, 200f, 100f), "D: " + option3);
		}
	}
}
