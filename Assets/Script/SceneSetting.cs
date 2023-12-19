using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneSetting : MonoBehaviour
{
    public Animator loadMarginLeftAnimator;
    public Animator loadMarginRightAnimator;
    public Animator settingAnimator;

    public void OnHome(){
        StartCoroutine(LoadHome());
    }

    public void OnPlayGame(){
        StartCoroutine(LoadGamePlay());
    }
    
    public void OnExit(){
        Application.Quit();
    }

    private IEnumerator LoadHome(){
        loadMarginLeftAnimator.SetTrigger(AnimationString.Close);
        loadMarginRightAnimator.SetTrigger(AnimationString.Close);
        settingAnimator.SetTrigger(AnimationString.Close);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }

    private IEnumerator LoadGamePlay(){
        loadMarginLeftAnimator.SetTrigger(AnimationString.Close);
        loadMarginRightAnimator.SetTrigger(AnimationString.Close);
        settingAnimator.SetTrigger(AnimationString.Close);
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(1);
    }
}