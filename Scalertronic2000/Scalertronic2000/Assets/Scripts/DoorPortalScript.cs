using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortalScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          collision.gameObject.SetActive(false);
          Invoke("reload",1f);
        }
    }
    private void reload()
    {
     //   Scene scene = SceneManager.GetActiveScene();
        Debug.Log("bruh");
        SceneManager.LoadScene("Final");
    }
}
