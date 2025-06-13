using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject eighth_note;

    private void Awake()
    {
        Instantiate(eighth_note);
    }
}
