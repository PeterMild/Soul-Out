using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Healthbar.health += 20f;
    }
}
