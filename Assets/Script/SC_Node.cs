using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Node : MonoBehaviour
{
    [Header("Node options")]
    [SerializeField] public Vector3 yOffset;
    private Renderer render;
    private GameObject turret;
    public Color hoverColor;
    private Color startColor;


    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Impossible de placer une tourelle ici.");
            return;
        }

        // Construction des tourelles
        GameObject turretToBuild = SC_BuildSystem.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + yOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
