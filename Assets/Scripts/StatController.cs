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

    [SerializeField, Range(1, 100)] private int maxLevel = 100;
    [SerializeField] private int levelSeed = 1000;
    [SerializeField] private int[] customLevelReqs = new int[100];
    private int[] levelReqs;
    
    // Start is called before the first frame update
    void Start()
    {
        // simple system to start out.
        levelReqs = new int[maxLevel];
        for (int i = 0; i < levelReqs.Length; i++) {
            if (customLevelReqs[i] == 0) levelReqs[i] = levelSeed + levelSeed*i;
            else levelReqs[i] = customLevelReqs[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
