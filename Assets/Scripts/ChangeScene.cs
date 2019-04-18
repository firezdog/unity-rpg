using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	// both the sending and receiving portal need to have the same "from" -- should be renamed or refactored.
	public string toPortal;
	public string toScene;
	public Transform portalExit;
	PlayerController p = PlayerController.instance;

	void Start()
	{
		if (p == null)
		{
			p = GameObject
				.FindGameObjectWithTag("Player")
				.GetComponent<PlayerController>();
		}
		if (p.getFrom() == toPortal) { p.transform.position = portalExit.position; }
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && toPortal != "start")
		{
			SceneManager.LoadSceneAsync(toScene);
			p.setFrom(toPortal);
		}
	}
}
