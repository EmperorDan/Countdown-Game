using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoopBytes.System;
using LoopBytes.Database;
using Game.Algorithm;
namespace Game {

    public enum FinishState
    {
        Win,
        HalfWin,
        Lose
    }

    public class App : Singleton<App>  {
       
        [SerializeField, Tooltip("X: Amount to deposit if the user's word is valid and also is the best solution, \n"
            + "Y: Amount to deposit if the user's word is valid but is not the best, \n"
            + "Z: Amount to be withdrawn if the user's word is not valid, when he loses.")]
        private Vector3 amounts;

        private float _wallet;
        
       
        public float Wallet { get { return _wallet; } }



        public delegate void OnFinishSignature(FinishState state);
        public static event OnFinishSignature OnFinish;



        // This is called on Awake
        protected override void Init()  {           
          
        }


        public void Finish(FinishState state) {
            switch (state) {
                case FinishState.Win:
                    _wallet += amounts.x;
                    break;
                case FinishState.HalfWin:
                    _wallet += amounts.y;
                    break;
                case FinishState.Lose:
                    _wallet -= amounts.z;
                    break;
            }

            if (OnFinish != null) OnFinish(state);
        }
    }
}

