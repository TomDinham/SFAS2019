using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour {

     public float P_speed = 30;
	
	// Update is called once per frame
	void Update ()
    {

        this.transform.Rotate(0, P_speed * Time.deltaTime, 0);
	}
}
