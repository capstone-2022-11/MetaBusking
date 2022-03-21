using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;	// UnityWebRequest����� ���ؼ� �����ش�.


public class NetworkTest : MonoBehaviour
{
    string url = "http://localhost:8080";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnityWebRequestPOSTTEST());
    }

    IEnumerator UnityWebRequestPOSTTEST()
    {
        User user1 = new User
        {
            id = "hi",
            password = "hi",
            email = "hi",
            nickname = "hi",
            character = 1234
        };
        Auth auth = new Auth
        {
            id = "hi",
            password = "hi"
        };

        
        string json = JsonUtility.ToJson(auth);
        using (UnityWebRequest request = UnityWebRequest.Post(url + "/api/auth", json))
        {// ���� �ּҿ� ������ �Է�
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            if (request.error == null)
            {
                Debug.Log(request.downloadHandler.text);
            }
            else
            {
                Debug.Log(request.error.ToString());
            }
        }
    }   
}