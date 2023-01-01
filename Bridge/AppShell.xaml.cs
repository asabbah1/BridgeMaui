using Bridge.Views;

namespace Bridge;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        this.FlowDirection = Common.GetFlowDirection();

        Routing.RegisterRoute(nameof(LoginView),
               typeof(LoginView));

        Routing.RegisterRoute(nameof(HomeView),
            typeof(HomeView));

    }
}
