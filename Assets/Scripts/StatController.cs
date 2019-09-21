using UnityEngine;

public class StatController : MonoBehaviour 
{

	#region basic information
	[SerializeField] private string playerName;
	public string PlayerName { get => playerName; set => playerName = value; }
	[SerializeField] private Sprite playerImage;
	public Sprite PlayerImage { get => playerImage; set => playerImage = value; }
	#endregion

	#region HP & MP
	[SerializeField] private int currentHP = 100;
	public int CurrentHP { get => currentHP; set => currentHP = value; }
	[SerializeField] private int maxHP = 100;
	public int MaxHP { get => maxHP; set => maxHP = value; }
	[SerializeField] private int currentMP = 100;
	public int CurrentMP { get => currentMP; set => currentMP = value; }
	[SerializeField] private int maxMP = 100;
	public int MaxMP { get => maxMP; set => maxMP = value; }
	#endregion

	#region combat stats
	[SerializeField] private int attack = 1;
	public int Attack { get => attack; set => attack = value; }
	[SerializeField] private int weaponBonus;
  	public int WeaponBonus { get => weaponBonus; set => weaponBonus = value; }
	[SerializeField] private string equippedWeapon;
	public string EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
	[SerializeField] private int defence = 1;
  	public int Defence { get => defence; set => defence = value; }
	[SerializeField] private int armorBonus;
  	public int ArmorBonus { get => armorBonus; set => armorBonus = value; }
	[SerializeField] private string equippedArmor;
	public string EquippedArmor { get => equippedArmor; set => equippedArmor = value; }
	#endregion

	#region character level
	[SerializeField] private int exp;
	public int Exp { get => exp; set => exp = value; }
	[SerializeField] private int level;
	public int Level { get => level; set => level = value; }
	#endregion

	#region level book-keeping
	[SerializeField, Range(1, 100)] private int maxLevel = 100;
	[SerializeField] private int levelSeed = 100;
	private int[] levelReqs;
	[SerializeField] private int[] customLevelReqs = new int[101];
	[SerializeField] private int[] customMPLvlBonus = new int[101];
	[SerializeField] private int[] customHPLvlBonus = new int[101];
	#endregion

  	// Start is called before the first frame update
  	void Start()
	{
		// simple system to start out. -- not zero indexed, i.e. req for level 2 should be levelReqs[2]
		levelReqs = new int[maxLevel + 1];
		// customLevelReqs[0] can override the level seed.
		levelReqs[2] = levelSeed;
		for (int i = 3; i < levelReqs.Length; i++)
		{
			levelReqs[i] = customLevelReqs[i] == 0 ?
			  	(int)(levelReqs[i - 1] * 2.05) :
				customLevelReqs[i];
		}
		// to prevent me from setting exp to a value lower than current level req's.
		Exp = relativeExp() < 0 ? levelReqs[level] : exp; 
	}

	public float percentToLevel()
	{
		if (Level == maxLevel) return 1;
		return (float) relativeExp() / relativeExpForNextLevel();
	}

	public int relativeExp() {
		if (level == maxLevel) return levelReqs[level] - levelReqs[level - 1];
		int baseLine = levelReqs[level];
		return Exp - baseLine;
	}

	public int relativeExpForNextLevel() {
		if (level == maxLevel) return levelReqs[level] - levelReqs[level - 1];
		return levelReqs[level + 1] - levelReqs[level];
	}

	public int remainingExpForNextLevel() {
		return forNextLevel() - Exp;
	}

	public int forNextLevel()
	{
		if (Level == maxLevel) return Exp;
		return levelReqs[level + 1];
	}

	public void addExp(int gain)
	{
		// zero-indexing: level N's requirements are listed in levelReqs[N-1]
		// note the requirement to get to level N + 1 is level N's level up requirement (a bit confusing, I know)
		if (Level == maxLevel) return;
		Exp += gain;
		if (remainingExpForNextLevel() <= 0) levelUp();
	}

	void levelUp()
	{
		gainStats();
		Level++;
		// do some other stuff (stats increase)
	}

	void gainStats()
	{
		int custHP = customHPLvlBonus[Level];
		int custMP = customMPLvlBonus[Level];
		CurrentHP = MaxHP = 
			custHP == 0 ?
				(int)(MaxHP * 1.05) :
				MaxHP + custHP;
		CurrentMP = MaxMP = 
			custMP == 0 ?
		  		(int)(MaxMP * 1.05) :
		  		MaxMP + custMP;
		Attack++;
		Defence++;
	}

	// Update is called once per frame
	// for testing
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			addExp(50);
		}
	}
}
