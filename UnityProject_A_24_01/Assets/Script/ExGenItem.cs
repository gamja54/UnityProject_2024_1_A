using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenItem : MonoBehaviour
{
    public GameObject ItemBox;                                                        //아이템 박스 정의
    public float checkTime;                                                           //시간 검사할 변수 선언
     
    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;                                                 //프레임 시간을 쌓아서 초를 검사한다.
        if(checkTime >= 2.0f)                                                        //2초의 시간이 흐르면
        {
            checkTime = 0.0f;
            GameObject temp = Instantiate(ItemBox);                                  //시간 초기화를 시킨다.
            temp.transform.position = this.gameObject.transform.position;
            int RandomNumber = Random.Range(0, 4);
            temp.transform.position += new Vector3(0.0f, RandomNumber, 0.0f);
        }
        
    }
}
