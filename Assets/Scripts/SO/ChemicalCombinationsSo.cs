using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Combination", menuName = "Create Chemical Combination/New Combination")]
    public class ChemicalCombinationsSo : ScriptableObject
    {
        [SerializeField] private string _combination;
        [SerializeField] private ChemicalDataSo _element1;
        [SerializeField] private ChemicalDataSo _element2;

        public string Combination => _combination;

        public ChemicalDataSo Element1 => _element1;

        public ChemicalDataSo Element2 => _element2;
        
    }
}