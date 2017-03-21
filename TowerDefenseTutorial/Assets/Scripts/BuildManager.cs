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
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    
    public bool CanBuild { get { return turretToBuild != null;  } }

    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode ()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
