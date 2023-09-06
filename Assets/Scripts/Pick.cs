using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    GameObject parent;
    int picksNeeded;
    void Start()
    {
        parent = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            picksNeeded = 1;
            if (parent.GetComponent<Abilities>() != null)
            {
                //Sound
                SoundManager.instance.PickAudio();

                //Break Pick
                other.gameObject.GetComponent<Wall>().UnSubToDelegates();
                Destroy(other.gameObject);
                parent.GetComponent<Abilities>().BreakPick(picksNeeded);
            }
        }
    }
}
