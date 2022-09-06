using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player; // ประกาศตัวแปรให้กล้องรู้จักกับ ball
    private Vector3 offSet; // สร้างตัวแปรแกน 3 มิติ ชื่อว่า offset เอาไว้เก็บระยะห่างจาก ball กับ กล้อง
    private Vector3 newtrans;


    void Start()
    {
        //offSet = this.transform.position - Player.transform.position; // ค่า offset = ตำแหน่งกล้อง - ตำแหน่ง ball
        offSet.x = transform.position.x - Player.transform.position.x;
        offSet.z = transform.position.z - Player.transform.position.z;
        newtrans = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = Player.transform.position + offSet; // ย้ายตำแหน่งกล้องตาม ค่าตำแหน่งบอล + ค่า offset
        // newPosition.y = 0;
        // transform.position = newPosition;
        newtrans.x = Player.transform.position.x + offSet.x;
        newtrans.z = Player.transform.position.z + offSet.z;
        transform.position = newtrans;
    }
   
}
