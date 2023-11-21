using Interaction;
using TMPro;
using UnityEngine;

namespace UI_Chemical
{
    public class UIAllCombinationFind : MonoBehaviour
    {
        [SerializeField] private ChemicalCombination _chemicalCombination;
        [SerializeField] private GameObject _panelRect;
        [SerializeField] private GameObject _objectResultCombinePrefab; // Префаб объекта с текстовым полем

        private void Start()
        {
            // Подписываемся на событие успешной комбинации
            _chemicalCombination.OnSuccessfulCombination += HandleSuccessfulCombination;
        }

        private void HandleSuccessfulCombination(string combinationResult)
        {
            // Создаем новый объект на основе префаба
            GameObject resultObject = Instantiate(_objectResultCombinePrefab, _panelRect.transform);

            // Находим текстовое поле в созданном объекте
            TextMeshProUGUI resultText = resultObject.GetComponentInChildren<TextMeshProUGUI>();

            // Устанавливаем значение текстового поля
            if (resultText != null)
            {
                resultText.text = combinationResult;
            }
        }
    }
}
