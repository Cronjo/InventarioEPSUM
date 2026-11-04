using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] private string escenaCargar;
    [SerializeField] private string escenaBoton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(escenaCargar);
        }
    }

    public void CargarBoton()
    {
        SceneManager.LoadScene(escenaBoton);
    }
}
