using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color warnColor;
    private Color startColor;
    public Vector3 positionOffset;
    private Renderer rend;

    [HideInInspector]
    public GameObject gun;
    [HideInInspector]
    public GunModel gunModel;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    /*
     * Tra ve vi tri cua node
     */
    public Vector3 GetBuildPossiton()
    {
        return transform.position + positionOffset;
    }
    /*
     * Bat su kien khi click vao node 
     */
    private void OnMouseDown()
    {
        //check node da co gun chua
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //neu node co da co sung thi chon node nay de hien thi bang upgrade and sell
        if (gun != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (buildManager.GunToBuild == null)
        {
            return;
        }
        //GunModel gunToBuild = buildManager.GetGunToBuild();
        //gun = Instantiate(gunToBuild, transform.position + positionOffset, transform.rotation);
        //buildManager.SetGunToBuild(null);

        //buildManager.BuildGunOn(this);
        BuildGun(buildManager.GetGunToBuild());
    }
    /*
     * Xay sung moi 
     */
    void BuildGun(GunModel _gunModel)
    {
        if (PlayerStates.money < _gunModel.cost)
        {
            Debug.Log(PlayerStates.money + " - Cannot buy!");
            return;
        }
        //xay dung gun moi
        GameObject _gun = Instantiate(_gunModel.gunPrefab, GetBuildPossiton(), Quaternion.identity);
        gun = _gun;

        gunModel = _gunModel;

        PlayerStates.money -= _gunModel.cost;
    }
    /*
     * Upgrade sung  
     */
    public void UpgradeGun()
    {
        if (PlayerStates.money < gunModel.upgradeCost)
        {
            Debug.Log(PlayerStates.money + " - Cannot upgrade!");
            return;
        }
        //- tien upgrade
        PlayerStates.money -= gunModel.upgradeCost;
        //pha huy gun cu
        Destroy(gun);

        //xay dung gun moi
        GameObject _gun = Instantiate(gunModel.upgradePrefab, GetBuildPossiton(), Quaternion.identity);
        gun = _gun;

        isUpgraded = true;
    }
    /*
     * Sell gun
     */
    public void SellGun()
    {
        if (isUpgraded)
        {
            PlayerStates.money += (gunModel.cost + gunModel.upgradeCost) / 2;
        }
        else
        {
            PlayerStates.money += (gunModel.cost) / 2;
        }
        Destroy(gun);
        gunModel = null;
        isUpgraded = false;
    }
    private void OnMouseEnter()
    {
        //neu node da co sung thi hover vao chuyen mau warnColor
        if (EventSystem.current.IsPointerOverGameObject())
        {
            rend.material.color = warnColor;
            return;
        }
        if (buildManager.GunToBuild == null)
        {
            return;
        }
        //du tien de xay sung thi mau hoverColor neu k thi mau wanrColor
        if (buildManager.EnoughMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = warnColor;
        }
    }
    /*
     * Thoat khoi su kien hover hoac click vao node
     */
    private void OnMouseExit()
    {
        //khi thoat chuot khoi node thi tra lai mau ban dau
        rend.material.color = startColor;
    }
}
