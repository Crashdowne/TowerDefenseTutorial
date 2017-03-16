using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    // can access instance anywhere
    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager :((");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
