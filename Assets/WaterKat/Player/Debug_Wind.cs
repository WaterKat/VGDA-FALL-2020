using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Wind : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public Vector3 windVelocity = new Vector3(-10, 0, 0);
    public float velocityThreshold = 2f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rigidbody.velocity.magnitude>velocityThreshold)
            rigidbody.AddForce(windVelocity);
    }
}
