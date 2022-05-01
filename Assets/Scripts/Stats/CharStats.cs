using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Stats
{
    public class CharStats : MonoBehaviour
    {
        public string charName;
        public string equippedWeapon;
        public string equippedArmor;

        public int currentHP;
        public int maxHP = 100;
        public int currentMP;
        public int maxMP = 30;
        public int strength;
        public int defence;
        public int weaponPower;
        public int armorPower;
        public int[] expToNextLevel;
        public int maxLevel = 100;
        public int baseEXP = 1000;
        public int currentEXP = 250 ;
        public int playerLevel = 1;

        public Sprite charImage;

        private void Start() 
        {
            expToNextLevel = new int[maxLevel];
            expToNextLevel[1] = baseEXP;

            for (int i = 2; i < expToNextLevel.Length; i++)
            {
                expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i-1] * 1.05f);
            }
        }

        private void Update() 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                AddExp(500);
            }
        }

        public void AddExp(int expToAdd)
        {
            currentEXP += expToAdd;

            
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;
            }


        }
        
    }
}
