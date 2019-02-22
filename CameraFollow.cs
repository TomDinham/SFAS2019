using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The Camera Target
    [SerializeField]
    public GameObject m_PlayerTransform;

    // The Z Distance from the Camera Target
    [SerializeField]
    Vector3 cam = new Vector3 (0.0f,3.0f,10f);

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = (m_PlayerTransform.transform.position + cam);
        transform.rotation = m_PlayerTransform.transform.rotation;
	}
}
