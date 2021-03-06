﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float jumpSpeed = 10f;


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.playerPhysics.OverrideVelocity(1, jumpSpeed);
        }
    }
}
