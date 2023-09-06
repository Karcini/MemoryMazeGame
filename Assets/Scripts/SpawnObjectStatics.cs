using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectStatics
{
    //These are used in GridPoint.cs
    public static int amountEaglePads = 3;
    public static int amountTrueSightMist = 2;
    public static int amountPicks = 1;
    public static int amountCoins = 20;

    public static void ResetSpawnObjects()
    {
        amountEaglePads = 3;
        amountTrueSightMist = 2;
        amountPicks = 1;
        amountCoins = 20;
    }
}
