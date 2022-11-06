using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SC_NodeUI : MonoBehaviour
{
    private SC_Node target;
    public GameObject ui;
    public TMP_Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget (SC_Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost + "€";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Fully upgraded";
            upgradeButton.interactable = false;
        }
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        SC_BuildSystem.instance.DeselectNode();
    }
}
