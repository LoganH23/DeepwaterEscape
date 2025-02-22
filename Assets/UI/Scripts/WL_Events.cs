using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WL_Events : MonoBehaviour
{
    private UIDocument _document;
    private Button _menu;
    private Button _exit;
    private Button _play;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _menu = _document.rootVisualElement.Q<Button>("menu");
        _exit = _document.rootVisualElement.Q<Button>("exit");
        _play = _document.rootVisualElement.Q<Button>("play");

        if (_menu != null)
        {
            _menu.RegisterCallback<ClickEvent>(OnMenu);
        }

        if (_exit != null)
        {
            _exit.RegisterCallback<ClickEvent>(OnExit);
        }

        if (_play != null)
        {
            _play.RegisterCallback<ClickEvent>(OnPlay);
        }
    }

    private void OnDisable()
    {
        if (_menu != null)
        {
            _menu.UnregisterCallback<ClickEvent>(OnMenu);
        }
        if (_exit != null)
        {
            _exit.UnregisterCallback<ClickEvent>(OnExit);
        }
        if (_play != null)
        {
            _play.UnregisterCallback<ClickEvent>(OnPlay);
        }
    }

    private void OnMenu(ClickEvent evt)
    {
        StartCoroutine(PlayMenu());
    }

    private IEnumerator PlayMenu()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        SceneManager.LoadScene("Main"); // Load the "Main" scene after the sound finishes
    }

    private void OnExit(ClickEvent evt)
    {
        StartCoroutine(PlayExit());
    }

    private IEnumerator PlayExit()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        Application.Quit();
    }

    private void OnPlay(ClickEvent evt)
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        SceneManager.LoadScene("1.Submarine"); // Load the "Main" scene after the sound finishes
    }
}
