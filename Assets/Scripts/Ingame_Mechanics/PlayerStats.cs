using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Gold;
    public int startGold = 0;
    public static int notEnoughGoldThreshold = 200;
    public static int _TotalGold;

    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Gold = startGold;
        Lives = startLives;
    }
}
