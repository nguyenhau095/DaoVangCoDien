using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject m_map1;
    public GameObject m_map2;
    public GameObject m_map3;
    public GameObject m_map4;

    List<GameObject> m_listMap = new List<GameObject>();
    public static MapManager Instance { get; set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_listMap.Add(m_map1);
        m_listMap.Add(m_map2);
        m_listMap.Add(m_map3);
        m_listMap.Add(m_map4);
    }

    public void SetActiveMap(int map)
    {
        for (int i = 0; i < m_listMap.Count; i++)
        {
            if(i == map - 1)
            {
                m_listMap[i].SetActive(true);
            }
            else
            {
                m_listMap[i].SetActive(false);
            }
        }
        
    }
}
