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
	
	void Start()
	{
		if (PlayerController.instance.getFrom() == toPortal) { PlayerController.instance.transform.position = portalExit.position; }
		UIFade.instance.fadeOut();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && toPortal != "start")
		{
			PlayerController.instance.setFrom(toPortal);
			UIFade.instance.fadeIn();
			StartCoroutine(waitAndLoad());
		}
	}

	private IEnumerator waitAndLoad() {
		yield return new WaitForSeconds(loadWait);
		SceneManager.LoadScene(toScene);
	}

}
