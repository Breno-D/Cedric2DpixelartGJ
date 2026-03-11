using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float maxCount;
    public float currCount;
    [SerializeField] float zeroTimer;
    float target;

    void Awake()
    {
        currCount = maxCount;
    }

    void FixedUpdate()
    {
        CountDownCounter();
        UpdateCounterUI();
    }

    void CountDownCounter()
    {
        target = (100f/zeroTimer) * Time.deltaTime;
        currCount = Mathf.MoveTowards(currCount, 0, target);
        if(currCount <= 0)
        {
            // EOG
        }
    }

    void UpdateCounterUI()
    {
        
    }
}
