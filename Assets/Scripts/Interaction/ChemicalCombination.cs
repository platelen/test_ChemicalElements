using System.Collections.Generic;
using SO;
using UnityEngine;

namespace Interaction
{
    public class ChemicalCombination:MonoBehaviour
    {
        [SerializeField] private List<ChemicalCombinationsSo> _chemicalCombinationsSo;
        [SerializeField] private ChemicalData _element1;
        [SerializeField] private ChemicalData _element2;
    }
}