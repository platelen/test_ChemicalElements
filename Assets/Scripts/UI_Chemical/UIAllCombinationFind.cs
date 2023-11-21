using System;
using Events;
using Interaction;
using TMPro;
using UnityEngine;

namespace UI_Chemical
{
    public class UIAllCombinationFind : MonoBehaviour
    {
        [SerializeField] private ChemicalCombination _chemicalCombination;
        [SerializeField] private GameObject _panelRect;
        [SerializeField] private GameObject _objectResultCombinePrefab;
        [SerializeField] private TextMeshProUGUI _textAllCombine;
        [SerializeField] private TextMeshProUGUI _textCountCombine;

        private bool _allCombinationsCollected = false;
        private string _defaultCombine = "Не все комбинации собраны!";

        private void Start()
        {
            _chemicalCombination.OnSuccessfulCombination += HandleSuccessfulCombination;
            _chemicalCombination.OnAllCombinationsCollected += HandleAllCombinationsCollected;
            _textAllCombine.text = _defaultCombine;
            _textCountCombine.text = $"Осталость собрать: {_chemicalCombination.AllCombine.ToString()}.";
        }

        private void Update()
        {
            _textCountCombine.text = $"Осталость собрать: {_chemicalCombination.AllCombine.ToString()}.";
        }

        private void HandleSuccessfulCombination(string combinationResult)
        {
            GameObject resultObject = Instantiate(_objectResultCombinePrefab, _panelRect.transform);
            TextMeshProUGUI resultText = resultObject.GetComponentInChildren<TextMeshProUGUI>();

            if (resultText != null)
            {
                resultText.text = combinationResult;
            }
        }

        private void HandleAllCombinationsCollected()
        {
            _allCombinationsCollected = true;
            GlobalEvents.SendStartFinishGame();
        }
    }
}