using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _health = 100f;
    public float health
    {
        get { return _health; }
    }

    [SerializeField]
    private float _maxhealth = 100f;
    public float maxHealth
    {
        get { return _maxhealth; }
    }

    [SerializeField]
    private Transform _cameraContainer;
    public Transform cameraContainer
    {
        get
        {
            return _cameraContainer;
        }
    }

    [SerializeField]
    private Camera _camera;
    public new Camera camera
    {
        get
        {
            return _camera;
        }
    }
    /*
        [SerializeField]
        private CharacterController _characterController;
        public CharacterController characterController
        {
            get
            {
                return _characterController;
            }
        }
    */
    [SerializeField]
    private Rigidbody _rigidbody;
    public new Rigidbody rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }

    [SerializeField]
    private PlayerPhysicsController _playerPhysics;
    public  PlayerPhysicsController playerPhysics
    {
        get
        {
            return _playerPhysics;
        }
    }

    #region "Grounded"
    public bool Grounded = false;
    public float GroundDistance = 0.15f;
    float SphereRadius = 0.6f;

    public bool CheckIfGrounded()
    {
        bool Grounded = false;
        Ray downwards = new Ray(transform.position+(Vector3.up*(SphereRadius+0.05f)), Vector3.down);
        RaycastHit hit;
        if (Physics.SphereCast(downwards, SphereRadius, out hit, GroundDistance))
        {
            if (!hit.collider.isTrigger)
            {
                Grounded = true;
            }
        }
        return Grounded;
    }
    public bool CheckIfGrounded(out Vector3 _groundVelocity)
    {
        bool Grounded = false;
        Ray downwards = new Ray(transform.position + (Vector3.up * (SphereRadius + 0.05f)), Vector3.down);

        RaycastHit hit;
        if (Physics.SphereCast(downwards, SphereRadius, out hit, GroundDistance))
        {
            if (!hit.collider.isTrigger)
            {
                Grounded = true;
                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    _groundVelocity = rb.velocity;
                }
            }
        }
        _groundVelocity = Vector3.zero;
        return Grounded;
    }
    #endregion

    private void Update()
    {
        Grounded = CheckIfGrounded();
    }
}
