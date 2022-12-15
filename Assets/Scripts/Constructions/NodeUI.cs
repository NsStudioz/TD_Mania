using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

    [SerializeField] Node target;

    [SerializeField] GameObject ui;

    [SerializeField] TMP_Text upgradeCost;

    [SerializeField] TMP_Text sellingCost;

    [SerializeField] Button upgradeButton;

    private void Update()
    {
        if(GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
        {
            Hide();
        }
    }

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // not using target.transform.position so it wont sit inside the node block, and will sit on top of the turret.

        ui.SetActive(true);

/*        if (!target.isDefUnitUpgraded) // if not upgraded, set upgrade text. else set it to Maxed out.
        {
            upgradeCost.text = "$" + target.d_Unit_Blueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false;
        }*/

        sellingCost.text = "$" + target.d_Unit_Blueprint.GetSellAmount();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

/*    public void UpgradeDefUnit()
    {
        target.UpgradeTurretOrDefUnit();
        ConstructManager.instance.DeselectNode();
    }*/

    public void SellDefUnit() // for button
    {
        target.SellDefUnit();
        ConstructManager.instance.DeselectNode();
    }

    public void TemporarilyActivateTurretLOS() // Activate Line of Sight for turret temporarily.
    {
        target.TemporarilyActivateTurretLOS();
        ConstructManager.instance.DeselectNode();
    }

}
