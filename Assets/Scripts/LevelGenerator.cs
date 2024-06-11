using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] sections;
    public Transform player;
    public float deletionDistance = 200f;
    public float sectionLength = 100f;
    public int maxSections = 10; // Karakterin önündeki maksimum bölüm sayısı

    private List<GameObject> generatedSections = new List<GameObject>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateInitialSections();
    }

    private void Update()
    {
        // Karakterin z pozisyonunu al
        float playerZPos = player.position.z;

        // Karakterin 200 birim gerisinde kalan tüm section'ları sil
        DeleteSectionsBehindPlayer(playerZPos);

        // Karakterin önünde yeterince boşluk varsa yeni bir section oluştur
        if (playerZPos + deletionDistance > (generatedSections.Count - maxSections) * sectionLength)
        {
            GenerateSection();
        }
    }

    void GenerateInitialSections()
    {
        // İlk birkaç bölümü oluştur
        GameObject initialSection = Instantiate(sections[0], Vector3.zero, Quaternion.identity);
        generatedSections.Add(initialSection);

        for (int i = 1; i < maxSections; i++)
        {
            GenerateSection();
        }
    }

    void GenerateSection()
    {
        int randomIndex = Random.Range(1, sections.Length); // Dizinin ilk elemanı hariç rastgele seçim yap
        GameObject newSection = Instantiate(sections[randomIndex], new Vector3(0, 0, generatedSections.Count * sectionLength), Quaternion.identity);
        generatedSections.Add(newSection);
    }

    void DeleteSectionsBehindPlayer(float playerZPos)
    {
        for (int i = 0; i < generatedSections.Count; i++)
        {
            // Eğer section, karakterin deletionDistance birim gerisinde kaldıysa sil
            if (generatedSections[i].transform.position.z < playerZPos - deletionDistance)
            {
                Destroy(generatedSections[i]);
                generatedSections.RemoveAt(i);
                i--; // Liste boyutu bir azaldı, indeks değişmeli
            }
        }
    }
}
