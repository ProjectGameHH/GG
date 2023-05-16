using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject obj;
    public int levelToLoad;
    public bool work = false;
    private Animator anim;

    private void Start()
    {
        anim = obj.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ABOBA");
            work = true;
            anim.SetTrigger("fade");
        }
    }
     public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}