using UnityEngine;

[CreateAssetMenu(fileName = "normalEgg", menuName = "Scriptable Objects/normalEgg")]
public class normalEgg : ScriptableObject
{
    [SerializeField] Sprite eggImage;
    [SerializeField] int chance;
    [SerializeField] int value;

    public Sprite eggImage_get => eggImage;
    public int chance_get => chance;
    public int value_get => value;
}