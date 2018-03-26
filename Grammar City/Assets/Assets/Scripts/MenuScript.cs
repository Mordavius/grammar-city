using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas submenu;
    public Button Option1;
    public Button Option5;
    

	// Use this for initialization
	void Start () {
        submenu = submenu.GetComponent<Canvas>();
        Option1 = Option1.GetComponent<Button>();
        Option5 = Option5.GetComponent<Button>();
		submenu.enabled = false;
	}

    public void ExitPress() {
        submenu.enabled = true;
    }

    public void NoPress() {
        submenu.enabled = false;
    }

    public void StartLevel() {
        Application.LoadLevel(1);
    }

    public void QuitGame() {
        Application.Quit ();
    }



	
	// Update is called once per frame
	void Update () {
	
	}
}
