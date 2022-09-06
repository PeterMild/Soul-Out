using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // เรียกใช้เพื่อให้ทำการ load scene ได้
using UnityEngine.UI; // เรียกใช้เพื่อให้สามารถเรียก UI

public class DeletePoint : MonoBehaviour
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
    private void OnTriggerEnter(Collider other) // เมื่อ มีการชนกับวัตถุ is trigger (ตัว coin ตังค่า is trigger ไว้) จะเรียก Collider ตัวอื่น other
    {
        if (other.gameObject.tag == "Floor") // ถ้าวัตถุที่ชนมี Tag ชื่อว่า coin 
        {
            Destroy(other.gameObject); 
        }
    }
}
