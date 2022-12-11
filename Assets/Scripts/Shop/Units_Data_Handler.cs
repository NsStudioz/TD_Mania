using UnityEngine;

public class Units_Data_Handler : MonoBehaviour
{
    // UNITS LEVEL HANDLER:
    [SerializeField] private int _ThisUnitLevel = 0;

    public int GetUnitLevel()
    {
        return _ThisUnitLevel;
    }

    public int UpgradeUnitLevel()
    {
        return _ThisUnitLevel++;
    }
}
