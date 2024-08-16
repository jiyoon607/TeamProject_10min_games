using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text talkText;
    public GameObject scanObject;
    public GameObject playerCanvas;

    bool Displaying = false;


    void Awake()
    {
        instance = this;
    }

    public void Action(GameObject scanObj)
    {
        if(scanObj != null){
            scanObject = scanObj;
            talkText.text = "이것의 이름은 " + scanObj.name;
            if(Displaying == false) {
                StartCoroutine(DisplayCanvas());
            }
            SceneControl.instance.GameScenesControl(scanObject.GetComponent<Items>().Id);
        }
    }

    IEnumerator DisplayCanvas()
    {
        Displaying = true;
        playerCanvas.SetActive(true);   // 캔버스 활성화
        yield return new WaitForSeconds(2f);  // 2초 대기
        playerCanvas.SetActive(false);  // 캔버스 비활성화
        Displaying = false;
    }
}
