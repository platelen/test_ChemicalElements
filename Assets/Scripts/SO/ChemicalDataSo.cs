using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ChemicalElement", menuName = "CreateChemicalElement/ChemicalElement")]
    public class ChemicalDataSo : ScriptableObject
    {
        [SerializeField] private string _nameChemicalElement;
        [SerializeField] private Color _elementColor;

        public string NameChemicalElement => _nameChemicalElement;
        public Color ElementColor => _elementColor;
    }
}