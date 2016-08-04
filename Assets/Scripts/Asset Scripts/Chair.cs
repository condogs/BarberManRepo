using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour {

    public Sprite green;
    public Sprite red;

    GameObject Enemy;

    public int AssetState = 0;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = red;
        Enemy = GameObject.Find("Enemy");
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
}
