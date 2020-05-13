using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    public static int Rand(int min, int max)
    {
        return Random.Range(min, max + 1); //맥스값이 나오도록. 보통은 맥스 -1
    }

    public static float Rand(float min, float max)
    {
        return Random.Range(min, max); 
    }

    public static bool FloatEqual(float a, float b)
    {
        return (a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon);
    }

    public static GameObject FindChildObject(GameObject go, string name)
    {
        foreach (Transform tr in go.transform)
        {
            if (tr.name.Equals(name))    //자식에서만 탐색
            {
                return tr.gameObject;
            }
            else                        //자식의 자식 탐색.
            {
                GameObject find = FindChildObject(tr.gameObject, name);
                if (find != null)       //자식이 있으면
                {
                    return find;        //자식을 돌려보냄.
                }
            }
        }
        return null;
    }

    public static int GetPriority(int[] priorities)
    {
        int sum = 0;

        for (int i = 0; i < priorities.Length; ++i)
        {
            sum += priorities[i];
        }

        if (sum <= 0) //테이블 값 총합이 0보다 작으면
            return 0;       //확률 0%를 돌려보냄.

        int num = Rand(1, sum);

        sum = 0;

        for (int i = 0; i < priorities.Length; ++i)
        {
            int start = sum;
            sum += priorities[i];
            if(start < num && num <= sum)
            {
                return i;
            }
        }
        return 0;
    }

    public static T ToEnum<T>(string str)
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        foreach (T t in A)
        {
            if (t.ToString() == str)
                return t;
        }
        return default(T);
    }

    //public static Vector2 shortcut(GameObject a, Transform b)   //점과 선 사이 가장 가까운 길이 구하기.
    //{
    //    float x_1 = a.transform.position.x;
    //    float x_2 = a.transform.position.x;

    //    return;
    //}
}
