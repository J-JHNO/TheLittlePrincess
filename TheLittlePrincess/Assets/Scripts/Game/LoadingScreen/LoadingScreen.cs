using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject _loadingScreen;
    public Image _loadingIcon;
    public TextMeshProUGUI _loadingText;
    public Animator _textAnimator;

    private int _lastTextIndex = 0;

    public void Start()
    {
        Hide();
        InitLoadingText();
    }

    public void Update()
    {
        _loadingIcon.transform.Rotate(0, 0, -2);
    }

    private void InitLoadingText()
    {
        _loadingText.text = ChooseRandomText();
    }

    private string ChooseRandomText()
    {
        List<string> texts = new List<string>();
        texts.Add("Did you know? The little princess is a hip-hop star in her planet");
        texts.Add("Hold F to dance !");
        texts.Add("You can save the game at any time by pressing escape");
        texts.Add("Some humans can help you in Fouras's castle");
        texts.Add("Did you know? The little princess comes from the planet SI4-FISA");
        texts.Add("You can unlock all the planets with the UnlockAll button");

        int newIndex = Random.Range(0, texts.Count);
        while (_lastTextIndex == newIndex) {
            newIndex = Random.Range(0, texts.Count);
        }
        _lastTextIndex = newIndex;
        return texts[newIndex];
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        Show();

        // Fake load of 8 seconds
        int count = 0;
        while (count < 8)
        {
            yield return new WaitForSeconds(1);
            count++;

            if (count == 4)
            {
                _textAnimator.SetBool("fading", true);
                Debug.Log("Fading");
                yield return new WaitForSeconds(2.95f);
                InitLoadingText();
                _textAnimator.SetBool("fading", false);
                Debug.Log("Stop fading");
            }
        }
        

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadingOperation.isDone)
        {
            count++;

            if (count % 4 == 0)
            {
                _textAnimator.SetBool("fading", true);
                yield return new WaitForSeconds(2);
                InitLoadingText();
                _textAnimator.SetBool("fading", false);
            }
        }
    }

    private void Show()
    {
        _loadingScreen.SetActive(true);
    }

    private void Hide()
    {
        _loadingScreen.SetActive(false);
    }
}
