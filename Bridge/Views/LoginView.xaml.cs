using Bridge.ViewModels;

namespace Bridge.Views;

public partial class LoginView : BasePage
{
	public LoginView(LoginViewModel viewModel)
	{
		BindingContext = viewModel;
        this.FlowDirection = Common.GetFlowDirection();
        InitializeComponent();
	}
}