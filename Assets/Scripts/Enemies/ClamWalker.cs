using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/*
 * This script handles the clam 
*/

public class Clam_Walker : MonoBehaviour
{
    private bool isAggro = false;
    public NavMeshAgent clamNavAgent;
    public Transform navTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clamNavAgent.destination = navTarget.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAggro = true;
        }
    }
}
