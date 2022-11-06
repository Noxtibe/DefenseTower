using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BuildSystem : MonoBehaviour
{
    #region Singleton
    public static SC_BuildSystem instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déjà un build system !");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] public GameObject standardTurretPrefab;
    [SerializeField] public GameObject missileLauncherPrefab;
    public SC_NodeUI nodeUI;
    private SC_TurretBlueprint turretToBuild;
    private SC_Node selectedNode;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return SC_PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(SC_TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public SC_TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(SC_Node node)
    {
        if(node == selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
