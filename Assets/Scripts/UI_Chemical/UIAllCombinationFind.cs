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

        private bool _allCombinationsCollected = false;
        private string _defaultCombine = "Не все комбинации собраны!";
        private string _collectedCombine = "Поздравляю! Все комбинации собраны!";

        private void Start()
        {
            _chemicalCombination.OnSuccessfulCombination += HandleSuccessfulCombination;
            _chemicalCombination.OnAllCombinationsCollected += HandleAllCombinationsCollected;
            _textAllCombine.text = _defaultCombine;
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
            _textAllCombine.text = _collectedCombine;
        }
    }
}