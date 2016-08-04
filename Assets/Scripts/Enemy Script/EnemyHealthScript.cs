using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    GameObject Player;

    int EnemyHealth = 100;
    public int EnemyPayment = 30;
    
    // Use this for initialization
    void Start () {

        Player =  GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
        if(EnemyHealth < 0)
        {
            Destroy(gameObject);
        }
        if(Vector3.Distance(Player.transform.position, transform.position) < 10)
        {
            
            //perform attack
            Player.GetComponent<Player2DController>().PlayerHealth -= 0.05f;
            //Debug.Log(Player.GetComponent<Player2DController>().PlayerHealth);

        }
        else
        {
            Player.GetComponent<Player2DController>().PlayerHealth += 0.02f;
        }

	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttackZone"))
        {
            EnemyHealth -= 25;
            Debug.Log("Ouch" + EnemyHealth);
            Player.GetComponent<Player2DController>().PlayerMoney += EnemyPayment;    
        }

    }

    

}
