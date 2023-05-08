using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartAnim : MonoBehaviour
{
    [SerializeField] private Button startbutton; //���� ���� ��ư
    [SerializeField] private Button tabscreenbutton; //ȭ�� ��ġ ��ư
    [SerializeField] private GameObject thepanel; //���Ǳ� �г�
    [SerializeField] private GameObject theFirstText; //�й� �̸� �ؽ�Ʈ
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
    public void Buttonstart() //���� ���� ��ư�� ������
    {
        startbutton.gameObject.SetActive(false);
        theFirstText.SetActive(false);
        anim.SetTrigger("button");
        StartCoroutine(tabscreenco());
    }
    public void tabbutton() //ȭ�� ��ġ ��ư�� ������
    {
        tabscreenbutton.gameObject.SetActive(false);
        thepanel.SetActive(true);
    }
}
