using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI bridgeCounterText;

    private int _bridgesUsed = 0;
    private int _maxAllowed = 3;

    public void UpdateBridgeCounter()
    {
        _bridgesUsed += 1;
        bridgeCounterText.text = "Pontes Usadas: " + _bridgesUsed + "/" + _maxAllowed;
    }
}
