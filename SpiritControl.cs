using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritControl : MonoBehaviour
{
    public GameObject Player; // ประกาศตัวแปรให้กล้องรู้จักกับ ball
    private Vector3 offSet; // สร้างตัวแปรแกน 3 มิติ ชื่อว่า offset เอาไว้เก็บระยะห่างจาก ball กับ กล้อง
    private Vector3 newtrans;
    // Start is called before the first frame update
    void Start()
    {
        offSet.x = transform.position.x - Player.transform.position.x;
        offSet.y = transform.position.y - Player.transform.position.y;
        offSet.z = transform.position.z - Player.transform.position.z;
        newtrans = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        newtrans.x = Player.transform.position.x + offSet.x;
        newtrans.y = Player.transform.position.y + offSet.y;
        newtrans.z = Player.transform.position.z + offSet.z;
        transform.position = newtrans;
    }



}
