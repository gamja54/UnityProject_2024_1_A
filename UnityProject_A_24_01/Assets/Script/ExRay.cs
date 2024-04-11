using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRay : MonoBehaviour
{
    public Text UiText;                        //텍스트 정의
    public int Point;                          //포인트 정의
    public float checkEndtime = 30.0f;         //게임 종료 시간 설정 (30초)

    // Update is called once per frame
    void Update()
    {
        checkEndtime -= Time.deltaTime;                                    //초를 지속적으로 깎는다.

        if (checkEndtime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);                            //게임이 끝나기 전에 점수를 저장한다.
            SceneManager.LoadScene("ResultScene");                         //결과 창으로 이동한다.
        }

        if(Input.GetMouseButtonDown(1))                                     //GetMouseButtonDown(1) 오른쪽 버튼 마우스가 눌렸을 때
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray를 정의하고 카메라의 마우스 위치에서 Ray를 쏜다.

            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);

                if (hit.collider.gameObject.tag == "Target")
                {
                    Destroy(hit.collider.gameObject);
                    Point += 1;
                    //if (Point >= 10) DoChangeScene();
                }
            }
            else
            {
                Point = 0;
            }

            UiText.text = Point.ToString();
        }
        
    }

    void DoChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}   

