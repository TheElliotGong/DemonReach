using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Upgrade> upgrades;



    // Update is called once per frame
    private void OnEnable()
    {
        RandomizeUpgrades();
    }

    public void RandomizeUpgrades()
    {
        List<int> upgradeOptions = new List<int>();
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
