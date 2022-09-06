using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : MonoBehaviour
{
    public GameObject CharacterMenuUI;
    public AudioSource audioSound;
    public AudioClip CharacterMenuSound;
    public AudioClip confirmSound;
    

    

    void Start()
    {

    }

    // Update is called once per frame
    public void OpenCharacter()
    {
        if (CharacterMenuUI != null)
        {
            audioSound.PlayOneShot(CharacterMenuSound, 0.7f);
            bool MenuOn = CharacterMenuUI.activeSelf;
            audioSound.PlayOneShot(CharacterMenuSound, 0.7f);
            CharacterMenuUI.SetActive(!MenuOn);
        }

    }


    

   

}
