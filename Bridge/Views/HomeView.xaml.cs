

using CommunityToolkit.Mvvm.Messaging;

namespace Bridge.Views;

public partial class HomeView : BasePage
{
	public HomeView(HomeViewModel viewModel)
	{
		BindingContext = viewModel;
        this.FlowDirection = Common.GetFlowDirection();
        InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

  //      WeakReferenceMessenger.Default.Register<object, string>(this, HomeViewModel.ScrollToPreviousLastItem, (sender, item) =>
		//{
		//	listProducts.ScrollTo(item, ScrollToPosition.End);
		//});
	}

}