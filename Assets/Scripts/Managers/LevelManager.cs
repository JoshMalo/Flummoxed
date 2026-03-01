using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace TuringTest
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private bool isFinalLevel;

        public UnityEvent OnLevelEnter, OnLevelExit;

        public void LevelEnter()
        {
            OnLevelEnter?.Invoke();
        }

        public void LevelExit()
        {

            OnLevelExit?.Invoke();

            if(isFinalLevel)
            {
                GameManager.GetInstance().ChangeState(GameState.GameEnd, this);
            }
            else
            {
                GameManager.GetInstance().ChangeState(GameState.LevelExit, this);
            }
        }


    }   
}
