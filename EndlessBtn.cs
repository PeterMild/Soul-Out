using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessBtn : MonoBehaviour
{
    public void onStartClick()
    {
        SceneManager.LoadScene("World1");
        
    }
}
