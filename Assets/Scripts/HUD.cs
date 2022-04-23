using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text alertText;
    [SerializeField] private Button simpleBt;
    [SerializeField] private Button diffBt;
    [SerializeField] private GameObject hidePannel;
    [SerializeField] private GameObject btPannel;

    public Action<State> OnDiffGame;

    private void Awake()
    {
        diffBt.onClick.AddListener(()=>DiffGame(new DifficultState()));
        simpleBt.onClick.AddListener(() => DiffGame(new SimpleState()));
    }
    public void PlayerWin()
    {
        alertText.text = "You win!";
    }
    public void PlayerLose()
    {
        alertText.text = "You lose!";
    }
    public void Standoff()
    {
        alertText.text = "Standoff!";
    }
    public void ChooseGame()
    {
        hidePannel.SetActive(true);
        alertText.text = "Choose ur game!";
    }
    private void DiffGame(State state)
    {
        OnDiffGame?.Invoke(state);
        alertText.text = "";
        btPannel.SetActive(false);
        hidePannel.SetActive(false);
    }
    private void OnDisable()
    {
        diffBt.onClick.RemoveListener(() => DiffGame(new DifficultState()));
        simpleBt.onClick.RemoveListener(() => DiffGame(new SimpleState()));
    }
}
