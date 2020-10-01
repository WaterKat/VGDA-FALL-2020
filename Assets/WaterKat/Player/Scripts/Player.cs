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

    [SerializeField]
    private CharacterController _characterController;
    public CharacterController characterController
    {
        get
        {
            return _characterController;
        }
    }

}
