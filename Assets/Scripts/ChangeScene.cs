using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	// both the sending and receiving portal need to have the same "from" -- should be renamed or refactored.
	public string toPortal;
	public string toScene;
	public float loadWait = 1f;
	public Transform portalExit;

	private PlayerController p = PlayerController.instance;

	void Start()
	{
		UIFade.instance.fadeOut();
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
			UIFade.instance.fadeIn();
			StartCoroutine(waitAndLoad());
			p.setFrom(toPortal);
		}
	}

	private IEnumerator waitAndLoad() {
		yield return new WaitForSeconds(loadWait);
		SceneManager.LoadScene(toScene);
	}

}
