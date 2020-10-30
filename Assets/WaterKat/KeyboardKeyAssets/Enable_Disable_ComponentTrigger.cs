using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Disable_ComponentTrigger : MonoBehaviour
{
    public Component targetComponent;

    public bool triggerEnter = true;
    public bool triggerExit = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerEnter)
            return;

        if (other.gameObject.tag == "Player")
        {
         //   targetComponent.
           // targetComponent.enabled =
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!triggerExit)
            return;

        if (other.gameObject.tag == "Player")
        {
          //  targetComponent.SetActive(false);
        }
    }
}
