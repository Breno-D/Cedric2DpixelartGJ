using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public float maxCount;
    public float currCount;
    [SerializeField] float zeroTimer;
    [SerializeField] Image counterFill;
    [SerializeField] GameObject endOfGamePanel;
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
            FindObjectOfType<PlayerInput>().DisablePlayerControls();
            endOfGamePanel.SetActive(true);
        }
        else if(currCount > maxCount)
        {
            currCount = maxCount;
        }
    }

    void UpdateCounterUI()
    {
        counterFill.fillAmount = currCount/maxCount;
    }
}
