using UnityEngine;

public class Loader : MonoBehaviour
{

	// TODO: make this into a singleton

	public GameObject[] toLoad;

	// Start is called before the first frame update
	void Awake()
	{
		foreach (var loadable in toLoad)
		{
			if (GameObject.Find(loadable.name) == null) Instantiate(loadable);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
