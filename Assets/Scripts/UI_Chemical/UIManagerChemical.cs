using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Chemical
{
    /// <summary>
    /// Вешается на Object с ChemicalCombination на сцене.
    /// </summary>
    public class UIManagerChemical : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textElement1;
        [SerializeField] private TextMeshProUGUI _textElement2;
        [SerializeField] private Image _colorResultReaction;
        [SerializeField] private TextMeshProUGUI _textGetOrNoteReaction;
        [SerializeField] private TextMeshProUGUI _textChemicalResult;
        [SerializeField] private GameObject _panelNoReacted;

        private string _getReaction = "Вы получили: ";


        private void Start()
        {
            ResetTextElements();
            _textChemicalResult.enabled = false;
            _textGetOrNoteReaction.enabled = false;
        }

        public TextMeshProUGUI TextElement1 => _textElement1;
        public TextMeshProUGUI TextElement2 => _textElement2;

        public void NoReacted()
        {
            _textChemicalResult.enabled = false;
            _panelNoReacted.SetActive(true);
        }

        public void GetReaction(Color colorReaction, string combResult)
        {
            EnabledTextResult();

            _textGetOrNoteReaction.text = _getReaction;
            _colorResultReaction.color = colorReaction;
            _colorResultReaction.color = new Color(colorReaction.r, colorReaction.g, colorReaction.b, 1f);
            _textChemicalResult.text = combResult;
        }

        private void EnabledTextResult()
        {
            _textChemicalResult.enabled = true;
            _textGetOrNoteReaction.enabled = true;
        }

        public void ResetTextElements()
        {
            _panelNoReacted.SetActive(false);
            _textElement1.text = "";
            _textElement2.text = "";
        }
    }
}