using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour {

    public Sprite green;
    public Sprite red;

    public int AssetState = 0;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = red;
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

    }
}
