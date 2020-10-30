using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WaterKat.Player_N;

public class HyperSense : MonoBehaviour
{
    [SerializeField]
    private bool hyperSenseActive = false;

    //[SerializeField]
    //private Camera mainCam;
    [SerializeField]
    private GameObject hyperCam;
    [SerializeField]
    private Volume volume;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            hyperSenseActive = !hyperSenseActive;
            //            mainCam.enabled = !hyperSenseActive;
            if (hyperSenseActive)
            {
                WaterKat.Audio.AudioManager.PlaySound("SniffSniff");
            }
        }

        if (hyperSenseActive)
        {
            volume.weight += Time.deltaTime;
        }
        else
        {
            volume.weight -= Time.deltaTime;
        }
        volume.weight = Mathf.Clamp(volume.weight, 0, 1);
        if (volume.weight == 0)
        {
            hyperCam.SetActive(false);
        }
        else
        {
            hyperCam.SetActive(true);

        }
    }
}
