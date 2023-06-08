using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//���Ḯ��Ʈ ���� ��ũ��Ʈ
[System.Serializable]
public class MyLinkedListNode<T>

{
    public T data;
    public MyLinkedListNode<T> Next;
    public MyLinkedListNode<T> Prev;
}

public class MyLinkedList<T> : MonoBehaviour
{
    public MyLinkedListNode<T> Head = null; //ù��°
    public MyLinkedListNode<T> Tail = null; //������
    public int count = 0;
    public MyLinkedListNode<T> AddLast(T data)
    {
        MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
        newRoom.data = data;
        //���࿡ �����Ͱ� ���ٸ� ���� �߰��� �����Ͱ� head
        if (Head == null)
            Head = newRoom;
        //������ ������ �����Ϳ� ���� �߰��Ǵ� �����͸� ����
        if(Tail!=null)
        {
            Tail.Next = newRoom;
            newRoom.Prev = Tail;
        }
        //���� �߰��Ǵ� �����͸� ������ �����ͷ� ���ᤷ
        Tail = newRoom;
        count++;
        return newRoom;
    }
    public void Remove(MyLinkedListNode<T> room)
    {
        //������ ù��° �����͸� ù��° �����ͷ� 
        if (Head == room)
            Head = Head.Next;
        //������ ������ �������� ���� �����͸� ������ �����ͷ�
        if (Tail == room)
            Tail = Tail.Prev;

        if (room.Prev != null)
            room.Prev.Next = room.Next;

        if (room.Next != null)
            room.Next.Prev = room.Prev;

        count--;
    }
    //���Ḯ��Ʈ ���� ��ũ��Ʈ
}
