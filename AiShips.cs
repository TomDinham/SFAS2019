using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiShips : MonoBehaviour
{ 
    public GameObject rocket;
    public GameObject target;
    public Transform[] guns;
    public float move_speed = 500;
    Vector3 motion_to_target = Vector3.zero;
    Vector3 movementDirection = Vector3.zero;
    CharacterController cc;
    public Transform spawnPoint;
    private float NextSpawn = 0f, spawnRate = 0.005f;
    public GameObject PR;
    // Use this for initialization
   
    void Start () {
        
        cc = GetComponent<CharacterController>();
        
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        movementDirection = target.transform.position - transform.position;
        movementDirection.Normalize();

        transform.LookAt(target.transform);
        moveToTargert();
        // Debug.Log(movementDirection);
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // Aggro range
        if (distance < 800f)
        {
           // Debug.Log("here");
            transform.LookAt(target.transform);
            if(Time.time >= NextSpawn)
            {
                Fire();
                NextSpawn = Time.time + 1f / spawnRate;
            }
            
        }
        else
        {
            motion_to_target = (movementDirection * move_speed + new Vector3(0, 0, 0)) * Time.deltaTime;

            cc.Move(motion_to_target);

        }
    }
    void turnToTarget()
    { 
    
        if (movementDirection != Vector3.zero)
        {
            
        }

    }
    void moveToTargert()
    {

    }
    void Fire()
    {
        Debug.Log("firing");
        Quaternion lookRotation = Quaternion.LookRotation(movementDirection);
     
        transform.rotation = lookRotation;
             foreach(Transform g in guns)
        {

            Instantiate(rocket, g.position, g.rotation * rocket.transform.rotation);
        }
       
            
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            Instantiate(PR, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
