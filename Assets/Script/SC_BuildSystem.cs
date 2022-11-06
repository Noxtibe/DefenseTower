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
    private SC_TurretBlueprint turretToBuild;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return SC_PlayerStats.money >= turretToBuild.cost; } }

    public void BuildTurretOn(SC_Node node)
    {
        if(SC_PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        SC_PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("L'objet a été acheté, il vous reste: " + SC_PlayerStats.money);
    }

    public void SelectTurretToBuild(SC_TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
