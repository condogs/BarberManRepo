using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Chair : MonoBehaviour {

    public Sprite green;
    public Sprite red;
    GameObject Player;
    GameObject Enemy;
    public int currentLevel;
    

    public int AssetState = 0;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = red;
        Enemy = GameObject.Find("Enemy");

        Debug.Log("welcome to level " + currentLevel.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
        if(AssetState == 0)
        {
            GetComponent<SpriteRenderer>().sprite = red;
            
        }
        if (AssetState == 1)
        {
            GetComponent<SpriteRenderer>().sprite = green;
            
        }

        //if Asset state 1, normal amount of enemies

        


    }

    public void MoveToNextLevel()
    {
        int i = currentLevel + 1;
        string s = "Level" + i.ToString();
        Debug.Log("success, moving to " + s);

        SceneManager.LoadScene(s);
    }
}
