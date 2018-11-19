using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using keyCode = UnityEngine.KeyCode;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D playerBody;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		playerBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

}
