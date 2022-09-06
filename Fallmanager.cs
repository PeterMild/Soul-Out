using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallmanager : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Healthbar.health = Healthbar.health - Healthbar.health;
    }
}
