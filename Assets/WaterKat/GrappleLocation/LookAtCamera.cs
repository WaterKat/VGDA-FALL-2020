﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LookAtCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
