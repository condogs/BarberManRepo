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

        //Player Attacking
        if(Input.GetMouseButton(0))
        {
            PerformAttack();
        }
        else
        {
            NoAttack();
        }
        
        //this is for testing purposes, when you hit number 1 2 or 3 you change between weapons scissors, shaver and spray can respectively
        /*if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponNumber = 2;
        }
        */
        //So using this above^^
        //I can change it to when the player Collides with a power up with a tag - power up with name "Shaver or spray can" 
        //then change the weapon number
        //and below this I can make a if statement, if the weapon number != o set a timer for it to change to weapon number 0. 
        //After this I just need to figure out how to affect the enemies with the weapons.

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

    void PerformAttack()
    {
        if (WeaponNumber == 0)
        {
            ScissorsAttackZone.SetActive(true);
        }
        else
        {
            ScissorsAttackZone.SetActive(false);
        }
        if (WeaponNumber == 1)
        {
            ShaverAttackZone.SetActive(true);
        }
        else
        {
            ShaverAttackZone.SetActive(false);
        }
        if (WeaponNumber == 2)
        {
            SprayAttackZone.SetActive(true);
        }
        else
        {
            SprayAttackZone.SetActive(false);
        }
    }
        
   void NoAttack()
        {

            ScissorsAttackZone.SetActive(false);
            ShaverAttackZone.SetActive(false);
            SprayAttackZone.SetActive(false); 
        }


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
        // (other.CompareTag("gel_powerup"))
        //
        //  Destroy(other.gameObject);
        //  WeaponNumber = 3;
        //  PowerUpTimer += 10;
       //


    }


}
