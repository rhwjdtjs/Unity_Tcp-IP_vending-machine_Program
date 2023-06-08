using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardUI : MonoBehaviour
{
    [SerializeField] private GameObject main_panel;
    [SerializeField] private GameObject login_panel;
    [SerializeField] private GameObject adminster_panel;
    [SerializeField] private GameObject shop_drink_panel; //패널들
    [SerializeField] private Animator main_anim;
    [SerializeField] private Animator login_anim;
    [SerializeField] private Animator admin_anim;
    [SerializeField] private Animator shop_drink_anim; //애니메이션들
    [SerializeField] private Button admin_button;
    [SerializeField] private Button login_cancel_button;
    [SerializeField] private Button login_to_admin_button;
    [SerializeField] private Button admin_cancel_button;
    [SerializeField] private Button quit_program_button;
    [SerializeField] private Button shop_drink_Cancel_button;
    [SerializeField] private Button start_shop_button; //필요한 버튼들
    [SerializeField] private adminpassword theadminpassward; //관리자 비밀번호
    [SerializeField] private InputField thepasswordinput; //비밀번호 입력 필드
    [SerializeField] private Text incorrectmessagetext; //비번이 틀릴때 나오는 텍스트
    public void mainbutton() //메인화면 버튼 눌렀을때
    {
        StartCoroutine(mainco());
    }
    public void toadminloginbutton() //로그인 버튼을 누르면 관리자 화면으로 간다.
    {
        StartCoroutine(toadminloginco());
    }
    public void tomainlogincancel() //로그인 화면에서 취소
    {
        StartCoroutine(tomainloginco());
    }
    public void admincancelbutton() //관리자 메뉴에서 취소
    {
        StartCoroutine(admincancelco());
    }
    public void shopdrinkcancelbutton() //음료 구매 창 취소버튼
    {
        StartCoroutine(shopdrinktomainco());
    }
    public void maintoshopbutton()//음료 구매 하는 패널로 이동하는 버튼
    {
        StartCoroutine(maintoshopco());
    }
    public void quitbutton() //종료 버튼
    {
        Application.Quit();
    }
    //각 버튼을 눌렀을때 실행되는 함수
    IEnumerator mainco()
    {
        main_anim.SetTrigger("close");
        quit_program_button.gameObject.SetActive(false);
        admin_button.gameObject.SetActive(false);
        start_shop_button.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        login_cancel_button.gameObject.SetActive(true);
        login_to_admin_button.gameObject.SetActive(true);
        main_panel.SetActive(false);
       login_panel.gameObject.SetActive(true);
    }
    IEnumerator toadminloginco() //로그인 버튼을 누르면 관리자 화면으로 감.
    {
       
            if (thepasswordinput.text.ToString() == PassWord.password)
            {
                incorrectmessagetext.gameObject.SetActive(false);
                login_anim.SetTrigger("close");
                login_cancel_button.gameObject.SetActive(false);
                admin_cancel_button.gameObject.SetActive(true);
                login_to_admin_button.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                login_panel.SetActive(false);
                adminster_panel.SetActive(true);
            }
            else
            {
                incorrectmessagetext.gameObject.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                incorrectmessagetext.gameObject.SetActive(false);
            }
        
    

    }
    IEnumerator tomainloginco()
    {
        login_anim.SetTrigger("close");
        login_to_admin_button.gameObject.SetActive(false);
        login_cancel_button.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        login_panel.SetActive(false);
        quit_program_button.gameObject.SetActive(true);
        admin_button.gameObject.SetActive(true);
        start_shop_button.gameObject.SetActive(true);
        main_panel.SetActive(true);
    }
    IEnumerator admincancelco()
    {
        admin_anim.SetTrigger("close");
        admin_cancel_button.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        adminster_panel.SetActive(false);
        quit_program_button.gameObject.SetActive(true);
        admin_button.gameObject.SetActive(true);
        start_shop_button.gameObject.SetActive(true);
        login_to_admin_button.gameObject.SetActive(true);
        main_panel.SetActive(true);
    }
    IEnumerator shopdrinktomainco()
    {
        shop_drink_anim.SetTrigger("close");
        shop_drink_Cancel_button.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        shop_drink_panel.SetActive(false);
        main_panel.SetActive(true);
        quit_program_button.gameObject.SetActive(true);
        admin_button.gameObject.SetActive(true);
        start_shop_button.gameObject.SetActive(true);
    }
    IEnumerator maintoshopco()
    {
        main_anim.SetTrigger("close");
        quit_program_button.gameObject.SetActive(false);
        admin_button.gameObject.SetActive(false);
        start_shop_button.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        shop_drink_Cancel_button.gameObject.SetActive(true);
        shop_drink_panel.SetActive(true);
        main_panel.SetActive(false);
        
    }
}
