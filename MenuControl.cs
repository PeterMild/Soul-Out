using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public AudioSource audioSound;
    public AudioClip start;
    public void onStartClick()
    {
        SceneManager.LoadScene("PrepareMenu");
        audioSound.PlayOneShot(start, 0.7f);
    }
}
