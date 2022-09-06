using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject inventoryMenuUI;
    public AudioSource audioSound;
    public AudioClip inventorySound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenInventory()
    {
        if (inventoryMenuUI != null)
        {
            audioSound.PlayOneShot(inventorySound, 0.3f);
            bool inventoryOn = inventoryMenuUI.activeSelf;
            inventoryMenuUI.SetActive(!inventoryOn);
            audioSound.PlayOneShot(inventorySound, 0.3f);
        }

    }

}
