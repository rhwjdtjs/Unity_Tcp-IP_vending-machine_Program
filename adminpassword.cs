using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class adminpassword : MonoBehaviour
{

    [SerializeField] private InputField theinputpassword; //�н����� �Է� ĭ
    [SerializeField] private Button thestartbutton; //���� ������ �Ѿ������ ��ư
    [SerializeField] private Text correctpassword; //�ùٸ� ����϶� ������ �ؽ�Ʈ
    [SerializeField] private Text incorrectpassword; //Ʋ�� ����϶� ������ �ؽ�Ʈ
    void Start()
    {
        thestartbutton.gameObject.SetActive(false); //��ư ��Ȱ��ȭ
    }

    void Update()
    {
        PassWord.password = theinputpassword.text.ToString(); //PassWord �� �ɹ����� password�� �Է¹��� ����� ����
        //Debug.Log(PassWord.password);
    }
    public void afterpasswordOkButton()
    {

        if (PassWord.password.Length >= 8 && PassWord.password.Any(c => !Char.IsLetterOrDigit(c)) && PassWord.password.Any(c => Char.IsDigit(c))) //Ư�����ڰ� �ϳ��� �� ���ԵǾ� �ְ�
            //���ڰ� �ϳ� �̻� ������ 8�� �̻��϶�
        {
            Debug.Log("��й�ȣ�� ��Ģ�� �½��ϴ�.");
            Debug.Log(PassWord.password);
            StartCoroutine(correctpasswordco()); //�Լ� ����
        }
        else
        {
            Debug.Log("��й�ȣ�� 8�ڸ� �̻�, Ư������ �� ���ڰ� ���ԵǾ�� �մϴ�.");
            Debug.Log(PassWord.password);
            StartCoroutine(incorrectpasswordco()); //�Լ� ����
        }


    }
    IEnumerator correctpasswordco() //�ùٸ� ��й�ȣ �϶�
    {
        incorrectpassword.gameObject.SetActive(false);
        correctpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        correctpassword.gameObject.SetActive(false);
        theinputpassword.gameObject.SetActive(false);
        thestartbutton.gameObject.SetActive(true); //�������� �Ѿ������ ��ư Ȱ��ȭ
    }
    IEnumerator incorrectpasswordco() //Ʋ�� ��й�ȣ �϶�
    {
        correctpassword.gameObject.SetActive(false);
        incorrectpassword.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        incorrectpassword.gameObject.SetActive(false);
    }
}
