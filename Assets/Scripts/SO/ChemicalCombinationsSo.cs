using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ChemicalCombinations", menuName = "CreateChemicalElement/ChemicalCombinations")]
    public class ChemicalCombinationsSo : ScriptableObject
    {
        [SerializeField] private List<CombinationData> combinations;

        [Serializable]
        public class CombinationData
        {
            public ChemicalDataSo element1;
            public ChemicalDataSo element2;
            public string result;
        }

        public string GetCombinationResult(ChemicalDataSo element1, ChemicalDataSo element2)
        {
            foreach (var combination in combinations)
            {
                if ((combination.element1 == element1 && combination.element2 == element2) ||
                    (combination.element1 == element2 && combination.element2 == element1))
                {
                    return combination.result;
                }
            }

            return "No Combination";
        }
    }
}