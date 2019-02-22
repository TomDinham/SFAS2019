using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject PR;
    public AudioSource AS;
    public AudioClip Explosion;
    // The total health of this unit
    [SerializeField]
    public float m_Health = 100;
    public float StartHealth;
    public Image healthBar;
    
    private void Awake()
    {
       
       // AS = GetComponent<AudioSource>();
    }
    public void Start()
    {
        StartHealth = m_Health;
    }
    public void DoDamage(float damage)
    {
        m_Health -= damage;
        healthBar.fillAmount = m_Health / StartHealth;
        if (m_Health <= 0)
        {

           
            Instantiate(PR, this.transform.position, this.transform.rotation);
            AS.PlayOneShot(Explosion);
            Destroy(gameObject);
           
        }
    }

    public bool IsAlive()
    {
        return m_Health > 0;
    }
}
