using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPage : MonoBehaviour
{

    public ListPageInSongPage listPage;
    public SearchPageInSongPage searchPage;
    public AddPageInSongPage addPage;
    void Start()
    {
        
    }

    public void open()
    {
        gameObject.SetActive(true);
    }
    public void LoadListPage(int id)
    {//id에 따라 알맞은 재생목록을 불러오는 함수


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
