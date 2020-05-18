using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public float m_speed = 10.0f;

        private Transform m_target;
        private int wavePointIndex = 0;

        private void Start()
        {
            m_target = Waypoint.Instance.points[0];
        }

        private void Update()
        {
            Vector3 dir = m_target.position - transform.position;
            transform.Translate(dir.normalized * m_speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, m_target.position) <= 0.2f)
            {
                GetnNextWaypoint();
            }
        }

        void GetnNextWaypoint()
        {
            if (wavePointIndex >= Waypoint.Instance.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavePointIndex++;
            m_target = Waypoint.Instance.points[wavePointIndex];
        }
    }
