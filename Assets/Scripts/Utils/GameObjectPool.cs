using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool<T> where T : class {

    short count;
    public delegate T Func();  
    Func create_fn;
    Stack<T> objects;       //후입선출. Que도 상관없음.
    public GameObjectPool(short count, Func fn) //생성자.
    {
        this.count = count;
        this.create_fn = fn;
        this.objects = new Stack<T>(this.count);
        allocate();
    }
    void allocate()     //메모리 생성
    {
        for(int i = 0; i < this.count; ++i)
        {
            this.objects.Push(this.create_fn());
        }
    }
    public T pop()  //필요할 때 1개 사용.
    {
        if(this.objects.Count <= 0) //더 이상 꺼낼것이 없을 때
        {
            allocate();                 //메모리 추가 할당.
        }
        return this.objects.Pop();
    }
    public void push(T obj)
    {
        this.objects.Push(obj);
    }
}
