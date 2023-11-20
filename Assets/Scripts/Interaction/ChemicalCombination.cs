using System;
using System.Collections;
using SO;
using UI_Chemical;
using UnityEngine;

namespace Interaction
{
    public class ChemicalCombination : MonoBehaviour
    {
        [SerializeField] private ChemicalCombinationsSo _chemicalCombinationsSo;
        [SerializeField] private ChemicalData _element1;
        [SerializeField] private ChemicalData _element2;
        [SerializeField] private float _waitingCombineTime = 2f;

        private bool _isCombining = false;
        private UIManagerChemical _uiManagerChemical;

        private void Start()
        {
            _uiManagerChemical = GetComponent<UIManagerChemical>();
        }

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
                        _uiManagerChemical.TextElement1.text = _element1.DataSo.NameChemicalElement;
                    }
                    else if (_element2 == null && _element1 != chemicalData)
                    {
                        _element2 = chemicalData;
                        _uiManagerChemical.TextElement2.text = _element2.DataSo.NameChemicalElement;

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

            (string combinationResult, Color colorReaction) =
                _chemicalCombinationsSo.GetCombinationResult(_element1.DataSo, _element2.DataSo);

            if (!string.IsNullOrEmpty(combinationResult))
            {
                Debug.Log("Combination found: " + combinationResult);
                Debug.Log("Color comb: " + colorReaction);
                _uiManagerChemical.GetReaction(colorReaction, combinationResult);
            }
            else
            {
                Debug.Log("Failed to combine");
                _uiManagerChemical.NoReacted();
            }

            yield return new WaitForSeconds(_waitingCombineTime);

            _element1 = null;
            _element2 = null;

            _isCombining = false;
        }
    }
}