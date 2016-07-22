using UnityEngine;
using System.Collections;

public class Player2DController : MonoBehaviour {

    public float Speed;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //character Movement Controls
        transform.Translate(new Vector2(0, 1) * Speed * Input.GetAxis("Vertical"), Space.World);
        transform.Translate(new Vector2(1, 0) * Speed * Input.GetAxis("Horizontal"), Space.World);

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
