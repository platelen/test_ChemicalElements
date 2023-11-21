using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ChemicalCombinations", menuName = "CreateChemicalElement/ChemicalCombinations")]
    public class ChemicalCombinationsSo : ScriptableObject
    {
        [SerializeField] private List<CombinationData> _combinations;

        [Serializable]
        public class CombinationData
        {
            [SerializeField] private ChemicalDataSo _element1;
            [SerializeField] private ChemicalDataSo _element2;
            [SerializeField] private string _result;
            [SerializeField] private Color _colorReaction;

            public ChemicalDataSo Element1 => _element1;

            public ChemicalDataSo Element2 => _element2;

            public string Result => _result;
            public Color ColorReaction => _colorReaction;
        }

        public (string,Color) GetCombinationResult(ChemicalDataSo element1, ChemicalDataSo element2)
        {
            foreach (var combination in _combinations)
            {
                if ((combination.Element1 == element1 && combination.Element2 == element2) ||
                    (combination.Element1 == element2 && combination.Element2 == element1))
                {
                    return (combination.Result,combination.ColorReaction);
                }
            }
            return ("",Color.white);
        }
    }
}