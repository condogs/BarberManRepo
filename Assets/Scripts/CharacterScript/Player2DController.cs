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
        if(Input.GetKeyDown(KeyCode.Alpha1))
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
    

}
