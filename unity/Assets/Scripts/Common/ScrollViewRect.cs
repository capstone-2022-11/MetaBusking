using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ���õ� ��ũ��Ʈ �۾��� ���ؼ� �߰��� �־�� �Ѵ�. 


public class ScrollViewRect : MonoBehaviour
{
    // ��ũ�� ��� ���õ� ������ �ϱ� ���� ������ �ִ� ���� 
    RectTransform rect;

    void Start () {
        rect = GetComponent<RectTransform>();
        SetContentSize();
    } 
    void SetContentSize() {
        float height = 100;
        Debug.Log(height);
        int cnt = transform.childCount;
        for(int i=0; i<cnt; i++)
        {
            height += transform.GetChild(i).gameObject.GetComponent<RectTransform>().sizeDelta.y;
        }


        Debug.Log(height);
        // scrollRect.content�� ���ؼ� Hierachy �信�� �ô� Viewport ���� Content ���� ������Ʈ�� ������ �� �ִ�. 
        // �׸��� sizeDelta ���� ���ؼ� Content�� ���̿� ���̸� ������ �� �ִ�. 

        rect.sizeDelta = new Vector2(rect.sizeDelta.x,height);
    }


}
