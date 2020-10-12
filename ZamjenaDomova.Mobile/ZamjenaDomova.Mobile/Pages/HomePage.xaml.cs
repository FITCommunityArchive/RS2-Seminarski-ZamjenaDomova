using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.Children.Add(new MojDomPage() { Title = "Moj dom" });
            this.Children.Add(new TraziPage() { Title = "Traži" });
            this.Children.Add(new ProfilPage() { Title = "Profil" });
            this.CurrentPage = this.Children[1];
        }
        public HomePage(ListingsModelsSearchRequest request)
        {
            InitializeComponent();
            this.Children.Add(new MojDomPage() {Title= "Moj dom" });
            this.Children.Add(new TraziPage(request) {Title="Traži" });
            this.Children.Add(new ProfilPage() {Title= "Profil" });
            this.CurrentPage = this.Children[1];

        }
    }
}