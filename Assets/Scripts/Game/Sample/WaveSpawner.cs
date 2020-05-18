using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace sample
{
    public class WaveSpawner : SingletonMonoBehaviour<WaveSpawner>
    {
        public Transform enemyPrefab;

        public Transform SpawnPoint;

        public float timerBetweenWaves = 5.0f;
        private float countDown = 2.0f;

        public Text waveCountdownText;

        private int waveIndex = 1;

        private void Update()
        {
            if (countDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countDown = timerBetweenWaves;
            }

            countDown -= Time.deltaTime;

            //waveCountdownText.text = Mathf.Floor(countDown).ToString();
            //Floor 가장 큰 int값을 내보냄. 
            waveCountdownText.text = Mathf.Round(countDown).ToString();
            
        }

        IEnumerator SpawnWave()
        {
            waveIndex++;

            for (int i =0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("Wave Incomming!");
            
        }

        void SpawnEnemy()
        {
            Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }

    }
}