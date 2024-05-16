using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;
    public Transform genTransform;
    public float timeCheck;
    public bool isGen;

    public void GenObject()       //생성 관련 변수값 변경 시켜주는 함수
    {
        isGen = false;            //생성 완료 되었으니 bool을 false로 변경
        timeCheck = 1.0f;         //생성 완료 후 1.0초로 시간 초기화
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                         //isGen 플래그가 false일 경우
        {
            timeCheck -= Time.deltaTime;                          //매 프레임 돌아가면서 시간을 감소 시킨다.
            if(timeCheck <= 0.0f)                                 //0초 이하가 되었을 경우
            {
                int RandNumber = Random.Range(0, 3);                       //0 ~ 2 의 랜덤 넘버 생성
                GameObject Temp = Instantiate(CircleObject[RandNumber]);   //프리팹 생성 후 Temp 오브젝트에 넣는다.
                Temp.transform.position = genTransform.position;  //고정 위치에 생성시킨다.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)
    {
        GameObject Temp = Instantiate(CircleObject[index]);
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();
    }
}
