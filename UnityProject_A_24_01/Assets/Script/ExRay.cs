using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRay : MonoBehaviour
{
    public Text UiText;                        //�ؽ�Ʈ ����
    public int Point;                          //����Ʈ ����
    public float checkEndtime = 30.0f;         //���� ���� �ð� ���� (30��)

    // Update is called once per frame
    void Update()
    {
        checkEndtime -= Time.deltaTime;                                    //�ʸ� ���������� ��´�.

        if (checkEndtime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);                            //������ ������ ���� ������ �����Ѵ�.
            SceneManager.LoadScene("ResultScene");                         //��� â���� �̵��Ѵ�.
        }

        if(Input.GetMouseButtonDown(1))                                     //GetMouseButtonDown(1) ������ ��ư ���콺�� ������ ��
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ���.

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

