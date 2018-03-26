using UnityEngine;
using System.Collections;
using System.Xml;

public class xmltest : MonoBehaviour {
	bool hit = false;

	void Start () {
		var doc = new XmlDocument(); // create an empty doc
		doc.Load("Assets/Resources/questions.xml");
		//var baseNode = doc.DocumentElement;// load the doc, dbPath is a string
		// Use this for initialization
		var number = Random.Range (1, 5);
		XmlNodeList xnList = doc.SelectNodes("/Questions/Question[@id='"+number+"' and @type='sp']");
		while (!hit){
		if (xnList.Count == 0) {
		number = Random.Range (1, 5);
		xnList = doc.SelectNodes("/Questions/Question[@id='"+number+"' and @type='sp']");
		} else {
				hit = true;
			}
		if (hit) {
			foreach (XmlNode node in xnList) {
				Debug.Log (node.Name);
				Debug.Log (node.SelectSingleNode ("text").InnerText);
				Debug.Log (node.SelectSingleNode ("option1").InnerText);
				Debug.Log (node.SelectSingleNode ("option2").InnerText);
				Debug.Log (node.SelectSingleNode ("option3").InnerText);
				Debug.Log (node.SelectSingleNode ("answer").InnerText);
		}
		}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
