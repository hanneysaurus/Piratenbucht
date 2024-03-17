using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipAreaHandler : MonoBehaviour
{
    public GameObject[] states = null;
    public GameObject[] upgrades = null;
    public GameObject statusRing = null;

    private int status = 1;
    private int MAX_STATUS = 7;
    private int MIN_STATUS = 0;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform state1_rectTransform = states[status].GetComponent<RectTransform>();
        statusRing.GetComponent<RectTransform>().localPosition = state1_rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetStatus()
    {
        return status;
    }
    public void SetStatus(int status)
    {
        this.status = status;
        Debug.Log(status);
    }

    public bool IncreaseStatus()
    {
        status++;
        if (status > MAX_STATUS)
        {
            status = MAX_STATUS;
            return false;
        } else {
            return true;
        }
    }

    public bool DecreaseStatus()
    {
        status--;
        if (status < MIN_STATUS)
        {
            status = MIN_STATUS;
            statusRing.SetActive(false);

            return false;
        } else {
            return true;
        }
    }
}
