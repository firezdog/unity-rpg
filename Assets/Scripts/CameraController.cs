using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	private Transform target;
	// Start is called before the first frame update
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
    // Make sure camera updates after player (prevent lag)
    void LateUpdate()
    {
		gameObject.transform.position = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
    }
}
