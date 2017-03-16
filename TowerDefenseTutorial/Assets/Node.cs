using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
	}

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Turret already here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        Debug.Log("Enter");
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        Debug.Log("Exit");
    }
}
