using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldManager : MonoBehaviour
{
    public AudioClip triggerSound;
    AudioSource goldSound;
    
    
    void Start()
    {
        goldSound = this.GetComponent<AudioSource>();
    }
  
     void OnTriggerEnter(Collider other) // เมื่อ มีการชนกับวัตถุ is trigger (ตัว coin ตังค่า is trigger ไว้) จะเรียก Collider ตัวอื่น other
    {
            goldSound.PlayOneShot(triggerSound,1f);
           
       

        
        
    }
}
