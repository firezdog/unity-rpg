using UnityEngine;
using UnityEngine.Tilemaps;

// use 16:9 resolution

public class CameraController : MonoBehaviour
{
	public Tilemap tm;
	private Vector3 mapMin;
	private Vector3 mapMax;
	private Vector3 camMin;
	private Vector3 camMax;
	private Transform target;

	// Start is called before the first frame update
	void Start()
	{
		SetCameraBounds();
		// use our static player instance -- we just need to make sure that instance is set first (script load / awake)
		PlayerController.instance.setBounds(mapMin, mapMax);
		target = PlayerController.instance.transform;
	}

	private void SetCameraBounds()
	{
		float halfHeight = Camera.main.orthographicSize;
		float halfWidth = Camera.main.aspect * halfHeight;
		mapMin = tm.localBounds.min;
		camMin = mapMin + new Vector3(halfWidth, halfHeight, 0);
		mapMax = tm.localBounds.max;
		camMax = mapMax - new Vector3(halfWidth, halfHeight, 0);
	}

	// Make sure camera updates after player (prevent lag)
	void LateUpdate()
	{
		// plan: move the camera unless the leading edge of the camera = the edge of the tilemap
		// i.e. clamp vector to tilemap
		// note that this affects the *center* of the camera
		gameObject.transform.position = new Vector3(
			 Mathf.Clamp(target.position.x, camMin.x, camMax.x),
			 Mathf.Clamp(target.position.y, camMin.y, camMax.y),
			 gameObject.transform.position.z);
	}
}
