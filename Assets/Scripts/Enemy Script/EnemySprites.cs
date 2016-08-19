using UnityEngine;
using System.Collections;

public class EnemySprites : MonoBehaviour {

    public Sprite ChosenSprite;
    int SpriteNumber;

    public Sprite BodySprite1;
    public Sprite BodySprite2;
    public Sprite BodySprite3;

    // Use this for initialization
    void Start () {

        SpriteNumber = Random.Range(1, 3);

        if(SpriteNumber == 1)
        {
            ChosenSprite = BodySprite1;
        }
        if (SpriteNumber == 2)
        {
            ChosenSprite = BodySprite2;
        }
        if (SpriteNumber == 3)
        {
            ChosenSprite = BodySprite3;
        }
        GetComponent<SpriteRenderer>().sprite = ChosenSprite;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
