using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreBlock : MonoBehaviour
{
    public Text pName, time, points;
    public void Display(PlayerEntry item)
    {
        pName.text = item.playerName;
        time.text = item.playerTime.ToString() + "s";
        points.text = item.playerScore.ToString();

    }
}
