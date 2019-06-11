using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{

    private string playerName;
    private Sprite playerImage;

    private int currentHP;
    private int maxHP;
    private int currentMP;
    private int maxMP;

    private int attack;
    private int weaponBonus;
    private string equippedWeapon;
    private int defence;
    private int armorBonus;
    private string equippedArmor;

    private int exp;
    private int level = 1;
    private int expForNext;

    [SerializeField, Range(1, 100)] private int maxLevel = 100;
    [SerializeField] private int levelSeed = 100;
    [SerializeField] private int[] customLevelReqs = new int[100];
    private int[] levelReqs;
    
    // Start is called before the first frame update
    void Start()
    {
        // simple system to start out.
        levelReqs = new int[maxLevel];
        levelReqs[0] = levelSeed;
        for (int i = 1; i < levelReqs.Length; i++) {
            if (customLevelReqs[i] == 0) levelReqs[i] = (int) (levelReqs[i-1] * 1.05);
            else levelReqs[i] = customLevelReqs[i];
        }
        // test -- should level up
        exp = 100;
    }

    void checkLevel() {
        // zero-indexing: level N's requirements are listed in levelReqs[N-1]
        expForNext = levelReqs[level-1] - exp;;
        if (expForNext <= 0) levelUp(); 
    }

    void levelUp() {
        level++;
        // do some other stuff (stats increase)
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }
}
