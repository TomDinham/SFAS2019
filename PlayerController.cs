using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
 
  
   
    // The starting position of the player
    Vector3 m_SpawningPosition = Vector3.zero;
   
    // Whether the player is alive or not
    bool m_IsAlive = true;

    // The time it takes to respawn
    const float MAX_RESPAWN_TIME = 1.0f;
    float m_RespawnTime = MAX_RESPAWN_TIME;

    Rigidbody rb;
    CharacterController cc;
    Transform MT;
    private AudioSource AS;

    public float M_speed = 50f;
    public float T_angle = 60f;
    public GameObject rocket;
    public GameObject PR;
    public  Transform[] Rspawner;
    public float health=100;
    public int ammo;
    private bool canfire;
    public AudioClip Lazer,warp,powerDown,dryfire;
    public Text AmmoTex;
    public Image healthBar , boostBar;
    private float startHealth;
    private float Cooldown = 1f;
    private bool isHit;
    private float boost;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MT = transform;
        AS = GetComponent<AudioSource>();
        health = 100;
        boost = 100;
    }

    // Use this for initialization
    void Start()
    {
       
        m_SpawningPosition = transform.position;
        startHealth = health;
    }


    // Update is called once per frame
    void Update()
    {

        if (ammo > 0)
        {
            canfire = true;
        }
        else
        {
            canfire = false;
        }
        // If the player is dead update the respawn timer and exit update loop
        if (!m_IsAlive)
        {
            UpdateRespawnTime();
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (canfire)
            {
                Fire();

            }
            else
            {
                AS.PlayOneShot(dryfire);
            }

        }
        boostBar.fillAmount = boost / 100f;

        if (boost > 1)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                M_speed = 500;
                boost -= 2f;
            }
           
        }
        else
        {
            M_speed = 300;
        }
        boost += 0.25f;



        if (health <= 0)
        {
            Die();
        }
        AmmoTex.text = ammo.ToString();
       
        if(isHit)
        {
            
            if(Cooldown <= 0)
            {
                isHit = false;
                Cooldown = 1f;
            }
            else
            {
                Cooldown -= Time.deltaTime;
            }
            
        }
        
    }
    private void FixedUpdate()
    {
        turn();
        mover();

        
    }
    private void mover()
    {
        
        if(Input.GetAxis("Vertical_P1") != 0)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
               
                AS.PlayOneShot(warp);
                AS.Play();
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                AS.Stop();
                AS.PlayOneShot(powerDown);
            }

            MT.position += MT.forward * M_speed * Time.deltaTime * Input.GetAxis("Vertical_P1");
           
           
        }
    }
   
    void turn()
    {
        float yaw = T_angle * Time.deltaTime * Input.GetAxis("Horizontal_P1");
        float pitch = T_angle * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = T_angle * Time.deltaTime * Input.GetAxis("Roll");

        MT.Rotate(-pitch, yaw, roll);
    }
    void Fire()
    {
        foreach(Transform t in Rspawner)
        {
            AS.PlayOneShot(Lazer);
            Instantiate(rocket, t.position, t.rotation * rocket.transform.rotation);
            ammo--;
        }

    }

    public void Die()
    {
        m_IsAlive = false;
        Instantiate(PR, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
        m_RespawnTime = MAX_RESPAWN_TIME;
    }

    void UpdateRespawnTime()
    {
        m_RespawnTime -= Time.deltaTime;
        if (m_RespawnTime < 0.0f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        m_IsAlive = true;
        transform.position = m_SpawningPosition;
        transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Planet" || other.gameObject.CompareTag("Earth"))
        {
            Debug.Log("Death");
            Die();
        }
        if(other.gameObject.tag == "Enemy")
        {
            if(!isHit)
            {
                isHit = true;
                health -= 10;
                healthBar.fillAmount = health/startHealth;

            }
           
        }
        if(other.gameObject.tag == "Ammo")
        {
            if(ammo <= 100)
            {
                ammo = 200;
            }
           
            
            
        }
        if (other.gameObject.CompareTag("Ship"))
        {
            Debug.Log("Crash");
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ship"))
        {
            Debug.Log("Crash");
            Die();
        }
    }

}
