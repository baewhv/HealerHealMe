using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutData : DontDestroy<OutData>
{
    int monsterCount;
    public WaveData[] waveData = new WaveData[15];
    bool InitComplete = false;

    public void InitData()
    {
        InitWaveData();
    }

    protected override void OnStart()
    {
        base.OnStart();
        InitWaveData();
    }

    void InitWaveData()
    {
        if (!InitComplete)
        {
            waveData[0] = new WaveData(1, 1);
            waveData[1] = new WaveData(2, 2);
            waveData[2] = new WaveData(3, 3);
            waveData[3] = new WaveData(4, 1);
            waveData[4] = new WaveData(5, 2);
            waveData[5] = new WaveData(6, 3);
            waveData[6] = new WaveData(7, 1);
            waveData[7] = new WaveData(8, 2);
            waveData[8] = new WaveData(9, 3);
            waveData[9] = new WaveData(10, 1);
            waveData[10] = new WaveData(11, 2);
            waveData[11] = new WaveData(12, 3);
            waveData[12] = new WaveData(13, 1);
            waveData[13] = new WaveData(14, 2);
            waveData[14] = new WaveData(15, 3);
            InitComplete = true;
        }
    }

    public void GetMaxWaves(out int _max)
    {
        if (!InitComplete)
        {
            InitWaveData();
        }
        int maxNum = 0;

        //배열 늘리기로 체크
        bool[] check = new bool[32];

        check.Initialize();

        for (int i = 0; i < waveData.Length; i++)
        {
            if(maxNum < waveData[i].waveNum)
            {
                maxNum = waveData[i].waveNum;  //최대값 탐색
            }
            if(!check[waveData[i].waveNum-1])
            {
                check[waveData[i].waveNum-1] = true; //중복 및 순차값 체크용
                //Debug.Log(i + " 번째 배열 : " + (waveData[i].waveNum - 1));
            }
        }
        int maxValue = 0;
        for (int i = 0; i < check.Length-1; i++)
        {
            if(!check[i])
            {
                break;
            }
            maxValue = i;
            //Debug.Log((i+1) + " 번째 배열 : " + check[i]);
        }
        Debug.Log("배열의 최대값 = " + maxNum + " | " + "연속 최대값 = " + (maxValue +1));
        _max = maxValue;
    }
}

