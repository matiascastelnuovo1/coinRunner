using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnFloor : MonoBehaviour
{
    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
