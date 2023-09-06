using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPad : MonoBehaviour
{
    Move movement;
    public float boostStrength = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            movement = other.gameObject.GetComponent<Move>();
            StartCoroutine(Boost());
        }
    }
    public IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        movement.NullVelocity();
        movement.AddVelocity(boostStrength * Vector3.up);

        //Sound
        SoundManager.instance.EagleAudio();

        //Destroy Boost After Using
        DestroyBoosts();
    }
    public void DestroyBoosts()
    {
        Destroy(this.gameObject);
    }
}
