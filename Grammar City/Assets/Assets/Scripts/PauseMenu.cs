using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public Canvas Pause;
    public Button Main;
    public Button Quit;
    public Button Continue;

	// Use this for initialization
	void Start () {
        Pause = Pause.GetComponent<Canvas>();
        Main = Main.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
        Continue = Continue.GetComponent<Button>();
        Pause.enabled = false;
        
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause.enabled = true;
        }
    }

        public void MainMen() {
            Application.LoadLevel (0);
            Time.timeScale = 1;
        }
        public void ContGame()
        {
            Pause.enabled = false;
            Time.timeScale = 1;
        }
        public void QuitGam()
        {
            Application.Quit();
        }

	}

