using UnityEngine;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private D_Unit_Blueprint[] defendingUnits;

    public void SelectTurret(int index)
    {
        ConstructManager.instance.SelectTurretToBuild(defendingUnits[index]);
    }
}
