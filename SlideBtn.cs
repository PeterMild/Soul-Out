using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideBtn : MonoBehaviour
{
    
    public GameObject Player;
    Animator anim;
    Rigidbody rb;
    BoxCollider boxCollider;

    public bool buttonHeldDown;


 void Start()
{
    anim = Player.GetComponent<Animator>();
      rb = Player.GetComponent<Rigidbody>();
        boxCollider = Player.GetComponent<BoxCollider>();


    }


    void Update()
    {
    



    }

    public void TaskOnClick()
    {
        boxCollider.size = new Vector3(16.2f, 4.8f, 0.2f);
        boxCollider.center = new Vector3(0.6f, -4.6f, 0);
        buttonHeldDown = true;
            anim.SetBool("nowSlide", true);
       
    }
    public void TaskOnClickUp()
    {
            buttonHeldDown = false;
            anim.SetBool("nowSlide", false);
        boxCollider.size = new Vector3(8.5f, 14.3f, 0.2f);
        boxCollider.center = new Vector3(0.6f, -0.1f, 0);
    }
}





