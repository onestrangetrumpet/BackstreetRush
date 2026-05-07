using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    float distance;
    public TextMeshProUGUI distanceText;
    
    // Update is called once per frame
    void Update()
    {
        distance += Time.unscaledDeltaTime;
        distanceText.text = distance.ToString("00.00");
    }
}
