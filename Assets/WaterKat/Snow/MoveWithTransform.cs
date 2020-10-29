using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTransform : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private Vector3 offset;

    void Update()
    {
        transform.position = targetTransform.position + offset;    
    }
}
