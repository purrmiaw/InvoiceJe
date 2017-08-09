using InvoiceJe.Data;
using InvoiceJe.Models;
using InvoiceJe.UWP.Extensions;
using InvoiceJe.UWP.Views;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InvoiceJe.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // To disable ExtendViewIntoTitleBar and others when using Acryllic Accent
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = false;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = null; // by setting this to null, it gets the default value
            titleBar.ButtonInactiveBackgroundColor = null; // by setting this to null, it gets the default value

            // repository
            var repository = new Repository(FileAccessHelper.GetLocalDatabasePath());
            InvoicesListView.ItemsSource = repository.GetInvoices().ToList();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
    AppViewBackButtonVisibility.Collapsed;
            }

        }

        private void InvoicesListView_Click(object sender, ItemClickEventArgs e)
        {
            Invoice invoice = (Invoice)e.ClickedItem;
            Frame.Navigate(typeof(InvoicesEditPage), invoice.Id);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InvoicesCreatePage));
        }
    }
}