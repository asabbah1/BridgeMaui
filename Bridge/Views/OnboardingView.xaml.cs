namespace Bridge.Views;

public partial class OnboardingView : BasePage
{
	public OnboardingView(OnboardingViewModel viewModel)
	{
        BindingContext = viewModel;
        this.FlowDirection = Common.GetFlowDirection();
        InitializeComponent();
    }
}