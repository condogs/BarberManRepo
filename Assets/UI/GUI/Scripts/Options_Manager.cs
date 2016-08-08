using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options_Manager : MonoBehaviour {

	public GameObject audioOn;
	public GameObject audioOff;

	public bool audio = true;

	// Use this for initialization
	void Start () 
	{
		audioOn.SetActive (true);
		audioOff.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (audio) 
		{
			audioOff.SetActive (false);
			audioOn.SetActive (true);
		}

		if (!audio) 
		{
			audioOff.SetActive (true);
			audioOn.SetActive (false);
		}
	}

	public void AudioPressed ()
	{
		audio = !audio;
	}

	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
