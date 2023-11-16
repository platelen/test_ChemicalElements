using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;

namespace Interaction
{
    public class ChemicalCombination : MonoBehaviour
    {
        [SerializeField] private List<ChemicalCombinationsSo> _chemicalCombinationsSo;
        [SerializeField] private ChemicalData _element1;
        [SerializeField] private ChemicalData _element2;

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

            // Ваша логика комбинирования элементов

            // Ждем некоторое время
            yield return new WaitForSeconds(2f);

            // Освобождаем поля
            _element1 = null;
            _element2 = null;

            _isCombining = false;
        }
    }
}