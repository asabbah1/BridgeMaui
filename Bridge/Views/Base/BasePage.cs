namespace Bridge.Views
{
    public class BasePage : ContentPage
    {
        public IViewModel ViewModel => (IViewModel)BindingContext;
        public BasePage()
        {
            this.FlowDirection = Common.GetFlowDirection();
        }

        protected async override void OnAppearing()
        {
            await ViewModel.Initialize();
            base.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            await ViewModel.Stop();
            base.OnDisappearing();
        }
    }
}
