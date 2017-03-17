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
    public GameObject missleTurretPrefab;

    private TurretBlueprint turretToBuild;
    
    public bool CanBuild { get { return turretToBuild != null;  } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough $$");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret built, money spent");
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
