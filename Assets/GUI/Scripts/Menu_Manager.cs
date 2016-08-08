using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour 
{
	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void QuitPressed ()
	{
		Application.Quit ();
	}
}
