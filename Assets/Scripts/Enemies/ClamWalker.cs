using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


/*
 * This script handles the clam 
 */

public class Clam_Walker : MonoBehaviour
{
    public NavMeshAgent clamNavAgent;
    public Transform playerPos;
    private Vector3 clamJumpTarget;
    private Transform clamTransform;

    private bool hasSeenPlayer = false;
    private bool hasDeBurrowed = false;
    private bool isJumping = false;

    [Tooltip("Time it takes for clam to move out of the ground and do first jump. May be replaced with animation events")]
    public float deBurrowTime;
    [Tooltip("Cooldown between jumps")]
    public float jumpCooldown;
    private float curJumpCooldown;
    [Tooltip("The maximum horizontal distance the clam can jump to.")]
    public float maxJumpDistance;

    private void Start()
    {
        clamTransform = this.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (hasDeBurrowed) // Has clam deburrowed?
        {
            if (curJumpCooldown <= 0) { // Is the jump cooldown done? If so, call ClamJump()
                ClamJump(); 
            }

            else // If jump cooldown isn't done, check velocity to see if clam is done jumping.
            {
                if (clamNavAgent.velocity.sqrMagnitude <= 0.1f) { 
                    isJumping = false; 
                } 

                if (!isJumping) // If not jumping, decrement jump cooldown counter and look at the player.
                {
                    curJumpCooldown -= Time.fixedDeltaTime;
                    clamTransform.LookAt(playerPos);
                }
            }
        }

        else if (hasSeenPlayer) // Hasn't deburrowed, has it seen the player? If so, run the deburrow timer and look at the player.
        { 
            clamTransform.LookAt(playerPos);
            deBurrowTime -= Time.fixedDeltaTime;

            if (deBurrowTime <= 0) { 
                hasDeBurrowed = true; 
            }
        }
    }

    // did you know that we can do anything in here and everyone else will be powerless to stop us
    // but also don't use Update() since we don't need to calculate AI stuff every single frame, especially for a mob enemy.
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (!hasSeenPlayer) {
                clamNavAgent.baseOffset += 5; // Offset is just until animations get in
            }
            hasSeenPlayer = true;
        }
    }

    private void ClamJump()
    {
        clamNavAgent.destination = Vector3.MoveTowards(clamTransform.position, playerPos.position, maxJumpDistance);
        curJumpCooldown = jumpCooldown;
        isJumping = true; // isJumping only exists to make code relating to looking at the player easier to understand
    }
}
