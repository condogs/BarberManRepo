using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions_Manager : MonoBehaviour {

	public GameObject textObjectives;
	public GameObject textPlayerControls;
	public GameObject textEnemies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ObjectivesClicked ()
	{
		textObjectives.SetActive (true);
		textPlayerControls.SetActive (false);
		textEnemies.SetActive (false);
	}

	public void PlayerControlsClicked ()
	{
		textObjectives.SetActive (false);
		textPlayerControls.SetActive (true);
		textEnemies.SetActive (false);
	}

	public void EnemiesClicked ()
	{
		textObjectives.SetActive (false);
		textPlayerControls.SetActive (false);
		textEnemies.SetActive (true);
	}

	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
