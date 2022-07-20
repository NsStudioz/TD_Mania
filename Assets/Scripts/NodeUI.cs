using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{

    private Node target;

    public GameObject ui;

    public TMP_Text upgradeCost;

    public TMP_Text sellingCost;

    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // not using target.transform.position so it wont sit inside the node block, and will sit on top of the turret.

        ui.SetActive(true);

        if (!target.isDefUnitUpgraded) // if not upgraded, set upgrade text. else set it to Maxed out.
        {
            upgradeCost.text = "$" + target.d_Unit_Blueprint.upgradeCost;
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false;
        }

        sellingCost.text = "$" + target.d_Unit_Blueprint.GetSellAmount();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeDefUnit()
    {
        target.UpgradeTurretOrDefUnit();
        ConstructManager.instance.DeselectNode();

    }

    public void SellDefUnit() // for button
    {
        target.SellDefUnit();
        ConstructManager.instance.DeselectNode();
    }

}
