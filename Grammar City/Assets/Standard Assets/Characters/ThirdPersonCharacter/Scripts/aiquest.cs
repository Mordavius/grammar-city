using UnityEngine;
using System.Collections;
using System.Xml;

public class aiquest : MonoBehaviour {

	public GameObject GM;
	public GameObject PW;
	private playerwalk playerWalk;
	private GameMaster gameMaster;
	[SerializeField]
	TextAsset questions;
	public Transform target;
	bool engaged = false;
	bool hit = false;
	int number;
	string question;
	string option1;
	string option2;
	string option3;
	string answer;
	string attempt;
	bool tick = false;

	void Start () {
		gameMaster = GM.GetComponent<GameMaster> ();
		playerWalk = PW.GetComponent<playerwalk> ();
		playerWalk.respawn = false;
		number = Random.Range (1, 5);
		XmlDocument doc = new XmlDocument (); // create an empty doc
		doc.LoadXml (questions.text);
		XmlNodeList xnList = doc.SelectNodes ("/Questions/Question[@id='" + number + "' and @type='sp']");
		var baseNode = doc.DocumentElement;// load the doc, dbPath is a string
		// Use this for initialization
		// Use this for initialization
		while (!hit) {
			if (xnList.Count == 0) {
				number = Random.Range (1, 5);
				xnList = doc.SelectNodes ("/Questions/Question[@id='" + number + "' and @type='sp']");
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
	}
	
	// Update is called once per frame
	void Update () {
		if (engaged) {
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
				gameMaster.SetScore (50f, 1);
				tick = false;
				Destroy (this.gameObject);
				Time.timeScale = 1;
				
			}
			if (answer != attempt) {
				gameMaster.SetScore (40f, 0);
				tick = false;
				Destroy (this.gameObject);
				Time.timeScale = 1;
			}
		}
	}
}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player") == true) {
			engaged = true;
			Time.timeScale = 0f;
		}
	}



	void OnGUI(){
			if (engaged) {
			Vector3 getPixelPos = Camera.main.WorldToScreenPoint (target.position);
			getPixelPos.y = Screen.height - getPixelPos.y;
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y - 15f, 200f, 100f), question);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y , 200f, 100f), "A: " + option1);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 15f, 200f, 100f), "S: " + option2);
			GUI.Label (new Rect (getPixelPos.x, getPixelPos.y + 30f, 200f, 100f), "D: " + option3);
		}
	}
}

