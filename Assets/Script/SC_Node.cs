using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SC_Node : MonoBehaviour
{
    [Header("Node options")]
    [SerializeField] public Vector3 yOffset;
    private Renderer render;
    public GameObject turret;
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

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildSystem.canBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Impossible de placer une tourelle ici.");
            return;
        }

        // Construction des tourelles
        buildSystem.BuildTurretOn(this);
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
