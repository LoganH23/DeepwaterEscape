using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _startButton;
    private Button _exitButton;
    private Button _howToPlayButton;
    private List<Button> _menuButtons = new List<Button>();
    private AudioSource _audioSource;

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _startButton = _document.rootVisualElement.Q<Button>("Start");
        _exitButton = _document.rootVisualElement.Q<Button>("Exit");
        _howToPlayButton = _document.rootVisualElement.Q<Button>("HowToPlay");

        if (_startButton != null)
        {
            _startButton.RegisterCallback<ClickEvent>(OnPlayGameClick);
        }

        if (_exitButton != null)
        {
            _exitButton.RegisterCallback<ClickEvent>(OnExitGameClick);
        }

        if (_howToPlayButton != null)
        {
            _howToPlayButton.RegisterCallback<ClickEvent>(OnHowToPlayClick);
        }

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        foreach (var button in _menuButtons)
        {
            button.RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        if (_startButton != null)
        {
            _startButton.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        }

        if (_exitButton != null)
        {
            _exitButton.UnregisterCallback<ClickEvent>(OnExitGameClick);
        }

        if (_howToPlayButton != null)
        {
            _howToPlayButton.UnregisterCallback<ClickEvent>(OnHowToPlayClick);
        }

        foreach (var button in _menuButtons)
        {
            button.UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You Pressed the Start Button");
        StartCoroutine(PlayStart());
    }

    private void OnHowToPlayClick(ClickEvent evt)
    {
        Debug.Log("You Pressed the HowToPlay Button");
        StartCoroutine(PlayHowto());
    }

    private void OnExitGameClick(ClickEvent evt)
    {
        Debug.Log("You Pressed the Exit Button");
        StartCoroutine(PlayExit());
        Application.Quit();
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _audioSource.Play();
    }
    private IEnumerator PlayStart()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        SceneManager.LoadScene("1.Submarine"); // Load the "Main" scene after the sound finishes
    }

    private IEnumerator PlayHowto()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        SceneManager.LoadScene("Howto"); // Load the "Main" scene after the sound finishes
    }


    private IEnumerator PlayExit()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length); // Wait for the sound to finish
        Application.Quit();
    }

}
