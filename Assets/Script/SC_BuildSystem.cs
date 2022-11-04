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

    [SerializeField] public GameObject firstTurretPrefab;

    private void Start()
    {
        turretToBuild = firstTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
