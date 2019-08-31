using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDeathCounter : MonoBehaviour
{
    public TextMeshProUGUI deathCounterText;

    private GameManager gManager;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        deathCounterText.text = gManager.deathCount.ToString();
    }
}
