using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBtn : MonoBehaviour
{
    public void onStartClick()
    {
        SceneManager.LoadScene("BossScene");

    }
}
