using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {

    public GameObject pauseMenu;

    // Use this for initialization
	void Start ()
    {
        pauseMenu.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseClicked();
        }
	}

    public void PauseClicked()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive (true);
    }

    public void ResumeClicked()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartClicked()
    {
        // Input code
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MenuClicked()
    {
        // Input code
        Application.LoadLevel("Main_Menu");
    }
}
