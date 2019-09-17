using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{

	private StatController character;

	public StatController Character { set => character = value; }

	// Start is called before the first frame update
	void Start()
	{
		buttonText().text = character.name;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnClick()
	{

	}

	Text buttonText() {
		return gameObject.transform.GetComponentInChildren<Text>();
	}

}
