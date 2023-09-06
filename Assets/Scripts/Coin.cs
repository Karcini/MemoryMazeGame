using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Script assumes it is a collider within object parent
    GameObject parent;
    Animator animator;
    [SerializeField]
    int points = 1;
    void Start()
    {
        GteParent();
    }
    void GteParent()
    {
        parent = transform.parent.gameObject;
        animator = parent.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoreManager.instance.Player.CollectCoin(points);
            SoundManager.instance.CoinAudio();
            //other.GetComponent<Abilities>().CollectCoin(points);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            //Destroy(parent); after we trigger animation
            animator.SetTrigger("CoinPickup");
            Destroy(parent, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
