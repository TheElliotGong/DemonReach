using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum UpgradeType { moreHealth, moveSpeed, bulletSpeed, bulletDmg };
    private UpgradeType upgradeType;
    
    
    public List<Upgrade> upgrades;
    void Start()
    {
        RandomizeUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeUpgrades()
    {
        List<int> upgradeOptions;
        for(int i = 0; i < upgrades.Count; i++)
        {

            int randomNum = Random.Range(1, 5);
            while(!upgradeOptions.Contains(randomNum))
            {
                randomNum = Random.Range(1, 5);
            }
            upgradeOptions.Add(randomNum);
            upgrades[i].type = randomNum;
        }
        
        

    }
}
