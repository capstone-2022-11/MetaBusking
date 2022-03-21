using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
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
    }
    void OnClickLoginButton()
    {//로그인 버튼이 눌렸을 때 
        if (id_input.text.Length <= 0 || password_input.text.Length <= 0)
        {
            //ㅠㅠ
        }
        else
        {
            StartCoroutine(login());
        }
        
    }
    IEnumerator login()
    {
        Debug.Log("로그인 시도 : " + id_input.text + " " + password_input.text);
        animator.SetBool("isLoading", true);
        bool isLogin = false;
        while (true)
        {
            //임시로 시간지연
            yield return new WaitForSeconds(1.0f);
            if (true)//로그인이 완료되면
            {
                isLogin = true;
                break;
            }
            
        }
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("isLoading", false);
        

        if (isLogin)
        {
            SceneManager.LoadScene("01_Lobby");
        }
        else
        {
            //로그인 실패 띄우기
            wrong_obj.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
