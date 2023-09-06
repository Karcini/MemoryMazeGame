using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Pick : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Abilities>() != null)
            {
                other.gameObject.GetComponent<Abilities>().picks += 1;
                ScoreManager.instance.AmountPicks += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
