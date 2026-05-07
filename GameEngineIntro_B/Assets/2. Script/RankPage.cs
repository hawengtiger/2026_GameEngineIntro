using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;     // Content 오브젝트
    [SerializeField] GameObject rowPrefab;      // RankRow 프리팹

    StageResultList allData;

    public Button stage1, stage2, stage3;

    public int _stage = 1;

    private void Start()
    {
        stage1.onClick.AddListener(() => RankStageChange(1));
        stage2.onClick.AddListener(() => RankStageChange(2));
        stage3.onClick.AddListener(() => RankStageChange(3));
    }

    public void RankStageChange(int stage)
    {
        _stage = stage;
        RefreshRankList();
    }

    private void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        // 랭크 데이터 정렬
        var sortedData = allData.results.Where(r => r.stage == _stage). OrderByDescending(x => x.score).ToList();

        // 랭크 데이터 생성
        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
    }
}
