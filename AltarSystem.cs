using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSystem : MonoBehaviour
{
    public GameObject AltarMenuUI;
    public AudioSource audioSound;
    public AudioClip AltarMenuSound;
    public AudioClip confirmSound;




    void Start()
    {

    }

    // Update is called once per frame
    public void OpenAltar()
    {
        if (AltarMenuUI != null)
        {
            audioSound.PlayOneShot(AltarMenuSound, 0.7f);
            bool MenuOn = AltarMenuUI.activeSelf;
            audioSound.PlayOneShot(AltarMenuSound, 0.7f);
            AltarMenuUI.SetActive(!MenuOn);
        }

    }

}
