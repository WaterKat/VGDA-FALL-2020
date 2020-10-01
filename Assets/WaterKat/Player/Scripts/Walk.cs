using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private float walkSpeed = 10f;

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float rotationAngle = player.cameraContainer.rotation.eulerAngles.y;

        Vector3 rotatedInput = Quaternion.Euler(0, rotationAngle, 0) * input;

        player.characterController.SimpleMove(rotatedInput * walkSpeed);
    }
}
