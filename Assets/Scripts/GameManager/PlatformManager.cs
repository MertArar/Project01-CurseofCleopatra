using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private int _zedOffset;

    void Start()
    {
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            Instantiate(platformPrefabs[i], new Vector3(0, 0, i * 12), Quaternion.Euler(0,0,0));
            _zedOffset += 100;
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, _zedOffset);
        _zedOffset += 12;
    }
}
