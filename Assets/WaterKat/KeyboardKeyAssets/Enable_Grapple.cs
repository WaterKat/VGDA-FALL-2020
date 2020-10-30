using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Grapple : MonoBehaviour
{
    public GameObject grappleUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Grapple grapple = other.gameObject.GetComponent<Grapple>();
            if (grapple != null)
            {
                grapple.GrappleEnabled = true;
                grappleUI.SetActive(true);
                this.enabled = false;
                GetComponent<Light>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
