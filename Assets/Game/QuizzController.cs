using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LoopBytes;
using Game.Algorithm;
using LoopBytes.Database;
using LoopBytes.UI;
using Game.UI;
namespace Game {
    [RequireComponent(typeof(Timer))]
    public class QuizzController : MonoBehaviour {


        [SerializeField] private string databasePath;
        [Header("Containers")]
        [SerializeField] private RectTransform letterContainer;
        [SerializeField] private GameObject wordContainer;
        [SerializeField] private GameObject letterBoxPrefab;
        [SerializeField] private GameObject header;
        [SerializeField] private Text picksCounter;
        [SerializeField] private GameObject TimerContainer;
        [SerializeField] private Text Wallet;

        [SerializeField] private FinishWindow FinishWindow;

        [Header("Messages")]
        [SerializeField, TextArea] private string AnswerMessage = "You're word '{0}' is not valid or does not exists in our dictionary.";
        [SerializeField, TextArea] private string TitleLoseMessage = "You have lost!";
        [SerializeField, TextArea] private string TitleHalfMessage = "You won just a half, boy";
        [SerializeField, TextArea] private string TitleWinMessage = "You're a realy playa', don't cha'?";
        private DatabaseManager db;
        private CountdownAlgo algo;      
               
        private Timer _timer;
        private LetterPool _letterPool = new LetterPool();
        

        // RULES: 9 Letters, 3 vowels, 6 consanants || 5 vowels, 4 consanants
        // Use this for initialization
        void Start() {
            _timer = GetComponent<Timer>();
            Timer.OnFinish += ValidateWord;
            db = new DatabaseManager(databasePath);
            algo = new CountdownAlgo(db);           
            UpdatePicksTries();
            UpdateWallet();
        }        

        private void UpdateWallet()
        {
            Wallet.text = string.Format("Your Wallet: {0}", App.Instance.Wallet);
        }

        public void OnPick(bool isVol = false) {
            var letter = _letterPool.Pick(isVol);
            var o = Instantiate(letterBoxPrefab);        
            o.transform.SetParent(letterContainer);           
            o.GetComponentInChildren<Text>().text = letter.ToString().ToUpper();
            UpdatePicksTries();
            if (_letterPool.IsFull) {
                // TODO:: Fire event, end of picking
                header.SetActive(false);
                _timer.enabled = true;
                TimerContainer.SetActive(true);
            }
            
        }

        private void UpdatePicksTries() {
            picksCounter.text = string.Format("Picks: {0}", _letterPool.Tries);
        }

        private void ValidateWord() {
            var list = wordContainer.GetComponentsInChildren<Text>();
            string word = "";
            foreach(var letter in list)
                word += letter.text;

            var state = FinishState.Lose;
            var solution = algo.Solve(_letterPool.Word);
            if (solution == null)
                Debug.LogError("No word was found in the database");

            var playerResult = db.Exists(word);
            FinishWindow.gameObject.SetActive(true);
            FinishWindow.Answer = string.Format(AnswerMessage, word);
            FinishWindow.FormatSolution(solution);
            FinishWindow.Title = TitleLoseMessage;
            if (playerResult) {
                state = FinishState.HalfWin;
                FinishWindow.FormatAnswer(word);
                FinishWindow.Title = TitleHalfMessage;                
                if (word.Length >= solution.Length) {
                    state = FinishState.Win;
                    FinishWindow.Title = TitleWinMessage;
                }
                                                   
            }
            ClearScene();            
            App.Instance.Finish(state);
            UpdateWallet();
            Debug.LogFormat("User Best: {0} | Database Best: {1}", word, solution);
        }

        private void ClearScene() {
            wordContainer.SetActive(false);
            letterContainer.gameObject.SetActive(false);
            TimerContainer.SetActive(false);
        }


        public void RestartGame() {
            SceneLoader.Instance.ResetScence();
        }

        public void GoToMenu() {
            SceneLoader.Instance.LoadMenu();
        }
    }
}
