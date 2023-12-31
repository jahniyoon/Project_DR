using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneLoder : MonoBehaviour
{
    [Header ("Scene Loader")]
    public string sceneName;    // 전환할 씬의 이름
    public float sceneDelay = 3f;    // 씬 전환 시 딜레이
    public bool autoLoad;       // 체크 시 자동으로 씬 전환 
    public bool isWaitForGoogleSheetLoad;   // 체크 시 구글 시트가 불러졌을 때 로드
    private bool _isLoadScene = false;           // 씬 로드중인지 확인
    private ScreenFader fader;  // 플레이어 페이더

    void Start()
    {
        // isWaitForGoogleSheetLoad == false
        if (isWaitForGoogleSheetLoad.Equals(false))
        {
            // 플레이어의 페이더 찾아오기
            fader = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenFader>();
            if(!fader)
            {
                GFunc.Log("페이더를 찾지 못했습니다.");
            }

            // 자동으로 씬 전환
            if (autoLoad) 
            {
                LoadScene(sceneName);
            }
        }
    }

    private void FixedUpdate()
    {
        // isWaitForGoogleSheetLoad == true
        if (isWaitForGoogleSheetLoad.Equals(true) && _isLoadScene.Equals(false))
        {
            GFunc.Log("isWaitForGoogleSheetLoad.Equals(true)");
            // 데이터 매니저에 테이블이 전부 추가되었을 경우
            GFunc.Log($"GoogleSheetLoader.isDone.Equals(true) == {GoogleSheetLoader.isDone.Equals(true)}");
            // 데이터 매니저에 데이터가 전부 로드되었을 경우
            if (DataManager.Instance.IsDataLoaded())
            {
                _isLoadScene = true;
                LoadScene(sceneName);
            }
        }
    }

    // 씬을 불러오는 메서드
    public void LoadScene()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            GFunc.Log("전환할 씬을 찾지 못했습니다.");
            return;
        }
        StartCoroutine(LoadDelay(sceneName));
    }

    // 씬을 불러오는 메서드
    // _SceneName string을 매개변수로 불러올 수 있음
    public void LoadScene(string _SceneName)
    {
        if(string.IsNullOrEmpty(_SceneName))
        {
            GFunc.Log("전환할 씬을 찾지 못했습니다.");
            return;
        }
        StartCoroutine(LoadDelay(_SceneName));
    }

    // 딜레이가 있을 시 코루틴
    IEnumerator LoadDelay(string _SceneName)
    {
        if (fader)
        {
            fader.DoFadeIn();                           // 페이더를 켜고
        }


            yield return new WaitForSeconds (sceneDelay);   // 딜레이 이후

        
        SceneManager.LoadScene(_SceneName);             // 지정된 이름의 씬을 로딩
    }

}
