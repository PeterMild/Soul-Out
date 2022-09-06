using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int level = 1;
    private int oldLevel;
    private int newLevel;
    private float experience = 0;
    private float experienceToNextLevel = 100;
    public Image ExpFill;
    public float GetExp;
    public Text levelText;
    public Text oldlevelText;
    public Text newlevelText;
    public AudioClip levelUPSound;
    public AudioSource audioSound;
    public GameObject LevelUpWindowUI;
    private const float coef = 0.01f;
    PlayerControl playerControl;
    [SerializeField] private GameObject Player;

    public void Start()
    {
        ExpFill = GetComponent<Image>();

        playerControl = Player.GetComponent<PlayerControl>();


    }


    public void FixedUpdate()
    {
        GetExp += coef * Time.deltaTime;

        experience += GetExp;
        ExpFill.fillAmount = experience / experienceToNextLevel;

        if (experience >= experienceToNextLevel)
        {
            oldLevel = level;
            oldlevelText.text = level.ToString("#");
            level++;
            newLevel = level;
            newlevelText.text = level.ToString("#");
            levelText.text = level.ToString("#");
            audioSound.PlayOneShot(levelUPSound, 1f);
            experienceToNextLevel = experienceToNextLevel * 2.5f;
            experience = 0;
            Debug.Log(experienceToNextLevel);
            ExpFill.fillAmount = experience / experienceToNextLevel;
            LevelUpWindowUI.SetActive(true);
            StartCoroutine(DelayTime());

            

        }

        checkDead();


    }

    public void checkDead()
    {
        if (playerControl.isDead)
        {
            experience= 0;
        }
    }





    public IEnumerator DelayTime() // ตั้งเวลา delay ให้เกิดเหตุการอะไร
    {
        yield return new WaitForSeconds(3f);
        LevelUpWindowUI.SetActive(false);


    }
}







