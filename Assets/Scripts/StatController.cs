using UnityEngine;

public class StatController : MonoBehaviour 
{

	[SerializeField] private string playerName;
	[SerializeField] private Sprite playerImage;

	[SerializeField] private int currentHP = 100;
	[SerializeField] private int maxHP = 100;
	[SerializeField] private int currentMP = 100;
	[SerializeField] private int maxMP = 100;

	[SerializeField] private int attack = 1;
	[SerializeField] private int weaponBonus;
	[SerializeField] private string equippedWeapon;
	[SerializeField] private int defence = 1;
	[SerializeField] private int armorBonus;
	[SerializeField] private string equippedArmor;

	[SerializeField] private int exp;
	[SerializeField] private int level = 1;

	[SerializeField, Range(1, 100)] private int maxLevel = 100;
	[SerializeField] private int levelSeed = 100;
	[SerializeField] private int[] customLevelReqs = new int[100];
	[SerializeField] private int[] customMPLvlBonus = new int[100];
	[SerializeField] private int[] customHPLvlBonus = new int[100];
	private int[] levelReqs;

	public string PlayerName { get => playerName; set => playerName = value; }
	public Sprite PlayerImage { get => playerImage; set => playerImage = value; }
	public int CurrentHP { get => currentHP; set => currentHP = value; }
	public int MaxHP { get => maxHP; set => maxHP = value; }
	public int CurrentMP { get => currentMP; set => currentMP = value; }
	public int MaxMP { get => maxMP; set => maxMP = value; }
	public int Level { get => level; set => level = value; }
	public int Exp { get => exp; set => exp = value; }
  public int Attack { get => attack; set => attack = value; }
  public int WeaponBonus { get => weaponBonus; set => weaponBonus = value; }
  public string EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
  public int Defence { get => defence; set => defence = value; }
  public int ArmorBonus { get => armorBonus; set => armorBonus = value; }
  public string EquippedArmor { get => equippedArmor; set => equippedArmor = value; }

  // Start is called before the first frame update
  void Start()
	{
		// simple system to start out.
		levelReqs = new int[maxLevel];
		// customLevelReqs[0] can override the level seed.
		levelReqs[0] = levelSeed;
		for (int i = 1; i < levelReqs.Length; i++)
		{
			levelReqs[i] = customLevelReqs[i] == 0 ?
			  (int)(levelReqs[i - 1] * 2.05) :
			  customLevelReqs[i];
		}
	}

	public float percentToLevel()
	{
		if (Level == maxLevel) return 1;

		return (float) (Exp - BaseLineExp()) / (forNextLevel() - BaseLineExp());
	}

	public int BaseLineExp() {
		int baseLine;
		try {
      baseLine = levelReqs[level - 2];
    } catch {
			baseLine = 0;
		}
		return baseLine;
	}

	public int forNextLevel() {
		return levelReqs[level - 1];
	}

	public int toNextLevel()
	{
		if (Level == maxLevel) return Exp;
		return levelReqs[level - 1] - exp;
	}

	public void addExp(int gain)
	{
		// zero-indexing: level N's requirements are listed in levelReqs[N-1]
		// note the requirement to get to level N + 1 is level N's level up requirement (a bit confusing, I know)
		if (Level == maxLevel) return;
		Exp += gain;
		int expForNext = levelReqs[Level - 1] - Exp;
		if (expForNext <= 0) levelUp();
	}

	void levelUp()
	{
		gainStats();
		Level++;
		// do some other stuff (stats increase)
	}

	void gainStats()
	{
		int custHP = customHPLvlBonus[Level - 1];
		int custMP = customMPLvlBonus[Level - 1];
		CurrentHP = MaxHP = custHP == 0 ?
		  (int)(MaxHP * 1.05) :
		  MaxHP + custHP;
		CurrentMP = MaxMP = custMP == 0 ?
		  (int)(MaxMP * 1.05) :
		  MaxMP + custMP;
		Attack++;
		Defence++;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			addExp(50);
		}
	}
}
