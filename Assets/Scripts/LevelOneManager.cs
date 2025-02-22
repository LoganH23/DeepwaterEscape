using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script manages in-game events that occur in level 1. Specifically,
 * It keeps track of (a) If the 'begin' button has been pressed, which starts
 * the timer, and (b) if the items in the environment have been collected. Once
 * all items in the environment are collected, it actives the gun the player
 * uses to escape
*/
public class LevelOneManager : MonoBehaviour
{
    //variables
    [SerializeField] private bool item1PickedUp;
    [SerializeField] private bool item2PickedUp;
    [SerializeField] private bool item3PickedUp;

    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;

    [SerializeField] private GameObject playerGun;

    //set default level conditions
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        item1PickedUp = false;
        item2PickedUp = false;
        item3PickedUp = false;

        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
    }

    //activate objects when button is pressed
    public void turnOnObjects()
    {
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(true);
    }

    // Check to see if all items are collected
    void Update()
    {
        if(item1PickedUp && item2PickedUp && item3PickedUp)
        {
            playerGun.SetActive(true);
        }
    }

    //setters and getters for each item

    public void setItem1()
    {
        if(item1PickedUp == false)
        {
            item1PickedUp = true;
        }
    }
    public bool getItem1()
    {
        return item1PickedUp;
    }

    public void setItem2()
    {
        if(item2PickedUp == false)
        {
            item2PickedUp = true;
        }
    }
    public bool getItem2()
    {
        return item2PickedUp;
    }

    public void setItem3()
    {
        if (item3PickedUp == false)
        {
            item3PickedUp = true;
        }
    }
    public bool getItem3()
    {
        return item3PickedUp;
    }
}
