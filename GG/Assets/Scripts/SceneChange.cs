using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject obj;
    public int levelToLoad;
    private Animator anim;

    private void Start()
    {
        anim = obj.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("fade");
        }
    }
     public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}