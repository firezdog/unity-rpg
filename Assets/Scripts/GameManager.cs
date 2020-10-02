using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	[SerializeField] private StatController[] statControllers;
	private List<Item> items;

	private bool statMenuOpen, dialogOpen, fadingBetweenAreas;
	PlayerController pc;

	public bool DialogOpen
	{ get => dialogOpen; set => dialogOpen = value; }
	public bool StatMenuOpen
	{ get => statMenuOpen; set => statMenuOpen = value; }
	public bool FadingBetweenAreas
	{ get => fadingBetweenAreas; set => fadingBetweenAreas = value; }
	public StatController[] StatControllers { get => statControllers; }
	
	public void AddItem(Item item) {
		items.Add(item);
	}

	// Start is called before the first frame update
	void Awake()
	{
		instance = LoadHelper.setInstance<GameManager>(gameObject, this, instance);
		items = new List<Item>();
	}

	void Start()
	{
		pc = PlayerController.instance;
	}

	// Update is called once per frame
	void Update()
	{
		togglePlayerMovement();
	}

	private void togglePlayerMovement()
	{
		pc.setCanMove(!(StatMenuOpen || DialogOpen || fadingBetweenAreas));
	}
}
