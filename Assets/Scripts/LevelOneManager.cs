using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    [SerializeField] private bool item1PickedUp;
    [SerializeField] private bool item2PickedUp;
    [SerializeField] private bool item3PickedUp;

    [SerializeField] private GameObject playerGun;

    private void Awake()
    {
        item1PickedUp = false;
        item2PickedUp = false;
        item3PickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(item1PickedUp && item2PickedUp && item3PickedUp)
        {
            playerGun.SetActive(true);
        }
    }

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
