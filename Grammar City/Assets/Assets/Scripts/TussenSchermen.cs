using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TussenSchermen : MonoBehaviour {

    public Canvas Screen;
    public Button Continue;

	void Start () {
        Screen = Screen.GetComponent<Canvas>();
        Continue = Continue.GetComponent<Button>();
	
	}
	
    public void Cont()
    {
        Application.LoadLevel(2);
    }
    public void back()
    {
        Application.LoadLevel(0);
    }
}
