using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExRay : MonoBehaviour
{
    public Text UiText;
    public int Point;

    // Update is called once per frame
    void Update()
    {
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
                }
            }
            else
            {
                Point = 0;
            }

            UiText.text = Point.ToString();
        }
        
    }
}
