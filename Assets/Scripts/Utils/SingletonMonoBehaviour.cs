using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유니티용 모노비해비어 싱글턴 클래스
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T> {

    static public T Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = (T)this;             //(T) -> 형변환
            OnAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        if(Instance == (T)this)
        {
            OnStart();
        }
	}
    virtual protected void OnAwake()
    {
    }
    virtual protected void OnStart()
    {
    }
	
	void Update () {
	}
}
