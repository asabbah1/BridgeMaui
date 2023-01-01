namespace Bridge.Views;

public partial class ProfileView : BasePage
{
	public ProfileView(ProfileViewModel viewModel)
	{
		BindingContext = viewModel;
        this.FlowDirection = Common.GetFlowDirection();
        InitializeComponent();
	}
}