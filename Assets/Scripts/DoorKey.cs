using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    private bool inRange = false;
    private PlayerController player;
    public AudioSource audio;
    public GameObject card_UI;

    public bool isPickedUp = false;


    private void Start()
    {
        GetComponentInChildren<TMP_Text>().enabled = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        card_UI.SetActive(false);
    }

    private void Update()
    {
        if (inRange && player.interact.triggered)
        {
            audio.Play();
            card_UI.SetActive(true);
            Destroy(this.gameObject);
            //GetComponentInChildren<TMP_Text>().text = "Picked up Key";
            isPickedUp = true;
        }
    }

    // Player Approaches Power Bank
    private void OnTriggerEnter(Collider other)
    {
        if (player == other.gameObject.GetComponent<PlayerController>())
        {
            GetComponentInChildren<TMP_Text>().enabled = true;
            inRange = true;
        }
    }

    // Player Leaves Power Bank
    private void OnTriggerExit(Collider other)
    {
        if (player == other.gameObject.GetComponent<PlayerController>())
        {
            GetComponentInChildren<TMP_Text>().enabled = false;
            inRange = false;
        }
    }
}
