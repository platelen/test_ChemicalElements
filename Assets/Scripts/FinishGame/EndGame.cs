using Events;
using UnityEngine;

namespace FinishGame
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject _panelCongratulations;
        [SerializeField] private GameObject[] _panelsAll;

        private void Awake()
        {
            GlobalEvents.OnStartFinishGame.AddListener(FinishedGame);
        }

        private void Start()
        {
            _panelCongratulations.SetActive(false);
        }

        private void FinishedGame()
        {
            foreach (var panels in _panelsAll)
            {
                panels.SetActive(false);
            }

            _panelCongratulations.SetActive(true);
        }

        private void OnDestroy()
        {
            GlobalEvents.OnStartFinishGame.RemoveListener(FinishedGame);
        }
    }
}