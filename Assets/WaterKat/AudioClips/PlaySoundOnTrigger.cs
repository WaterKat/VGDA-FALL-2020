using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioSource entrySound;
    public AudioSource exitSound;

    public bool triggerEnter = true;
    public bool triggerExit = true;
    public bool Replay = false;
    private bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerEnter||alreadyPlayed)
            return;

        if (other.gameObject.tag == "Player")
        {
            entrySound.Play();
        }

        if ((!Replay)&&(!triggerExit))
        {
            alreadyPlayed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!triggerExit||alreadyPlayed)
            return;

        if (other.gameObject.tag == "Player")
        {
            exitSound.Play();
        }

        if (!Replay)
        {
            alreadyPlayed = true;
        }
    }
}
