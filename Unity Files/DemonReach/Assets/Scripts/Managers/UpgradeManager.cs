using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum UpgradeType { moreHealth, moveSpeed, bulletSpeed, bulletDmg };
    public UpgradeType upgradeType;
    private List<Upgrade> upgrades;
    public List<Button> upgradeButtons;
    void Start()
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            upgrades.Add(upgradeButtons[i].GetComponent<Upgrade>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeUpgrades()
    {

    }
}
