﻿using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator animator;
    bool doorOpen;

    private void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            doorOpen = true;
            Doors("Open");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (doorOpen)
        {
            doorOpen = false;
            Doors("Close");
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }

}
