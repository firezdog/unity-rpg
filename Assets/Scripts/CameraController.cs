using System;
using UnityEngine;
using UnityEngine.Tilemaps;


// use 16:9 resolution

public class CameraController : MonoBehaviour
{

	public Tilemap tm;
	private Vector3 tmMin;
	private Vector3 tmMax;
	private Transform target;

	// Start is called before the first frame update
	void Start()
	{
		setCameraBounds();
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

  private void setCameraBounds()
  {
		float halfHeight = Camera.main.orthographicSize;
		float halfWidth = Camera.main.aspect * halfHeight;
		tmMin = tm.localBounds.min + new Vector3(halfWidth, halfHeight, 0);
		tmMax = tm.localBounds.max - new Vector3(halfWidth, halfHeight, 0);
  }

  // Make sure camera updates after player (prevent lag)
  void LateUpdate()
    {
			// plan: move the camera unless the leading edge of the camera = the edge of the tilemap
			// i.e. clamp vector to tilemap
			// note that this affects the *center* of the camera
		 	gameObject.transform.position = new Vector3(
				 Mathf.Clamp(target.position.x, tmMin.x, tmMax.x), 
				 Mathf.Clamp(target.position.y, tmMin.y, tmMax.y),
				 gameObject.transform.position.z);
		}
}
