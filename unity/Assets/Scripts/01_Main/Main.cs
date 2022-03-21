using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;	// UnityWebRequest����� ���ؼ� �����ش�.
[System.Serializable]

public class User
{
    public string id;
    public string password;
    public string email;
    public string nickname;
    public int character;
}
public class Auth
{
    public string id;
    public string password;
}
public class Main : MonoBehaviour
{
    string url = "http://localhost:8080";

    public Button joinBtn;
    public Button loginBtn;
    public TMP_InputField id_input;
    public TMP_InputField password_input;
    public Join join;

    public GameObject wrong_obj;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        joinBtn.onClick.AddListener(delegate { join.OpenJoinPanel(); });
        loginBtn.onClick.AddListener(OnClickLoginButton);
        wrong_obj.SetActive(false);

        join.OnClickJoinButton_ += PostJoin;
    }
    void PostJoin(User user)
    {
        StartCoroutine(Join_UnityWebRequestPOST(user));
    }
    void OnClickLoginButton()
    {//�α��� ��ư�� ������ �� 
        if (id_input.text.Length <= 0 || password_input.text.Length <= 0)
        {
            //�Ф�
        }
        else
        {
            StartCoroutine(Login_UnityWebRequestPOST());
        }
        
    }
    IEnumerator Login_UnityWebRequestPOST()
    {
        animator.SetBool("isLoading", true);
        Auth auth = new Auth//���� inputfield�� �ۼ��� �� Ŭ������ ��ȯ
        {
            id = id_input.text,
            password = password_input.text
        };
        Debug.Log("�α��� �õ� : " + id_input.text + " " + password_input.text);


        string json = JsonUtility.ToJson(auth);
        using (UnityWebRequest request = UnityWebRequest.Post(url + "/api/auth", json))
        {// ���� �ּҿ� ������ �Է�
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();//��� ������ �� ������ ��ٸ���

            animator.SetBool("isLoading", false);

            if (request.error == null)//�α��� ����
            {

                Debug.Log(request.downloadHandler.text);
                SceneManager.LoadScene("02_Lobby");
            }
            else//�α��� ����
            {

                Debug.Log(request.error.ToString());
                wrong_obj.SetActive(true);
            }
        }


    }
    IEnumerator Join_UnityWebRequestPOST(User user)
    {
        //join �ε� �ִϸ��̼�
        join.LoadingJoin();

        string json = JsonUtility.ToJson(user);
        using (UnityWebRequest request = UnityWebRequest.Post(url + "/api/user", json))
        {// ���� �ּҿ� ������ �Է�
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();//���� ��ٸ���


            if (request.error == null)//���� ����
            {

                Debug.Log(request.downloadHandler.text);
                //join ����
                join.SuccessJoin();
            }
            else//�α��� ����
            {

                Debug.Log(request.error.ToString());
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
