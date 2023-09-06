using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public Transform playerTransform;
    public Animator animator;
    bool canOpenDoor = false;
    bool pulled = false;

    public AudioSource gateOpen;
    public AudioSource gateClose;


    void Update()
    {
        canOpenDoor = CanOpenDoor();
        if (canOpenDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!pulled)//Open Door
                {
                    pulled = true;
                    playerTransform.gameObject.GetComponent<Abilities>().canOpenDoor = false;
                    //Trigger animation
                    animator.SetTrigger("GateLeverTrigger");
                    gateOpen.Play();
                    //Trigger Timer
                    ScoreManager.instance.TimeActivated = true;
                }
                else//Close Door
                {
                    pulled = false;
                    playerTransform.gameObject.GetComponent<Abilities>().canOpenDoor = true;
                    animator.SetTrigger("GateCloseTrigger");
                    gateClose.Play();
                }
            }
        }
    }

    bool CanOpenDoor()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 3)
        {
            playerTransform.gameObject.GetComponent<Abilities>().canOpenDoor = true;
            return true;
        }
        else
            playerTransform.gameObject.GetComponent<Abilities>().canOpenDoor = false;
        return false;
    }
}
