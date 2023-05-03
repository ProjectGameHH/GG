using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string nextScene = "";
    private bool disableFadeInAnimation = false;

    private void Start()
    {
        if (disableFadeInAnimation)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.Play("FadeIn", 0, 1);
        }
    }

    void FadeOutFinished()
    {
        SceneManager.LoadScene(nextScene);
    }
}