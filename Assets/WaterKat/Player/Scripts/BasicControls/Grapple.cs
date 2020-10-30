using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterKat.Player_N;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public float maxGrappleDistance = 20f;

    private float grappleSpreadRange = 80f;

    private Vector2 screenSize;

    [SerializeField]
    private float grappleSpeed = 10f;
    private void Start()
    {
        screenSize = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private bool pullTowardsGrapple = false;
    private Coroutine pullCoroutine = null;
    private GameObject targetGrapple = null;
    private GameObject currentPullGrapple = null;

    public Running running;
    public Jump jump;

    private int inputMouseButton = 2;


    public bool GrappleEnabled = true;

    private void Update()
    {
        running.enabled = !pullTowardsGrapple;
        jump.enabled = !pullTowardsGrapple;

        targetGrapple = FindGrapple();

        if (!GrappleEnabled)
            return;

        if (Input.GetMouseButtonDown(inputMouseButton))
        {
            currentPullGrapple = targetGrapple;
            if (currentPullGrapple != null)
            {
                if (pullCoroutine != null)
                    StopCoroutine(pullCoroutine);

                pullTowardsGrapple = true;
                pullCoroutine = StartCoroutine(pullTowardsTarget(currentPullGrapple.transform));
            }
        }
        if (Input.GetMouseButtonUp(inputMouseButton))
        {
            if (pullCoroutine != null)
                StopCoroutine(pullCoroutine);
            pullTowardsGrapple = false;
        }
    }

    IEnumerator pullTowardsTarget(Transform target)
    {

        while (pullTowardsGrapple)
        {
            Debug.Log("pulling");
            player.rigidbody.velocity = Vector3.ClampMagnitude((target.position+(Vector3.down*2) - transform.position) / Time.deltaTime, grappleSpeed) ;
            yield return null;
        }
    }

    private GameObject FindGrapple()
    {
        GameObject[] grappleTargets = GameObject.FindGameObjectsWithTag("GrappleLocation");

        float closestGrappleSpread = 10000f;
        GameObject closestGrapple = null;

        foreach (var _grapple in grappleTargets)
        {
            float distanceFromGrapple = Vector3.Distance(player.camera.transform.position, _grapple.transform.position);
            if (distanceFromGrapple < maxGrappleDistance)
            {
                //Debug.Log(item.name + " is within Distance");

                float spreadToGrapple = ((Vector2)Camera.main.WorldToScreenPoint(_grapple.transform.position) - screenSize).magnitude;

                if (spreadToGrapple < grappleSpreadRange)
                {
                    //Debug.Log(item.name + " is within spread at " + spreadToGrapple);
                    
                    if (!Physics.Raycast(player.camera.transform.position, _grapple.transform.position - player.camera.transform.position, distanceFromGrapple))
                    {
                        if (spreadToGrapple < closestGrappleSpread)
                        {
                            closestGrappleSpread = spreadToGrapple;
                            closestGrapple = _grapple;
                        }
                    }
                }

                _grapple.GetComponent<Grapple_Environment>().ChangeColorWithinRange();
            }
            else
            {
                _grapple.GetComponent<Grapple_Environment>().ChangeColorOutOfRange();
            }
        }

        if (closestGrapple != null)
        {
            closestGrapple.GetComponent<Grapple_Environment>().ChangeColorActive();

            Debug.Log(closestGrapple.name+" is targeted");
        }

        return closestGrapple;
    }
}
