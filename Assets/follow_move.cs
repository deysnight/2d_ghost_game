using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_move : MonoBehaviour {

    public GameObject leader;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, leader.transform.position, 0.25f); //0.5f
    }
}
