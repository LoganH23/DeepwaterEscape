using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles object collection. It is attached to an object
 * that the player should be able to collect. A UI element will display
 * upon collection. When the given 'pick-up' button is clicked, the object
 * is destroyed and the UI element is set inactive
*/
public class ObjectPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrompt;
    private bool promptOn;

    private void Awake()
    {
        pickupPrompt.SetActive(false);
        promptOn = false;
    }

    private void Update()
    {
        if(promptOn == true && Input.GetKeyDown(KeyCode.E))
        {
            promptOn = false;
            pickupPrompt.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupPrompt.SetActive(true);
            promptOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupPrompt.SetActive(false);
            promptOn = false;
        }
    }
}
