using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMovementScript : MonoBehaviour
{
    [SerializeField] private int rotateX;
    [SerializeField] private int rotateY;
    public bool backwards;

    void Update()
    {
        float rotationZ = this.gameObject.transform.rotation.z;

        if (backwards)
        {
            if (rotationZ > -50)
            {
                this.gameObject.transform.Rotate(0, 0, 1);
            }
            else if (rotationZ < 50)
            {
                this.gameObject.transform.Rotate(0, 0, -1);
            }
        }
        else
        {
            if (rotationZ > -50)
            {
                this.gameObject.transform.Rotate(0, 0, -1);
            }
            else if (rotationZ < 50)
            {
                this.gameObject.transform.Rotate(0, 0, 1);
            }
        }
    }
}
