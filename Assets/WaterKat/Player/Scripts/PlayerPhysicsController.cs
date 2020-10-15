using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float maxHorizontalSpeed = 10f;
    [SerializeField]
    private float maxHorizontalAcceleration = 10f;
    private float horizontalCoefficient = 0f;

    [SerializeField]
    private float maxVerticalSpeed = 10f;
    [SerializeField]
    private float maxVerticalAcceleration = 10f;
    private float verticalCoefficient = 0f;

    [SerializeField]
    private bool useGlobalGravity = true;
    [SerializeField]
    private Vector3 localGravity = Vector3.down * 10f;

    private Vector3 addedVelocity = Vector3.zero;

    [SerializeField]
    private float quickBrakeThreshold = 5f;

    private void Start()
    {
        horizontalCoefficient = 2 * maxHorizontalAcceleration / Mathf.Pow(maxHorizontalSpeed, 2);
        verticalCoefficient = 2 * maxVerticalAcceleration / Mathf.Pow(maxVerticalSpeed, 2);
    }

    private void FixedUpdate()
    {
        Vector3 currentVelocity = player.rigidbody.velocity;

        if (useGlobalGravity)
        {
            addedVelocity += Physics.gravity;
        }

        float xDrag = horizontalCoefficient * -Mathf.Sign(currentVelocity.x) * Mathf.Pow(currentVelocity.x, 2) / 2f;
        float zDrag = horizontalCoefficient * -Mathf.Sign(currentVelocity.z) * Mathf.Pow(currentVelocity.z, 2) / 2f;

        float yDrag = verticalCoefficient * -Mathf.Sign(currentVelocity.y) * Mathf.Pow(currentVelocity.y, 2) / 2f;

        if (currentVelocity.magnitude < quickBrakeThreshold)
        {
            xDrag *= Mathf.Lerp(0f, 15f, currentVelocity.magnitude / quickBrakeThreshold);
            zDrag *= Mathf.Lerp(0f, 15f, currentVelocity.magnitude / quickBrakeThreshold);
        }
        if (currentVelocity.magnitude<0.5f)
        {
            OverrideVelocity(0, 0f);
            OverrideVelocity(2, 0f);
        }

        player.rigidbody.velocity += (addedVelocity + new Vector3(xDrag, yDrag, zDrag)) * Time.fixedDeltaTime;

        addedVelocity = Vector3.zero;
    }

    public void AddVelocity(Vector3 vector3)
    {
        addedVelocity += vector3;
    }

    public void OverrideVelocity(Vector3 vector3)
    {
        player.rigidbody.velocity = vector3;
    }

    public void OverrideVelocity(int id, float input)
    {
        Vector3 localvel = player.rigidbody.velocity;
        switch (id)
        {
            case 0:
                localvel.x = input;
                player.rigidbody.velocity = localvel;
                break;
            case 1:
                localvel.y = input;
                player.rigidbody.velocity = localvel;
                break;
            case 2:
                localvel.z = input;
                player.rigidbody.velocity = localvel;
                break;
            default:
                Debug.LogError("OverrideVelocity ID not valid!");
                break;
        }
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 100, 20), "Velocity: " + player.rigidbody.velocity.magnitude);
    }
}
