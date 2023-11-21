using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ChemicalElement", menuName = "CreateChemicalElement/ChemicalElement")]
    public class ChemicalDataSo : ScriptableObject
    {
        [SerializeField] private string _nameChemicalElement;

        public string NameChemicalElement => _nameChemicalElement;
    }
}