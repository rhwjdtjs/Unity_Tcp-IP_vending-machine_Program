using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardUI : MonoBehaviour
{
    [SerializeField] private GameObject main_panel;
    [SerializeField] private GameObject login_panel;
    [SerializeField] private GameObject adminster_panel;
    [SerializeField] private GameObject shop_drink_panel; //�гε�
    [SerializeField] private Animator main_anim;
    [SerializeField] private Animator login_anim;
    [SerializeField] private Animator admin_anim;
    [SerializeField] private Animator shop_drink_anim; //�ִϸ��̼ǵ�
    [SerializeField] private Button admin_button;
    [SerializeField] private Button login_cancel_button;
    [SerializeField] private Button login_to_admin_button;
    [SerializeField] private Button admin_cancel_button;
    [SerializeField] private Button quit_program_button;
    [SerializeField] private Button shop_drink_Cancel_button;
    [SerializeField] private Button start_shop_button; //�ʿ��� ��ư��
    [SerializeField] private adminpassword theadminpassward; //������ ��й�ȣ
    [SerializeField] private InputField thepasswordinput; //��й�ȣ �Է� �ʵ�
    [SerializeField] private Text incorrectmessagetext; //����� Ʋ���� ������ �ؽ�Ʈ
    public void mainbutton() //����ȭ�� ��ư ��������
    {
        StartCoroutine(mainco());
    }
    public void toadminloginbutton() //�α��� ��ư�� ������ ������ ȭ������ ����.
    {
        StartCoroutine(toadminloginco());
    }
    public void tomainlogincancel() //�α��� ȭ�鿡�� ���
    {
        StartCoroutine(tomainloginco());
    }
    public void admincancelbutton() //������ �޴����� ���
    {
        StartCoroutine(admincancelco());
    }
    public void shopdrinkcancelbutton() //���� ���� â ��ҹ�ư
    {
        StartCoroutine(shopdrinktomainco());
    }
    public void maintoshopbutton()//���� ���� �ϴ� �гη� �̵��ϴ� ��ư
    {
        StartCoroutine(maintoshopco());
    }
    public void quitbutton() //���� ��ư
    {
        Application.Quit();
    }
    //�� ��ư�� �������� ����Ǵ� �Լ�
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
    IEnumerator toadminloginco() //�α��� ��ư�� ������ ������ ȭ������ ��.
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
