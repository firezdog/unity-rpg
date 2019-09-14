using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
	
	[SerializeField] private GameObject panel;
	private MenuController mc;

	void Start() {
		gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
		mc = transform.GetComponentInParent<MenuController>();
	}

	void OnClick() {
		mc.ChangeCurrentPanel(panel);
	}
}