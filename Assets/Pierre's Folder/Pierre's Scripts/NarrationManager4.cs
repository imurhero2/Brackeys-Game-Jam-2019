using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationManager4 : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("1-4 Intro");
    }
}
