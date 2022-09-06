using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    float Damage = 20f;
    float realDamage;
    PlayerControl playerControl; // ตั้งชื่อ script ที่ต้องการดึงค่า
    [SerializeField] GameObject Player; // เรียกค่า object Player


    void Awake()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>(); // ขอเข้าถึง script จาก Player

    }

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        realDamage = (Damage - playerControl.Def);
        Debug.Log(realDamage);
        Healthbar.health -= realDamage;
        
       
        

    }

    public IEnumerator SetDelayTime() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        yield return new WaitForSeconds(1f);
        


    }
}
