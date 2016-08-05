using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2DController : MonoBehaviour {

    //DebugingShortCuts
    // E --> Interact
    // M --> GetMoney


    //initialise the speed of the player in the inspector
    public float Speed;

    //PlayerHealth
    public float PlayerHealth;

    //Weapon Number
    int WeaponNumber = 0;
    public GameObject ScissorsAttackZone;
    public GameObject ShaverAttackZone;
    public GameObject SprayAttackZone;

    //powerUp timer
    float PowerUpTimer = 0;

    //MoneySystem
    public int PlayerMoney = 0;

    //Upgrade GUI Element
    public GameObject UpgradeGUI;
    public Text PlayerMoneyGUI;
    GameObject Enemy;

    // Use this for initialization
    void Start () {

        PlayerHealth = 100.0f;
        Enemy = GameObject.Find("Enemy");
        
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

        //PlayerHealthmaximum
        if(PlayerHealth >= 100)
        {
            PlayerHealth = 100;
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
            //Debug.Log(PowerUpTimer);
        }
        else
        {
            PowerUpTimer = 0;
            WeaponNumber = 0;
        }
        //Debuging Money System
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerMoney += 100;
            Debug.Log("PlayerMoneyAmount = " + PlayerMoney);
        }

        //GUI Elements
        //PlayerMoney
        PlayerMoneyGUI.GetComponent<Text>().text = "Money: $" + PlayerMoney;
       
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

        //Debug.Log(other.tag);
        //Check if the trigger you collided with its a power up of type Spray Can
        if (other.CompareTag("spraycan_powerup"))
        {
            Destroy(other.gameObject);      //Destroy the power up object
            WeaponNumber = 2;               //Change the weapon loadout to spraycan
            PowerUpTimer += 10;             //Start the power up timer
        }
        //Check if the trigger you collided with its a power up of type Shaver
        if (other.CompareTag("shaver_powerup"))
        {
            Destroy(other.gameObject);      //Destroy the power up object
            WeaponNumber = 1;               //Change the weapon loadout to spraycan
            PowerUpTimer += 10;             //Start the power up timer
        }
        //Gel will need a enemy to use so this will be done next week
        // (other.CompareTag("gel_powerup"))
        //
        //  Destroy(other.gameObject);
        //  WeaponNumber = 3;
        //  PowerUpTimer += 10;
        //
    }

    //Asset Collision
    void OnTriggerStay2D(Collider2D other)
    {
        //Look to see if the player is in the assets zone
        if (other.CompareTag("Asset"))
        {

            if (other.GetComponent<Chair>().AssetState < 1)
            {
                UpgradeGUI.SetActive(true);
                
                //Check if the player has clicked the interact button and that he has the required amount of money 
                if (Input.GetKeyDown(KeyCode.E) && PlayerMoney >= 100)
                {
                        other.GetComponent<Chair>().AssetState = 1;
                        PlayerMoney -= 100;
                        Debug.Log(PlayerMoney);
                        Enemy.GetComponent<EnemyHealthScript>().EnemyPayment += 30;
                        Debug.Log("Enemy Money: " + Enemy.GetComponent<EnemyHealthScript>().EnemyPayment);
                }
            }
        }

        if (other.CompareTag("Office"))
        {
            
            if(other.name == "ChairNextLevel")
            {
                //Debug.Log("fond the next level chair");
                if (Input.GetKeyDown(KeyCode.E) && PlayerMoney >= 0)
                {

                    Chair ch = other.gameObject.GetComponent<Chair>();
                    ch.MoveToNextLevel();
                    PlayerMoney -= 1000;
                    Debug.Log(PlayerMoney);

                    
                }


            }
            
        }

    }

    void OnTriggerExit2D()
    {
        
         UpgradeGUI.SetActive(false);
        
    }


   
}
