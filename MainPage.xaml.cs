using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //webview.Navigate(new Uri("https://haojiezhe12345.top:82/madohomu"));
        }

        private void go(object sender, RoutedEventArgs e)
        {
            try
            {
                webview.Navigate(new UriBuilder(address.Text).Uri);
            } catch { }
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            webview.Refresh();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            if (webview.CanGoBack) webview.GoBack();
        }

        private void forward(object sender, RoutedEventArgs e)
        {
            if (webview.CanGoForward) webview.GoForward();
        }

        private void address_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                go(null, null);
            }
        }

        private void webview_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            refreshBtnSym.Symbol = Symbol.Cancel;
        }

        private void webview_LoadCompleted(object sender, NavigationEventArgs e)
        {
            address.Text = webview.Source.ToString();
            refreshBtnSym.Symbol = Symbol.Refresh;
        }

        private void webview_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            try
            {
                webview.Navigate(args.Uri);
                args.Handled = true;
            } catch { }
        }
    }
}
