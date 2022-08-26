using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Node target;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI sellCostText;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPossiton();

        //cap nhat noi dung hien thi cho bang thong bao upgrade
        if (!target.isUpgraded)
        {
            upgradeCostText.text = "$" + target.gunModel.upgradeCost;
            sellCostText.text = "$" + (target.gunModel.cost / 2);
        }
        else
        {
            upgradeCostText.text = "DONE";
            sellCostText.text = "$" + ((target.gunModel.upgradeCost + target.gunModel.cost) / 2);
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeGun();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellGun();
        BuildManager.instance.DeselectNode();
    }
}
