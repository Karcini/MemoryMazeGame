using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script has been replaced by DoorAnim.cs
    //Keeping it for just to see the drastic improvement in complexity
public class Door : MonoBehaviour
{
    GameObject doorsLever;
    public Transform playerTransform;
    bool canOpenDoor = false;
    bool pulled = false;
    void Start()
    {
        GetLever();
    }
    void Update()
    {
        canOpenDoor = CanOpenDoor();
        if (canOpenDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerTransform.gameObject.GetComponent<Abilities>().canOpenDoor = false;
                doorsLever.GetComponent<DoorLever>().Open();
            }
        }
        CheckLeverStatus();
    }

    void GetLever()
    {
        //Lever should be 1st Child of Door
        doorsLever = transform.GetChild(0).gameObject;
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
    void CheckLeverStatus()
    {
        if (doorsLever.GetComponent<DoorLever>().leverPulled)
        {
            if (!pulled)
            {
                //Lever was pulled
                pulled = true;
                SwitchTimer();
                StartCoroutine(LeverAnim());
                StartCoroutine(DoorAnim());
            }
        }
    }
    public IEnumerator DoorAnim()
    {
        //lots of fixed values since we know dimensions of door
        float end = -4.6f;
        float speed = 15f;
        Transform OrigLocation = this.gameObject.transform;
        Vector3 endLocation = new Vector3(OrigLocation.position.x, end, OrigLocation.position.z);

        while (true)
        {
            float dt = Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, endLocation, dt * speed);
            yield return new WaitForSeconds(0.3f);

            if (transform.position.y < end+.05f)
                Destroy(this.gameObject);
        }
    }
    public IEnumerator LeverAnim()
    {
        Transform OrigLocation = doorsLever.gameObject.transform;
        Transform endLocation = transform.GetChild(1).gameObject.transform;

        doorsLever.gameObject.transform.eulerAngles = endLocation.rotation.eulerAngles;

        yield return null;
    }

    void SwitchTimer()
    {
        if (ScoreManager.instance.TimeActivated)
            ScoreManager.instance.TimeActivated = false;
        else
            ScoreManager.instance.TimeActivated = true;
    }
}
