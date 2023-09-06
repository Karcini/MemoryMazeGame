using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detects if this object is colliding with a wall
public class Feeler : MonoBehaviour
{
    public bool collided = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
            collided = true;
    }
}
