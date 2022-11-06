using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Shop : MonoBehaviour
{
    [SerializeField] SC_TurretBlueprint standardTurret;
    [SerializeField] SC_TurretBlueprint missileLauncherTurret;

    private SC_BuildSystem buildSystem;

    private void Start()
    {
        buildSystem = SC_BuildSystem.instance;
    }
    public void SelectStandartTurret()
    {
        Debug.Log("Tourelle standard selectionée");
        buildSystem.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncherTurret()
    {
        Debug.Log("Lance missile selectioné");
        buildSystem.SelectTurretToBuild(missileLauncherTurret);
    }
}
