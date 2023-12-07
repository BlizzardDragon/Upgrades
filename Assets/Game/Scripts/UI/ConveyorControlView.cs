using UnityEngine;
using UnityEngine.UI;

public class ConveyorControlView : MonoBehaviour
{
    [SerializeField] private Button _increaseButton;
    [SerializeField] private Button _reduceButton;

    private IConveyorControlPresentationModel _presentationModel;


    public void Setup(IConveyorControlPresentationModel presentationModel)
    {
        _presentationModel = presentationModel;
    }

    private void OnEnable()
    {
        _increaseButton.onClick.AddListener(_presentationModel.OnIncrease);
        _reduceButton.onClick.AddListener(_presentationModel.OnReduce);
    }

    private void OnDisable()
    {
        _increaseButton.onClick.RemoveListener(_presentationModel.OnIncrease);
        _reduceButton.onClick.RemoveListener(_presentationModel.OnReduce);
    }
}