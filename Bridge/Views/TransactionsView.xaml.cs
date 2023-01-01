namespace Bridge.Views;

public partial class TransactionsView : BasePage
{
	public TransactionsView(TransactionsViewModel viewModel)
	{
		BindingContext = viewModel;
        this.FlowDirection = Common.GetFlowDirection();
        InitializeComponent();
	}
}