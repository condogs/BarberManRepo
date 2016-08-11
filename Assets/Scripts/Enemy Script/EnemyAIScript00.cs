using UnityEngine;
using System.Collections;

public class EnemyAIScript00 : MonoBehaviour {

	public Transform player;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
    public GameObject playerObject;
    public GameObject enemy;
    public float spawntime = 10f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawn", spawntime, 0);
	}
	
	// Update is called once per frame
    void Update()
    {
        {
            playerDistance = Vector3.Distance(player.position, transform.position);
            if (playerDistance < 100f)
            {
                chase();
                lookAtPlayer();
            }
        }
    }
	

	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}

	void chase()
	{
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}
    
    void spawn()
    {
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        Instantiate(enemy, position, Quaternion.identity);      
    }
}
	

