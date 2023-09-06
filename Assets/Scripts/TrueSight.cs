using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Known Bug
    //For SOME REASON, making this object turn itself off in anyway or destroy itself results in errors that prevents..
    //..the loading of every object during the maze Load.
    //Gridpoint loads objects, grid constructor makes gridpoints
public class TrueSight : MonoBehaviour
{
    Abilities ability;
    void Start()
    {
        //FixMist();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.gameObject.GetComponent<Abilities>() != null)
            {
                //SoundOn
                SoundManager.instance.MistAudio();

                ability = other.gameObject.GetComponent<Abilities>();
                //ability.trueSightDelegateOFF += DestroyMist;
                ability.trueSightAvailable = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Abilities>() != null)
            {
                //SoundOff
                SoundManager.instance.MistAudioStop();

                ability = other.gameObject.GetComponent<Abilities>();
                //ability.trueSightDelegateOFF -= DestroyMist;
                ability.trueSightAvailable = false;
            }
        }
    }
    void DestroyMist()
    {
        //this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }
    void FixMist()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
