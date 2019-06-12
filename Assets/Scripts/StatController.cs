using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{

    private string playerName;
    private Sprite playerImage;

    private int currentHP = 100;
    private int maxHP = 100;
    private int currentMP = 100;
    private int maxMP = 100;

    private int attack = 1;
    private int weaponBonus;
    private string equippedWeapon;
    private int defence = 1;
    private int armorBonus;
    private string equippedArmor;

    private int exp;
    private int level = 1;

    [SerializeField, Range(1, 100)] private int maxLevel = 100;
    [SerializeField] private int levelSeed = 100;
    [SerializeField] private int[] customLevelReqs = new int[100];
    [SerializeField] private int[] customMPLvlBonus = new int[100];
    [SerializeField] private int[] customHPLvlBonus = new int[100];
    private int[] levelReqs;
    
    // Start is called before the first frame update
    void Start()
    {
        // simple system to start out.
        levelReqs = new int[maxLevel];
        // customLevelReqs[0] can override the level seed.
        levelReqs[0] = levelSeed;
        for (int i = 0; i < levelReqs.Length; i++) {
            levelReqs[i] = customLevelReqs[i] == 0 ?
                (int) (levelReqs[i-1] * 2.05) :
                customLevelReqs[i];
        }
    }

    public void addExp(int gain) {
        // zero-indexing: level N's requirements are listed in levelReqs[N-1]
        // note the requirement to get to level N + 1 is level N's level up requirement (a bit confusing, I know)
        if (level == maxLevel) return;
        exp += gain;
        int expForNext = levelReqs[level-1] - exp;
        if (expForNext <= 0) levelUp(); 
    }

    void levelUp() {
        gainStats();
        level++;
        // do some other stuff (stats increase)
    }

    void gainStats() {
        int custHP = customHPLvlBonus[level - 1];
        int custMP = customMPLvlBonus[level - 1];
        currentHP = maxHP = custHP == 0 ? 
            (int) (maxHP * 1.05) : 
            maxHP + custHP;
        currentMP = maxMP = custMP == 0 ? 
            (int) (maxMP * 1.05) :
            maxMP + custMP;
        attack++;
        defence++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            addExp(50);
        }
    }
}
