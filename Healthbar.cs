using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Text healthText;
    Image healthBar;
    private float  maxHealth;
    public static float health;
    private const float coef = 1f;
    private float showHealth;
    PlayerControl playerControl; // ตั้งชื่อ script ที่ต้องการดึงค่า
    [SerializeField] GameObject Player; // เรียกค่า object Player

    void Awake()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>(); // ขอเข้าถึง script จาก Player
       
    }



    void Start ()
    {
        maxHealth = (playerControl.MaxPlayerHp); // กำหนดให้ maxHealth มีค่าเท่ากับ MaxHp ใน Script Playercontrol
        

        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    void Update ()
    {
        if(health>0)
        {
            health -= coef * Time.deltaTime;
        }


        healthBar.fillAmount = health / maxHealth;
        
        healthText.text = health.ToString("#");
    }



}
