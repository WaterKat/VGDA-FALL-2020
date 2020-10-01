using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float jumpSpeed = 1f;


    void Update()
    {
        if (Input.GetButtonDown("Jump")&&player.characterController.isGrounded)
        {
            player.characterController.Move(Vector3.up * jumpSpeed);
        }
    }
}
