using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyShredder : MonoBehaviour
{
    [SerializeField] private NarrationManager4 nManager;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider);
        nManager.floppyThrown = false;
    }
}
