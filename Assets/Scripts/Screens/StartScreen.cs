using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    private void Start()
    {
        Open();
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
        WindowGroup.interactable = true;
        WindowGroup.blocksRaycasts = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
        WindowGroup.interactable = false;
        WindowGroup.blocksRaycasts = false;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
