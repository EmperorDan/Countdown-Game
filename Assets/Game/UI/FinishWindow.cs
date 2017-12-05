using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.UI
{
    public class FinishWindow : MonoBehaviour {
        [Header("Texts")]
        [SerializeField] private Text _title;
        [SerializeField] private Text _answer;
        [SerializeField] private Text _solution;
        [Header("Buttons")]
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        [Header("Events")]
        public UnityEvent onConfirm;
        public UnityEvent onCancel;


        public string Title { get { return _title.text; } set { _title.text = value; } }
        public string Answer { get { return _answer.text; } set { _answer.text = value; } }
        public string Solution { get { return _solution.text; } set { _solution.text = value; } }
        private void Start()
        {
            _confirmButton.onClick.AddListener(() => onConfirm.Invoke());
            _cancelButton.onClick.AddListener(() => onCancel.Invoke());
        }

        private void OnDisable() {
            _confirmButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.RemoveAllListeners();
        }

        public void FormatAnswer(string answer)
        {
            _answer.text = string.Format("Your answer is '{0}'", answer);
        }

        public void FormatSolution(string solution)
        {
            _solution.text = string.Format("The best solution is '{0}'", solution);
        }

    }
}
