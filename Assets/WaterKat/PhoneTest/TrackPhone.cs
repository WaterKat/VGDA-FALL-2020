using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrackPhone : MonoBehaviour
{

    void Start()
    {
        Input.gyro.enabled = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    void Update()
    {
        transform.localRotation = GyroToUnity(Input.gyro.attitude);

    }
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return Quaternion.Euler(90f, 0f, 0f) * new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
