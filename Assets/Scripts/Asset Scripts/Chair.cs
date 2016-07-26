using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour {

    public Sprite green;
    public Sprite red;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = green;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = red;
        }

	}
}
