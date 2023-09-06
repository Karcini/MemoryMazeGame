using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Abilities sightEvent;
    void Start()
    {
        sightEvent = (Abilities)FindObjectOfType(typeof(Abilities));
        InitializeDelegates();
    }
    void InitializeDelegates()
    {
        sightEvent.trueSightDelegateON += Disappear;
        sightEvent.trueSightDelegateOFF += Reappear;
    }
    public void UnSubToDelegates()
    {
        sightEvent.trueSightDelegateON -= Disappear;
        sightEvent.trueSightDelegateOFF -= Reappear;
    }
    void Disappear()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }
    void Reappear()
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
