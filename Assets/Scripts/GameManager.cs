using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayState
{
    Play, Dead
}

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayState ps;
    public static GameManager gm;

    void Start()
    {
        ps = PlayState.Play;
        gm = this;
    }

    void Update()
    {
// 만약 안드로이드나 아이폰으로 프로젝트를 설정할 경우
// 기종에 따라 게임 재시작 시키는 방법을 구현
#if(UNITY_ANDROID||UNITY_IPHONE)
        if (ps == PlayState.Dead)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("SampleScene");
                }
            }

        }
#else
        if (ps == PlayState.Dead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("SampleScene");
            }
        }    
#endif
    }
}
