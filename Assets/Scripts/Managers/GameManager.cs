using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine.XR;
using System;

namespace TuringTest
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelManager[] levels;

        private GameState currentState;
        private LevelManager currentLevel;
        private int currentLevelIndex = 0;
        private bool isInputActive = false;
        
        #region singleton
        public static GameManager instance;
        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }
        public static GameManager GetInstance() { return instance; }
        #endregion


        public bool IsInputActive()
        {
            return isInputActive; 
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(levels.Length > 0)
            {
                ChangeState(GameState.BriefingCutscene, levels[currentLevelIndex]);
            }
        }

        public void ChangeState(GameState state, LevelManager level)
        {
            currentState = state;
            currentLevel = level;

            switch (currentState)
            {
                case GameState.BriefingCutscene:
                    StartBriefing();
                    break;
                case GameState.LevelEnter:
                    LevelEnter();
                    break;
                case GameState.LevelUpdate:
                    LevelUpdate();
                    break;
                case GameState.LevelExit:
                    LevelExit();
                    break;
                case GameState.GameOver:
                    GameOver();
                    break;
                case GameState.GameEnd:
                    GameEnd();
                    break;
            }
        }

        public void GameEnd()
        {
            Debug.Log("Game Ending");
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
        }

        private void LevelExit()
        {
            Debug.Log("Level Exit");
            ChangeState(GameState.LevelEnter, levels[++currentLevelIndex]);
        }

        private void LevelUpdate()
        {
            Debug.Log("Running Curent Level" + currentLevel.gameObject.name);
        }

        private void LevelEnter()
        {
            Debug.Log("Level Enter");
            isInputActive = true;
            currentLevel.LevelEnter();
            ChangeState(GameState.LevelUpdate, currentLevel);
        }

        private void StartBriefing()
        {
            Debug.Log("Briefing State Started");
            isInputActive = false;
            ChangeState(GameState.LevelEnter, currentLevel);
        }
    }
}
