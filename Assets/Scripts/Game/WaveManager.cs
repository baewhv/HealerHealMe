using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : SingletonMonoBehaviour<WaveManager>
{
    public Transform enemyPrefab;

    public Transform SpawnPoint;

    public float m_waveCollTime = 5.0f;
    float m_countDown = 2.0f;

    public Text waveCountdownText;

    int CurrentWave = 0;    //UI에 표시 현재 웨이브 / 최대 웨이브
    int MaxWave = 0;        //UI에 표시

    private void Update()
    {
        if (CurrentWave <= MaxWave)
        {
            if (m_countDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                m_countDown = m_waveCollTime;
                Debug.Log(CurrentWave + "웨이브 ");
            }
            m_countDown -= Time.deltaTime;

            //waveCountdownText.text = Mathf.Floor(countDown).ToString();
            //Floor 가장 큰 int값을 내보냄. 
            waveCountdownText.text = Mathf.Round(m_countDown).ToString();
        }
    }

    IEnumerator SpawnWave()
    {
        CurrentWave++;

        for (int i = 0; i < OutData.Instance.waveData[CurrentWave-1].spawnMonsterCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        //Debug.Log("Wave Incomming!");

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
    override protected void OnStart()
    {
        base.OnStart();
        OutData.Instance.GetMaxWaves(out MaxWave);
        
    }
}
