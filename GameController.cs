using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public GameObject player;
    public GameObject earth;
    public GameObject cam;
    public GameObject DeathUI, GameUI;
    [HideInInspector]
    public GameObject[] Plan;
    public Text P_count;
    private int currentP;
    public GameObject OutofZone;
    
    private void Awake()
    {

    }
    void Start()
    {
       
        Plan = GameObject.FindGameObjectsWithTag("Planet");
        P_count.text = ("X" + Plan.Length.ToString());
        currentP = Plan.Length;
    }


    void Update()
    {
        Plan = GameObject.FindGameObjectsWithTag("Planet");

        
        if (Plan.Length < currentP)
        {
            DisplayPlanets();
        }
        if(earth == null)
        {
            Destroy(player);
            cam.SetActive(true);
            DeathUI.SetActive(true);
            GameUI.SetActive(false);
        }
        else if(Plan.Length <= 0)
        {
            SceneManager.LoadScene("Winning");
        }
      
       
        if (player == null)
        {
            cam.SetActive(true);
            DeathUI.SetActive(true);
            GameUI.SetActive(false);

        }

    }
   public void DisplayPlanets()
    {
        Plan = GameObject.FindGameObjectsWithTag("Planet");
        P_count.text = ("X" + Plan.Length.ToString());
        currentP = Plan.Length;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Please re enter combat area");
            OutofZone.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            OutofZone.SetActive(false);
        }
    }
}
