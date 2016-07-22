using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour 
{
	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
