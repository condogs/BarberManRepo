using UnityEngine;
using System.Collections;

public class Player2DController : MonoBehaviour {

    


    //initialise the speed of the player in the inspector
    public float Speed;

    //Weapon Number
    int WeaponNumber = 0;
    public GameObject ScissorsAttackZone;
    public GameObject ShaverAttackZone;
    public GameObject SprayAttackZone;

    float PowerUpTimer = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //character Movement Controls
        transform.Translate(new Vector2(0, 1) * Speed * Input.GetAxis("Vertical"), Space.World);
        transform.Translate(new Vector2(1, 0) * Speed * Input.GetAxis("Horizontal"), Space.World);

        //mouse aiming controls
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Player interaction / upgrading
        if(Input.GetKeyDown(KeyCode.E))
        {
            //This is where I make the command to change the game objects state from either crappy chair to high end chair
            //So I will need to make a game object that has two states, and change that variable on command of the E key
            //once this is done I will make this change only possible if I have enough money to upgrade
        }


        //Player Attacking
        //if the player uses left mouse button click, the player will perform a attack, if the button is let go then the weapon will become deactive
        if(Input.GetMouseButton(0))
        {
            PerformAttack();
        }
        else
        {
            NoAttack();
        }
        
        //Power Up Timer
        //If the timer is above 0, the timer will decrease in value till it reaches zero and changes the players weapon back to default ( 0 ).
        if(PowerUpTimer > 0)
        {
            PowerUpTimer -= Time.deltaTime;
            Debug.Log(PowerUpTimer);
        }
        else
        {
            PowerUpTimer = 0;
            WeaponNumber = 0;
        }
        


    }

    //Perform Attack Function
    //To perform a attack a player will use this function
    //it will work out which attack zone to set active. When the attack zone becomes active it is essentially a box trigger, if the enemy gets inside it, they will take damage 1 time. 
    void PerformAttack()
    {
        //Set the Scissor attack zone active if the scissors is equiped
        if (WeaponNumber == 0)
        {
            ScissorsAttackZone.SetActive(true);
        }
        else
        {
            ScissorsAttackZone.SetActive(false);
        }
        //Set the Shaver attack zone active if the Shaver is equiped
        if (WeaponNumber == 1)
        {
            ShaverAttackZone.SetActive(true);
        }
        else
        {
            ShaverAttackZone.SetActive(false);
        }
        //Set the Spraycan attack zone active if the Spraycan is equiped
        if (WeaponNumber == 2)
        {
            SprayAttackZone.SetActive(true);
        }
        else
        {
            SprayAttackZone.SetActive(false);
        }
    }
   
    //The Dont attack function
    //This function disables all weapons attack zones so that the attack zone can be used once and then delete itself     
   void NoAttack()
        {

            ScissorsAttackZone.SetActive(false);
            ShaverAttackZone.SetActive(false);
            SprayAttackZone.SetActive(false); 
        }

    //Trigger event for collecting power ups
    //Each power up have their own tag in which determines which power up to equip
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spraycan_powerup"))
        {
            Destroy(other.gameObject);
            WeaponNumber = 2;
            PowerUpTimer += 10;
        }
        if (other.CompareTag("shaver_powerup"))
        {
            Destroy(other.gameObject);
            WeaponNumber = 1;
            PowerUpTimer += 10;
        }
        //Gel will need a enemy to use so this will be done next week
        // (other.CompareTag("gel_powerup"))
        //
        //  Destroy(other.gameObject);
        //  WeaponNumber = 3;
        //  PowerUpTimer += 10;
       //


    }


}
