using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LobbySetting : MonoBehaviour
{
    public Button exitBtn;
    public Button gotoMainSceneBtn;
    // Start is called before the first frame update
    void Start()
    {
        exitBtn.onClick.AddListener(delegate { gameObject.SetActive(false); });
        gotoMainSceneBtn.onClick.AddListener(delegate { SceneManager.LoadScene("01_Main"); });
    }

    public void init()
    {//����â �ʱ⼼�� and ���� ���� �ҷ�����
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
