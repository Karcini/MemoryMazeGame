using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script has been replaced by DoorAnim.cs
    //Keeping it for just to see the drastic improvement in complexity
public class DoorLever : MonoBehaviour
{
    public bool leverPulled = false; //true to activate door   
    public void Open()
    {
        leverPulled = true;
    }
}
