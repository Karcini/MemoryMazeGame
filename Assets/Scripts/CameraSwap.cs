using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The main mechanic has the player alternate between 1stPersp./Isometric views
    //Player needs both CameraSwap and CameraLook to operate Viewing
public class CameraSwap : MonoBehaviour
{
    public enum CameraPosition
    {
        One,
        Two,
        Three
    }
    public CameraPosition camPos = CameraPosition.One;

    public Camera playerCam;
    public GameObject[] camLocations;
    public float camChangeSpeed = 20;
    public Transform target;

    public bool currentlyUsingSight = false;

    void Start()
    {
        TargetCam();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool canUse = SpiritFormSight();
            if(canUse)
            {
                if (camPos == CameraPosition.One)
                {
                    camPos = CameraPosition.Two;
                    StartCoroutine(SwapCam());
                }
            }
        }
        TargetCam();
        float dt = Time.deltaTime;
        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, target.position, dt * camChangeSpeed);
    }

    void TargetCam()
    {
        for (int x=0; x<camLocations.Length; x++)
        {
            if (x == (int)camPos)
                target = camLocations[x].transform;
        }
    }
    IEnumerator SwapCam()
    {
        yield return new WaitForSeconds(5f);
        camPos = CameraPosition.One;
        currentlyUsingSight = false;
    }
    bool SpiritFormSight()
    {
        Abilities ability = transform.gameObject.GetComponent<Abilities>();
        if (ability.spiritFormSight > 0 && currentlyUsingSight == false)
        {
            currentlyUsingSight = true;
            ability.spiritFormSight -= 1;
            ScoreManager.instance.AmountSpiritForm -= 1;
            return true;
        }
        else if (ability.spiritFormSight <= 0)
        {
            Debug.Log("You have run out of Spirit Form energy.  Any more and you'd leave your body for good.");
            return false;
        }
        else
        {
            return false;
        }
    }
}
