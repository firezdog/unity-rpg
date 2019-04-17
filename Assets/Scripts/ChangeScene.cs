using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	// both the sending and receiving portal need to have the same "from" for transport between -- should be renamed or refactored.
	public string from;
	public string to;
	PlayerController p = PlayerController.instance;
	static bool used = false;

	void Start()
	{
		if (p == null)
		{
			p = GameObject
				.FindGameObjectWithTag("Player")
				.GetComponent<PlayerController>();
		}
		if (p.getFrom() == from) { p.transform.position = gameObject.transform.position; }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && from != "start" && !used)
		{
			SceneManager.LoadSceneAsync(to);
			p.setFrom(from);
			used = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && from != "start" && used)
		{
			used = false;
		}
	}

}
