using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartAnim : MonoBehaviour
{
    [SerializeField] private Button startbutton; //시작 상점 버튼
    [SerializeField] private Button tabscreenbutton; //화면 터치 버튼
    [SerializeField] private GameObject thepanel; //자판기 패널
    [SerializeField] private GameObject theFirstText; //학번 이름 텍스트
    private Animator anim;
    void Start()
    {
        tabscreenbutton.gameObject.SetActive(false);
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        
    }
    IEnumerator tabscreenco()
    {
        yield return new WaitForSeconds(3.9f);
        tabscreenbutton.gameObject.SetActive(true);
    }
    public void Buttonstart() //시작 상점 버튼을 누르면
    {
        startbutton.gameObject.SetActive(false);
        theFirstText.SetActive(false);
        anim.SetTrigger("button");
        StartCoroutine(tabscreenco());
    }
    public void tabbutton() //화면 터치 버튼을 누르면
    {
        tabscreenbutton.gameObject.SetActive(false);
        thepanel.SetActive(true);
    }
}
