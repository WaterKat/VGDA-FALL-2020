using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Walk walk;

    private void Update()
    {
        walk.enabled = !pullTowardsGrapple;

        targetGrapple = FindGrapple();

        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetMouseButtonUp(0))
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
            player.characterController.Move(Vector3.ClampMagnitude((target.position - transform.position)/Time.deltaTime,grappleSpeed)*Time.deltaTime);
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
