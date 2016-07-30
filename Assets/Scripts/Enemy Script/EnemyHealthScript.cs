using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    public GameObject Player;
    int EnemyHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(EnemyHealth < 0)
        {
            Destroy(gameObject);
        }

	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttackZone"))
        {
            EnemyHealth -= 25;
            Debug.Log("Ouch" + EnemyHealth);
            Player.GetComponent<Player2DController>().PlayerMoney += 25;
            
        }
        

    }


}
