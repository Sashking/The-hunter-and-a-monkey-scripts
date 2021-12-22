using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Bow bow;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Transform bananaTransform;
    [SerializeField] private Transform bowTransform;
    private float m_FirePowerSpeed;
    
    private void Update()
    {
        bowTransform.LookAt(bananaTransform); // Pořád míří lukem na banán
        m_FirePowerSpeed = 10 + slider.value * 20; // Výpočet počáteční rychlosti na základě slideru na obrazovce
        text.text = Math.Round(m_FirePowerSpeed, 2).ToString(); // Aktualizuje hodnotu textu na aktuální rychlost palebné síly
    }

    // Funkce odpovídající za střelbu
    public void Shoot()
    {
        bowTransform.LookAt(bananaTransform); // Zamíří luk na banán
        bow.Fire(m_FirePowerSpeed); // Zavolá funkci ze skriptu luku
    }
}
