using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using WaterKat.Audio;

namespace WaterKat.Player_N
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody))]

    public class Running : MonoBehaviour
    {
        Player currentPlayer;

        Rigidbody currentRigidbody;


        public float runningMaxVelocity = 30;
        public float runningAcceleration = 80;
        private float runningDragMultiplier;

        public float groundedBrakeAcceleration = 80;
        public float flyingBrakeAcceleration = 20;

        private bool sandStepPlaying = false;
        private float stepDelay = 0.4f;

        private void Awake()
        {
            currentPlayer = GetComponent<Player>();
        }

        void Start()
        {
            currentRigidbody = GetComponent<Rigidbody>();
            runningDragMultiplier = (-2 * runningAcceleration) / Mathf.Pow(runningMaxVelocity, 2);
        }

        private void OnEnable()
        {
            currentRigidbody = GetComponent<Rigidbody>();
            runningDragMultiplier = (-2 * runningAcceleration) / Mathf.Pow(runningMaxVelocity, 2);
        }

        private Vector3 currentPlayerVelocity = Vector3.zero;

        private Vector3 playerInput = Vector3.zero;

        private Quaternion cameraRotation = Quaternion.identity;

        private Vector3 runningAccelerationVector = Vector3.zero;
        private Vector3 runningDragAccelerationVector = Vector3.zero;

        private Vector3 brakeAccelerationVector = Vector3.zero;

        private float brakeAcceleration = 0;

        void Update()
        {
            PlayRandomSandStep();

            currentPlayerVelocity = currentRigidbody.velocity;
            currentPlayerVelocity.y = 0;

            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.z = Input.GetAxis("Vertical");

            playerInput.Normalize();

            cameraRotation = Quaternion.Euler(0, currentPlayer.camera.transform.rotation.eulerAngles.y, 0);

            runningAccelerationVector = cameraRotation * playerInput * runningAcceleration * Time.deltaTime;
            runningDragAccelerationVector = 0.5f * runningDragMultiplier * currentPlayerVelocity.normalized * Mathf.Pow(currentPlayerVelocity.magnitude, 2) * Time.deltaTime;

            if (currentPlayer.Grounded)
            {
                brakeAcceleration = groundedBrakeAcceleration;
            }
            else
            {
                brakeAcceleration = flyingBrakeAcceleration;
            }
            brakeAccelerationVector = Vector3.Project(currentPlayerVelocity, (cameraRotation * playerInput).normalized) - currentPlayerVelocity;
            brakeAccelerationVector = Vector3.ClampMagnitude(brakeAccelerationVector, brakeAcceleration * Time.deltaTime);

            /*
            Debug.DrawLine(transform.position, transform.position + brakeAccelerationVector, Color.red, .1f);
            Debug.DrawLine(transform.position, transform.position + (runningAccelerationVector / Time.deltaTime), Color.blue, .1f);
            Debug.DrawLine(transform.position, transform.position + (currentPlayerVelocity), Color.white, .1f);
            Debug.Log("Input: " + playerInput);
            Debug.Log("Brake: " + brakeAccelerationVector);
            */

            currentRigidbody.velocity += runningAccelerationVector + runningDragAccelerationVector + brakeAccelerationVector;
        }

        private void PlayRandomSandStep()
        {
            if (currentPlayer.Grounded && playerInput.magnitude > 0)
            {
                if (!sandStepPlaying)
                {
                    StartCoroutine(PlaySingleSandStep());
                }
            }
        }

        private IEnumerator PlaySingleSandStep()
        {
            sandStepPlaying = true;
            //AudioManager.PlaySound("PlayerSandStep" + Random.Range(1, 4));
            yield return new WaitForSeconds(stepDelay);
            sandStepPlaying = false;
        }
    }
}