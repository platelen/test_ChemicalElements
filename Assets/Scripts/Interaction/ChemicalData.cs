using SO;
using UnityEngine;

namespace Interaction
{
    public class ChemicalData:MonoBehaviour
    {
        [SerializeField] private ChemicalDataSo _chemicalDataSo;

        public ChemicalDataSo DataSo => _chemicalDataSo;
    }
}