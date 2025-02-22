﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public float interactDistance = 20f;


    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();
                    if (doorScript == null) return;

                    if (Inventory.keys[doorScript.index] == true)
                    {
                        doorScript.ChangeDoorState();
                    }
                }
                else if (hit.collider.CompareTag("Key"))
                {
                    Inventory.keys[hit.collider.GetComponent<Key>().index] = true;
                    Destroy(hit.collider.gameObject);
                }
            }




        }
    }
}