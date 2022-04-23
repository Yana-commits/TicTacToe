using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<Mark> marks = new List<Mark>();
    [SerializeField] private HUD hud;

    private Bot bot;
    private List<Mark> usedMarks = new List<Mark>();
    private Dictionary<string, Sprite> spriteByName = new Dictionary<string, Sprite>();
    private PlayMode playMode = PlayMode.Players;
    private GameMode gameMode = GameMode.Play;
    private void Awake()
    {
        spriteByName = sprites.ToDictionary(k => k.name, v => v);
        
        hud.ChooseGame();
        hud.OnDiffGame += SetGameType;
    }
    void Start()
    {
        gameMode = GameMode.Play;

        for (var i = 0; i < marks.Count; i++)
        {
            marks[i].Init(i);
            marks[i].OnClic += SetAsMarked;
        }
    }

    private void SetGameType(State state)
    {
        bot = new Bot(state);
    }
    private void SetAsMarked(Mark mark)
    {
        if (gameMode == GameMode.Play)
        {
            Sprite _sprite = null;

            if (playMode == PlayMode.Players)
            {
                _sprite = spriteByName["mark_X"];
                mark.CurMark = TicTacMark.X;
            }
            else
            {
                _sprite = spriteByName["mark_O"];
                mark.CurMark = TicTacMark.O;
            }

            mark.Image.color = new Color(255, 255, 255, 1f);
            mark.Image.sprite = _sprite;
            mark.Image.raycastTarget = false;

            WinCheck(mark);
        }
    }

    private void WinCheck(Mark mark)
    {
        SetMarkToArr(mark);
        bool winChecker = new WinChecker(playMode, marks).CheckIfWin();

        if (winChecker)
        {
    
            if (playMode == PlayMode.Players)
                hud.PlayerWin();

            else
                hud.PlayerLose();

            StartCoroutine(AnotherGame());
        }
        else if (usedMarks.Count == marks.Count)
        {
            hud.Standoff();
            StartCoroutine(AnotherGame());
        }
        SwitchPlayer();
    }

    private IEnumerator AnotherGame()
    {
        gameMode = GameMode.Stop;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }

    private void AisTurn()
    {
        if (playMode == PlayMode.AIs)
        {
            bot.ChooseMark(marks);
            StartCoroutine(SetAiMark());
        }
    }

    private IEnumerator SetAiMark()
    {
        yield return new WaitForSeconds(1f);
        SetAsMarked(marks[bot.index]);
    }

    private void SwitchPlayer()
    {
        if (gameMode == GameMode.Play)
        {
            playMode = playMode == PlayMode.Players ? PlayMode.AIs : PlayMode.Players;
            AisTurn();
        }
    }

    private void SetMarkToArr(Mark mark)
    {
        usedMarks.Add(mark);
    }

    private void OnDisable()
    {
        hud.OnDiffGame -= SetGameType;
        foreach (var item in marks)
        {
           item.OnClic -= SetAsMarked;
        }
    }
}

