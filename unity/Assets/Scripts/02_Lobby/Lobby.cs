using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public Button settingBtn;
    public Button openSongPageBtn;
    public Button loadSquareSceneBtn;
    public Button characterSetBtn;

    public CharacterSetPage characterSetPage;
    public SongPage songPage;
    public LobbySetting lobbySetting;
    void Start()
    {
        settingBtn.onClick.AddListener(delegate { lobbySetting.init(); });
        loadSquareSceneBtn.onClick.AddListener(LoadSquareScene);
        openSongPageBtn.onClick.AddListener(delegate { songPage.open(); });
        characterSetBtn.onClick.AddListener(delegate { characterSetPage.open(); });
    }

    void LoadSquareScene()
    {//±¤Àå¾À ·Îµå

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
