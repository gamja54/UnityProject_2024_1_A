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
