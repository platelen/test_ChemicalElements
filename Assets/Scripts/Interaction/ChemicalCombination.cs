using System.Collections;
using SO;
using UnityEngine;

namespace Interaction
{
    public class ChemicalCombination : MonoBehaviour
    {
        [SerializeField] private ChemicalCombinationsSo _chemicalCombinationsSo;
        [SerializeField] private ChemicalData _element1;
        [SerializeField] private ChemicalData _element2;
        [SerializeField] private float _waitingCombine = 2f;

        private bool _isCombining = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isCombining && other.gameObject.layer == LayerMask.NameToLayer("Flask"))
            {
                ChemicalData chemicalData = other.GetComponent<ChemicalData>();
                if (chemicalData != null)
                {
                    if (_element1 == null)
                    {
                        _element1 = chemicalData;
                    }
                    else if (_element2 == null && _element1 != chemicalData)
                    {
                        _element2 = chemicalData;

                        if (_element1 != null && _element2 != null)
                        {
                            StartCoroutine(CombineElements());
                        }
                    }
                }
            }
        }

        private IEnumerator CombineElements()
        {
            _isCombining = true;

            string combinationResult = _chemicalCombinationsSo.GetCombinationResult(_element1.DataSo, _element2.DataSo);

            if (!string.IsNullOrEmpty(combinationResult))
            {
                Debug.Log("Combination found: " + combinationResult);
            }
            else
            {
                Debug.Log("Failed to combine");
            }

            yield return new WaitForSeconds(_waitingCombine);

            _element1 = null;
            _element2 = null;

            _isCombining = false;
        }
    }
}