using UnityEngine;

namespace Interaction
{
    public class ClickableObject : MonoBehaviour
    {
        private void OnMouseDown()
        {
            string nameChemical = GetComponent<ChemicalData>().DataSo.NameChemicalElement;
        }
    }
}