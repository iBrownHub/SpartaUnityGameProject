using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    private Renderer rend;
    private Color startColour;
    private GameObject turret;
    public Vector3 positionOffset;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        cost = 200;
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (turret != null && WaveSpawner.currency >= cost)
        {
            WaveSpawner.currency -= cost;
            Turret thisTurret = turret.GetComponent<Turret>();
            thisTurret.turretLevel++;
            cost = 200 * thisTurret.turretLevel;
        }
        else if (turret != null)
        {
            return;
        }
        else if (WaveSpawner.currency >= 100)
        {
            WaveSpawner.currency -= 100;
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            Turret thisTurret = turret.GetComponent<Turret>();
            thisTurret.turretLevel = 1;
        }        
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColour;
    }
    void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
