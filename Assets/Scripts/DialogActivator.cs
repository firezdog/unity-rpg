using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
	[SerializeField] TextAsset textAsset;

	private bool focussed = false;
	public void Focus()
	{
		focussed = true;
	}

	DialogController dc;

	// Start is called before the first frame update
	void Start()
	{
		dc = DialogController.instance;
	}

	private string[] GetDialog()
	{
		return Regex.Split(textAsset.text, "\n");
	}

	void Update()
	{
		if (focussed && Input.GetButtonUp("Fire1"))
		{
			focussed = false;
			StartCoroutine("Activate");
		}
	}

	IEnumerator Activate()
	{
		yield return new WaitForSeconds(0.1f);
		dc.ToggleActive(GetDialog(), this);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") focussed = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") focussed = false;
	}

}
