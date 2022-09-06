using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // เรียกใช้เพื่อให้ทำการ load scene ได้
using UnityEngine.UI; // เรียกใช้เพื่อให้สามารถเรียก UI


public class PlayerControl : MonoBehaviour
{
    public Stats myStats;
    Rigidbody rb;  // สร้างตัวแปล ชื่อ rb เป็น Rigidbody
    public float speed; //สร้างตัวแปลชื่อ speed เป็น ทศนิยม แบบ public
    public float jumpSpeed;
    public bool onGround;
    private bool canJump = true;
    public int jumpCount = 0;
    Animator anim;
    float jumpOrSlide;
    BoxCollider boxCollider;
    SpriteRenderer sprite;
    Animator animator;
    public GameObject resultMenuUI;
    public bool isDead = false;
    private const float coef = 1f;
    public bool timerActive = false;

    public float MaxPlayerHp = 100f; // Max hp ของผู้เล่น
    public int Def =5; // ค่าป้องกันลดความเสียหายตอนชน
    public int Str =1; // เพิ่มค่า def เพิ่ม hp
    public int Agi =1; // เพิ่มความเร็วในการวิ่ง
    public int Int =1; // ทำให้เก็บยาเลือดได้ผลเยอะขึ้น
    public int Luk =0; // มีโอกาสหลบการชนได้ , มีผลต่อการ craft
    public int LevelPlayer ; // เลเวลตัวละคร
    public int maxLevelPlayer = 100;
    public int RemainingStatPoint;// แต้มคงเหลือในการอัพสเตตัส
    public float currentExp;
    public int MaxExp;





    private int score;
    private int gold;
    public Text scoreUI;
    public Text goldUI;
    public Text resultScoreUI;
    public Text resultGoldUI;
    public Text resultExpUI;

    public AudioClip resultClip;
    public AudioClip triggerSoundDead;
    public AudioClip triggerSoundRedPotion;
    public AudioClip triggerSoundFallCheck;
    public AudioClip triggerSoundRun;
    public AudioClip triggerSoundObstacle;
    public AudioClip triggerSoundGem;
    public AudioClip triggerSoundGold;
    AudioSource audioSound;

    private bool takeGold = false;
    private bool takeGem = false;
    private bool takeObstacle = false;


    void Awake()
    {
        

    }
    // Start เริ่มเมื่อเกมเริ่มรัน frame แรก
    void Start()
    {
        
        rb = this.GetComponent<Rigidbody>(); // กำหนดให้ตัวแปล rb ไปนำ Component ชื่อ Rigidbody ใน This(คือball) 
        anim = this.GetComponent<Animator>();
        boxCollider = this.GetComponent<BoxCollider>();
        audioSound = this.GetComponent<AudioSource>();
        sprite = this.GetComponent<SpriteRenderer>();
        timerActive = true;
    }

    // Update จะถูกเรียกใช้งานทุกๆ frame ที่วิ่งไป
    void Update()
    {

        

        if (takeGold)
        {
            audioSound.PlayOneShot(triggerSoundGold, 0.2f);
            takeGold = false;
        }
        else if(takeGem)
        {
            audioSound.PlayOneShot(triggerSoundGem, 0.3f);
            takeGem = false;
        }
        else if(takeObstacle)
        {
            audioSound.PlayOneShot(triggerSoundObstacle, 1f);
            takeObstacle = false;
            sprite.color = Color.red;
            StartCoroutine(delayTime());
            
            
        }


        transform.position = Vector3.right * speed * Time.deltaTime + transform.position;
        if (jumpCount == 2)
        {
            
            canJump = false;
           
            rb.AddForce(Vector3.down * jumpSpeed * 3f * Time.deltaTime);
            
        }
        else if (jumpCount == 1)
        {
            
            
            
            rb.AddForce(Vector3.down * jumpSpeed * 2.5f * Time.deltaTime);
            
            canJump = true;
        }
        else
        {

        }

        if (Input.GetKeyDown("up") | Input.GetKeyDown("w"))
        {
            jumpButton();
           
        }

        if(Input.GetKey("down") | Input.GetKey("s"))
        {

            boxCollider.size = new Vector3(16.2f, 4.8f, 0.2f);
            boxCollider.center = new Vector3(0.6f, -4.6f, 0);
            anim.SetBool("nowSlide", true);
            
        }
        else if (Input.GetKeyUp("down") | Input.GetKeyUp("s"))
        {
            
            anim.SetBool("nowSlide", false);
            boxCollider.size = new Vector3(8.5f, 14.3f, 0.2f);
            boxCollider.center = new Vector3(0.6f, -0.1f, 0);
            
        }

        checkDead();

        



    }


    public void jumpButton()
    {
        if (canJump == true )
        {
            jumpSpeed = 8500;
            //anim.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpSpeed + transform.position);
            jumpCount++;
            
            anim.SetBool("nowRun", false);
            anim.SetBool("nowJump", true);
            anim.SetBool("nowSlide", false);
            
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
            
            canJump = true;
            anim.SetBool("nowRun", true);
            anim.SetBool("nowJump", false);
            speed = 6;
            
        }
    }

    private void OnTriggerEnter(Collider other) // เมื่อ มีการชนกับวัตถุ is trigger (ตัว coin ตังค่า is trigger ไว้) จะเรียก Collider ตัวอื่น other
    {
        if (other.gameObject.tag == "Obstacle")  
        {
            speed = 3.5f;
            currentExp -= 5;
            takeObstacle = true;
            StartCoroutine(delayTime());

        }
        else if (other.gameObject.tag == "RedGem")
        {
            takeGem = true;
            Destroy(other.gameObject);
            score = score + 25;
            scoreUI.text = score.ToString("N0");
            currentExp += 1;
        }
        else if (other.gameObject.tag == "GreenGem")
        {
            takeGem = true;
            Destroy(other.gameObject);
            score = score + 50;
            scoreUI.text = score.ToString("N0");
            currentExp += 1;
        }
        else if (other.gameObject.tag == "PurpleGem")
        {
            takeGem = true;
            Destroy(other.gameObject);
            score = score + 100;
            scoreUI.text = score.ToString("N0");
            currentExp += 2;
        }
        else if (other.gameObject.tag == "smallGold")
        {
            takeGold = true;
            Destroy(other.gameObject);
            gold = gold + 10;
            score = score + 10;
            goldUI.text = gold.ToString("N0");
            scoreUI.text = score.ToString("N0");
            currentExp += 1;

        }
        else if (other.gameObject.tag == "bigGold")
        {
            takeGold = true;
            Destroy(other.gameObject);
            gold = gold + 100;
            score = score + 30;
            goldUI.text = gold.ToString("N0");
            scoreUI.text = score.ToString("N0");
            currentExp += 2;

        }
        else if (other.gameObject.tag == "FallCheck")
        {
            speed = 0;
            currentExp -= 5;
            sprite.color = Color.red;
            canJump = false;
            audioSound.PlayOneShot(triggerSoundFallCheck, 0.7f);
            rb.AddForce(Vector3.down * jumpSpeed * 2 * Time.deltaTime);
            anim.SetBool("nowFall", true);
            isDead = true;
            timerActive = false;

        }
        else if (other.gameObject.tag == "Boundary")
        {
            speed = 0;
            sprite.color = Color.red;
            currentExp -= 5;
            canJump = false;
            audioSound.PlayOneShot(triggerSoundFallCheck, 0.7f);
            rb.AddForce(Vector3.down * jumpSpeed * 2 * Time.deltaTime);
            anim.SetBool("nowFall", true);
            isDead = true;
            timerActive = false;



        }
        else if (other.gameObject.tag == "RedPotion")
        {
            Destroy(other.gameObject);
            audioSound.PlayOneShot(triggerSoundRedPotion, 2.5f);
        }

    }




    
    public IEnumerator delayTime() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        yield return new WaitForSeconds(1f);
        sprite.color = Color.white;
        speed = 6;
    }

   

    public void checkDead()
    {
        if (Healthbar.health < 0 | isDead == true)
        {
            speed = 0;
            jumpCount = 2;
            timerActive = false;
            isDead = true;
            anim.SetBool("nowRun", false);
            anim.SetBool("nowJump", false);
            anim.SetBool("nowSlide", false);
            anim.SetBool("nowDead", true);
            audioSound.PlayOneShot(triggerSoundDead, 0.9f);
            
            StartCoroutine(SetDeadTime());
            
            
            
            StartCoroutine(SetDelayTime());
            resultGoldUI.text = gold.ToString("N0");
            resultScoreUI.text = score.ToString("N0");
            resultExpUI.text = currentExp.ToString("N0");
            ES3.Save("resultExp",currentExp);
            ES3.Save("resultLevel",LevelPlayer);
            
        }
    }

    public IEnumerator SetDelayTime() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        audioSound.volume = 0f;
        yield return new WaitForSeconds(1f);
        resultMenuUI.SetActive(true);
        

    }
    public IEnumerator SetDeadTime() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        yield return new WaitForSeconds(0.3f);
        anim.Play("Dead");
        

    }

    public IEnumerator SetJumpDelay() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        yield return new WaitForSeconds(0.5f);
        jumpSpeed = 4000;


    }




}











