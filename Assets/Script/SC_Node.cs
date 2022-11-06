using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class SC_Node : MonoBehaviour
{
    [Header("Node options")]
    [SerializeField] public Vector3 yOffset;
    private Renderer render;
    [HideInInspector] public GameObject turret;
    [HideInInspector] public SC_TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    private SC_BuildSystem buildSystem;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;


    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        buildSystem = SC_BuildSystem.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + yOffset;
    }

    public void UpgradeTurret()
    {
        if (SC_PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle");
            return;
        }

        SC_PlayerStats.money -= turretBlueprint.upgradeCost;
        // Delete old turret
        Destroy(turret);

        //Create new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Tourelle améliorée");
    }

    private void BuildTurret(SC_TurretBlueprint blueprint)
    {
        if (SC_PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        SC_PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        Debug.Log("La tourelle a été construite");
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildSystem.SelectNode(this);
            return;
        }

        if (!buildSystem.canBuild)
        {
            return;
        }
        // Construction des tourelles
        BuildTurret(buildSystem.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildSystem.canBuild)
        {
            return;
        }

        if(buildSystem.hasMoney)
        {
            render.material.color = hoverColor;
        }
        else
        {
            render.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
