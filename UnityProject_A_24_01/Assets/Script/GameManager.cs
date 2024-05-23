using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;
    public Transform genTransform;
    public float timeCheck;
    public bool isGen;

    public int Point;
    public int BestScore;
    public static event Action<int> OnPointChanged;
    public static event Action<int> OnBestScoreChanged;

    public void GenObject()       //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;            //���� �Ϸ� �Ǿ����� bool�� false�� ����
        timeCheck = 1.0f;         //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
        OnPointChanged?.Invoke(Point);
        OnBestScoreChanged?.Invoke(BestScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                         //isGen �÷��װ� false�� ���
        {
            timeCheck -= Time.deltaTime;                          //�� ������ ���ư��鼭 �ð��� ���� ��Ų��.
            if(timeCheck <= 0.0f)                                 //0�� ���ϰ� �Ǿ��� ���
            {
                int RandNumber = UnityEngine.Random.Range(0, 3);                       //0 ~ 2 �� ���� �ѹ� ����
                GameObject Temp = Instantiate(CircleObject[RandNumber]);   //������ ���� �� Temp ������Ʈ�� �ִ´�.
                Temp.transform.position = genTransform.position;  //���� ��ġ�� ������Ų��.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)
    {
        GameObject Temp = Instantiate(CircleObject[index]);
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();

        Point += (int)Mathf.Pow(index, 2) * 10;
        OnPointChanged?.Invoke(Point);
    }
    public void EndGame()   
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");

        if(Point > BestScore)
        {
            PlayerPrefs.SetInt("BestScore", BestScore);
            OnBestScoreChanged?.Invoke(BestScore);
        }

        //���� �� �ؾ� ���� ���߿� �߰�
    }
}
