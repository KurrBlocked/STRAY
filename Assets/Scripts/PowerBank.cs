using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerBank : MonoBehaviour
{
    private bool inRange = false;
    private PlayerController player;
    public InventoryItemData ItemData;
    private AudioSource audio;
    private bool hasBeenCollected = false;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().enabled = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var inventory = player.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inRange && player.interact.triggered && !hasBeenCollected)
        {
            if (inventory.InventorySystem.AddToInventory(ItemData, 1))
            {
                //add sound effect here
                audio.Play(0);
                Destroy(transform.Find("Supply").gameObject);
                hasBeenCollected = true;
            }

            GetComponentInChildren<TMP_Text>().text = "No More Power Banks";
            player.PowerBanks++;
        }
    }

    // Player Approaches Power Bank
    private void OnTriggerEnter(Collider other)
    {
        if (player == other.gameObject.GetComponent<PlayerController>())
        {
            if (!hasBeenCollected) {
                GetComponentInChildren<TMP_Text>().enabled = true;
                inRange = true;
            }
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
