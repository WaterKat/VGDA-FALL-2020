using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_HyperSense : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HyperSense hypersense = other.gameObject.GetComponent<HyperSense>();
            if (hypersense != null)
            {
                hypersense.enabled = true;
                this.enabled = false;
            }
        }
    }
}
