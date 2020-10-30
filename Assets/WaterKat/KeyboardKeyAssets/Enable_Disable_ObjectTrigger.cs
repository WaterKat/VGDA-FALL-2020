using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Disable_ObjectTrigger : MonoBehaviour
{
    public GameObject targetObject;

    public bool triggerEnter = true;
    public bool triggerExit = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerEnter)
            return;

        if (other.gameObject.tag == "Player")
        {
            targetObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!triggerExit)
            return;

        if (other.gameObject.tag == "Player")
        {
            targetObject.SetActive(false);
        }
    }
}
