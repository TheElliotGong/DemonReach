using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Upgrade> upgradesOptions;
    // Update is called once per frame
    private void Start()
    {

    }
    private void OnEnable()
    {
        RandomizeUpgrades();
    }

    public void RandomizeUpgrades()
    {
        List<int> upgradeNums = new List<int>();
        int randomNum = 0;
        for(int i = 0; i < upgradesOptions.Count; i++)
        {
            do
            {
                randomNum = Random.Range(1, 5);
            } while (upgradeNums.Contains(randomNum));
            upgradeNums.Add(randomNum);
            upgradesOptions[i].SetType(randomNum);
        }
    }
}
