using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    //Break Wall
    public GameObject pick;
    public int picks = 1;
    bool pickActive;

    //Spirit Form
    public int spiritFormSight = 5;

    //True Sight
    public bool trueSightAvailable = false;
    public delegate void TrueSightOn();
    public TrueSightOn trueSightDelegateON;
    public delegate void TrueSightOff();
    public TrueSightOff trueSightDelegateOFF;

    //Doors
    public bool canOpenDoor = false;

    void Start()
    {
        pick.SetActive(false);
        pickActive = false;
        trueSightDelegateON += StopMovement;
        trueSightDelegateOFF += ReturnMovement;

        //Initialize Equipment
        picks = ScoreManager.instance.AmountPicks;
        spiritFormSight = ScoreManager.instance.AmountSpiritForm;

    }
    void Update()
    {
        if (HavePicks())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TogglePick();
            }
        }

        if(trueSightAvailable)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                trueSightAvailable = false;
                trueSightDelegateON?.Invoke();
                StartCoroutine(TurnOffTrueSight());
            }
        }

    }

    //PICK METHODS=====================
    bool HavePicks()
    {
        if (picks > 0)
            return true;
        else
            return false;
    }
    void TogglePick()
    {
        if (pickActive)
        {
            pickActive = false;
            pick.SetActive(false);
        }
        else
        {
            pickActive = true;
            pick.SetActive(true);
        }
    }
    public void BreakPick(int picksNeeded)
    {
        if(picksNeeded > picks)
        {
            //can't break wall
            return;
        }
        else
        {
            picks -= picksNeeded;
            ScoreManager.instance.AmountPicks -= picksNeeded;
            pick.SetActive(false);
        }
    }
    //TRUESIGHT METHODS=====================
    public IEnumerator TurnOffTrueSight()
    {
        yield return new WaitForSeconds(5f);
        trueSightDelegateOFF?.Invoke();
    }
    //SCORE METHODS=====================
    public void CollectCoin(int coinWorth)
    {
        ScoreManager.instance.PlayerPoints += coinWorth;
    }

    //EVENT METHODS=====================
    void StopMovement()
    {
        this.gameObject.GetComponent<CharacterController>().enabled = false;
    }
    void ReturnMovement()
    {
        this.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
