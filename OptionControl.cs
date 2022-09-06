using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionControl : MonoBehaviour
{
    public GameObject OptionMenuUI;
    public AudioSource audioSound;
    public AudioClip OptionSound;
    public AudioClip confirmSound;
    [SerializeField] Slider VolumeSlider;

    public GameObject flipJumpSlide;

        void Start()
    {

    }

    // Update is called once per frame
    public void OpenOption()
    {
        if (OptionMenuUI != null)
        {
            audioSound.PlayOneShot(OptionSound,0.7f);
            bool OptionOn = OptionMenuUI.activeSelf;
            audioSound.PlayOneShot(OptionSound,0.7f);
            OptionMenuUI.SetActive(!OptionOn);
        }

    }


    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
    }

    public void FlipJumpSlide()
    {
        if (flipJumpSlide != null)
        {
            bool FlipOn = flipJumpSlide.activeSelf;
            flipJumpSlide.SetActive(!FlipOn);
        }
        
    }

}
