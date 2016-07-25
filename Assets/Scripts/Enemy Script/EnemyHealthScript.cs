using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    int EnemyHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttackZone"))
        {
            EnemyHealth -= 10;
            Debug.Log("Ouch" + EnemyHealth);
        }
        

    }


}
