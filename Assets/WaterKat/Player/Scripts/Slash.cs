using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Animator swordAnimator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swordAnimator.SetTrigger("Slash");
        }
    }
}
