using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleporttoroom : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    public Camera camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player"){
            Debug.Log("Transfering");
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport(){
        Destroy(target);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scene1");

    }
}
