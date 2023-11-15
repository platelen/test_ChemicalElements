using UnityEngine;

namespace Interaction
{
    public class ClickableObject : MonoBehaviour
    {
        private void OnMouseDown()
        {
            string nameChemical = GetComponent<ChemicalData>().DataSo.NameChemicalElement;
            string colorChemical = GetComponent<ChemicalData>().DataSo.ElementColor.ToString();

            Debug.Log($"Clicked on: {nameChemical}, color chemical: {colorChemical}");
            // Дополнительная логика или вывод информации
        }
    }
}