using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GunModel standardGun;
    public GunModel missileLauncher;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardGun()
    {
        //buildManager.SelectGunToBuild(standardGun);
        buildManager.GunToBuild = standardGun;
    }
    public void SelectMissileLauncher()
    {
        //buildManager.SelectGunToBuild(missileLauncher);
        buildManager.GunToBuild = missileLauncher;
    }
}
