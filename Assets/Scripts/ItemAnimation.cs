using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 1f, 0, Space.World);
    }
}
