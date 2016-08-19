using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    GameObject Player;

    public Image Health_Bar;

    public float Enemy_DMG;

    int EnemyHealth = 100;
    public int EnemyPayment = 30;
    




    // Use this for initialization
    void Start () {

        Player =  GameObject.Find("Player");

        Health_Bar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        if(EnemyHealth < 0)
        {
            Debug.Log(EnemyPayment);
            Destroy(gameObject);
        }
        if(Vector3.Distance(Player.transform.position, transform.position) < 2.1)
        {
            //perform attack
            Player.GetComponent<Player2DController>().PlayerHealth -= Enemy_DMG;
            Debug.Log(Player.GetComponent<Player2DController>().PlayerHealth);
            Health_Bar.fillAmount = Player.GetComponent<Player2DController>().PlayerHealth / 100;
            if (Health_Bar.fillAmount <= 0f)
            {
                Application.LoadLevel("Game_Over");
            }
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

        if (other.CompareTag("gel_attackZone"))
        {
            EnemyHealth -= 110;
            Debug.Log("Ouch" + EnemyHealth);
            Player.GetComponent<Player2DController>().PlayerMoney += EnemyPayment;
            Destroy(other.gameObject);
        }

    }

    

}
