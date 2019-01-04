using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using keyCode = UnityEngine.KeyCode;

public class PlayerController : MonoBehaviour {

	[SerializeField] Animator playerAnimator;
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		animatePlayer();
	}

    private void animatePlayer()
    {
		playerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
		playerAnimator.SetFloat("moveX", playerBody.velocity.x);
		playerAnimator.SetFloat("moveY", playerBody.velocity.y);
		if (playerBody.velocity != new Vector2(0,0)) {
			playerAnimator.SetBool("stopped", false);
			playerAnimator.SetFloat("facingX", playerBody.velocity.x);
			playerAnimator.SetFloat("facingY", playerBody.velocity.y);
		} else {
			playerAnimator.SetBool("stopped", true);
		}
    }

}
