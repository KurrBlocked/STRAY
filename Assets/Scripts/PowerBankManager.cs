using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBankManager : MonoBehaviour
{
    public GameObject PowerBanks;
    public InventoryItemData[] icons;
    private List<GameObject> pbs;

    void Start()
    {
        pbs = new List<GameObject>();
        for (int i = 0; i < PowerBanks.transform.childCount; i++)
        {
            GameObject child = PowerBanks.transform.GetChild(i).gameObject;
            pbs.Add(child);
            child.transform.GetChild(0).GetComponent<PowerBank>().ItemData = icons[Random.Range(0, 9)];
            child.SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, pbs.Count);
            pbs[rand].SetActive(true);
            pbs.RemoveAt(rand);
        }
    }
}
