using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//연결리스트 구현 스크립트
[System.Serializable]
public class MyLinkedListNode<T>

{
    public T data;
    public MyLinkedListNode<T> Next;
    public MyLinkedListNode<T> Prev;
}

public class MyLinkedList<T> : MonoBehaviour
{
    public MyLinkedListNode<T> Head = null; //첫번째
    public MyLinkedListNode<T> Tail = null; //마지막
    public int count = 0;
    public MyLinkedListNode<T> AddLast(T data)
    {
        MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
        newRoom.data = data;
        //만약에 데이터가 없다면 새로 추가한 데이터가 head
        if (Head == null)
            Head = newRoom;
        //기존의 마지막 데이터와 새로 추가되는 데이터를 연결
        if(Tail!=null)
        {
            Tail.Next = newRoom;
            newRoom.Prev = Tail;
        }
        //새로 추가되는 데이터를 마지막 데이터로 벼녁ㅇ
        Tail = newRoom;
        count++;
        return newRoom;
    }
    public void Remove(MyLinkedListNode<T> room)
    {
        //기존의 첫번째 데이터를 첫번째 데이터로 
        if (Head == room)
            Head = Head.Next;
        //기존의 마지막 데이터의 이전 데이터를 마지막 데이터로
        if (Tail == room)
            Tail = Tail.Prev;

        if (room.Prev != null)
            room.Prev.Next = room.Next;

        if (room.Next != null)
            room.Next.Prev = room.Prev;

        count--;
    }
    //연결리스트 구현 스크립트
}
