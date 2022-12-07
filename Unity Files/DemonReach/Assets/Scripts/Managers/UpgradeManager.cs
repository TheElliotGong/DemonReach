using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Upgrade> upgrades;

    // Update is called once per frame
    private void Start()
    {
        RandomizeUpgrades();
    }
    private void OnEnable()
    {
        RandomizeUpgrades();
    }

    public void RandomizeUpgrades()
    {
        List<int> upgradeOptions = new List<int>();
        int randomNum = 0;
        for(int i = 0; i < upgrades.Count; i++)
        {
            do
            {
                randomNum = Random.Range(1, 4);
            } while (upgradeOptions.Contains(randomNum));
            upgradeOptions.Add(randomNum);
            upgrades[i].SetType(randomNum);
        }
    }
}
