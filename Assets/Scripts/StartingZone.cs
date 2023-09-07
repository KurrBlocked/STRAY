using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingZone : MonoBehaviour
{
    private Collider collider;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.PowerBanks >= 4)
            {
                player.win = true;
            }
        }
    }
}
