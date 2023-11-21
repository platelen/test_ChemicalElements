using Interaction;
using TMPro;
using UnityEngine;

namespace UI_Chemical
{
    public class UIInformationAboutChemical : MonoBehaviour
    {
        [SerializeField] private ChemicalData _chemicalData;
        [SerializeField] private TextMeshProUGUI _textInfo;

        private void Start()
        {
            _textInfo.text = _chemicalData.DataSo.NameChemicalElement;
        }
    }
}