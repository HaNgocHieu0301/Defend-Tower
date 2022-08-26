using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    //-> xu li singleton
    //public GameObject standardGunPrefabs;
    //public GameObject anotherGunPrefabs;

    private GunModel gunToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    public GunModel GunToBuild
    {
        get
        {
            return gunToBuild;
        }
        set
        {
            gunToBuild = value;
            DeselectNode();
        }
    }

    public bool EnoughMoney
    {
        get
        {
            return PlayerStates.money >= gunToBuild.cost;
        }
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        gunToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public GunModel GetGunToBuild()
    {
        return gunToBuild;
    }
}
