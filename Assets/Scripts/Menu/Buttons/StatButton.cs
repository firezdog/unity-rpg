using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{

	StatsPanel sp;

	private StatController character;

	public StatController Character { set => character = value; }
	public StatsPanel SP { set => sp = value; }

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
		sp.CurrentlyDisplayed = character;
	}

	Text buttonText() {
		return gameObject.transform.GetComponentInChildren<Text>();
	}

}
