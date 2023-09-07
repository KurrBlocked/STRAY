using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpener : MonoBehaviour
{
    public DoorKey key; //Requires a manual reference of the proper key card
    private PlayerController player;
    private bool inRange = false;
    private bool closed = true;
    public GameObject door_obstruct;
    private Quaternion original_Rot;
    private AudioSource audio;

    [System.Obsolete]
    private void Start()
    {
        transform.FindChild("Text (1)").GetComponent<TMP_Text>().enabled = false;
        GetComponentInChildren<TMP_Text>().enabled = false;
        original_Rot = transform.FindChild("Text (1)").rotation;
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        //door_obstruct.isStatic = true;
        audio = GetComponent<AudioSource>();
    }

    [System.Obsolete]
    private void Update()
    {
        if (key.isPickedUp)
        {
            if (closed)
            {
                GetComponentInChildren<TMP_Text>().text = "Open the Door";
                transform.FindChild("Text (1)").GetComponent<TMP_Text>().text = "Open the Door";
                transform.FindChild("Text (1)").GetComponent<Billboard>().enabled = false;
                transform.FindChild("Text (1)").rotation = original_Rot;
            }
            else
            {
                //GetComponentInChildren<TMP_Text>().text = "Close the Door";
                GetComponentInChildren<TMP_Text>().text = "";
                transform.FindChild("Text (1)").GetComponent<TMP_Text>().text = "Close the Door";
                transform.FindChild("Text (1)").GetComponent<Billboard>().enabled = true;
            }
        }
        if (inRange && player.interact.triggered && key.isPickedUp)
        {
            if (closed)
            {
                //door_obstruct.isStatic = false;
                door_obstruct.transform.Translate(new Vector3(-18, 0, 0));//moves door

                //moves text to seeable position
                //GetComponentInChildren<TMP_Text>().transform.Translate(new Vector3(0, 0, 0));
                //transform.FindChild("Text (1)").transform.Translate(new Vector3(0, 0, 0));
                closed = false;

                //door_obstruct.isStatic = true;
                //NavMeshBuilder.UpdateNavMeshData();
            }
            else 
            {
                //door_obstruct.isStatic = false;
                door_obstruct.transform.Translate(new Vector3(18, 0, 0));//moves door

                //moves text to seeable position
                //GetComponentInChildren<TMP_Text>().transform.Translate(new Vector3(-18, 0, 0));
                //transform.FindChild("Text (1)").transform.Translate(new Vector3(-18, 0, 0));
                closed = true;

                //door_obstruct.isStatic = true;
                //NavMeshBuilder.UpdateNavMeshData();
            }
            audio.Play();
        }
    }

    // Player Approaches Power Bank
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (player == other.gameObject.GetComponent<PlayerController>())
        { 
            transform.FindChild("Text (1)").GetComponent<TMP_Text>().enabled = true;
            GetComponentInChildren<TMP_Text>().enabled = true;
            inRange = true;
        }
    }

    // Player Leaves Power Bank
    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        if (player == other.gameObject.GetComponent<PlayerController>())
        {
            transform.FindChild("Text (1)").GetComponent<TMP_Text>().enabled = false;
            GetComponentInChildren<TMP_Text>().enabled = false;
            inRange = false;
        }
    }
}
