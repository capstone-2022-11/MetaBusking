using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Join : MonoBehaviour
{
    public Button exitBtn;
    public Button joinBtn;
    public inputObject[] inputObjects;

    public TextMeshProUGUI resultPopup_text;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        joinBtn.onClick.AddListener(OnClickJoinButton);
        exitBtn.onClick.AddListener(OnClickExitButton);
        for(int i=0; i<inputObjects.Length; i++)
        {
            inputObjects[i].OnClickButton_ += playAppearResultPopup;
        }
    }
    public void OpenJoinPanel()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].reset();
        }
        
       gameObject.SetActive(true);
        


    }
    void OnClickJoinButton()
    {
        for(int i=0; i<inputObjects.Length; i++)
        {
            if (inputObjects[i].isOkay == false)
            {
                //�߸� �Է��� ���� ���� ���
                playAppearResultPopup("��� ���׿� �ùٸ� ���� �Է����ּ���.");
                return;
            }
        }

        //������ �Ϸ��
        //���� �Ϸ� �ִϸ��̼��� ���

        gameObject.SetActive(false);

    }
    void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }
    void playAppearResultPopup(string str)
    {
        resultPopup_text.text = str;
        animator.SetTrigger("AppearResultPopup");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
