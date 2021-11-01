using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using CountryAppISO3166.Views;

namespace CountryAppISO3166.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await Application.Current.MainPage.DisplayAlert("Message", "Email and password are required!", "OK");
                return;
            }

            HttpClient client = new HttpClient();

            var jsonData = JsonConvert.SerializeObject(this);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(App.UrlApi + "auth/login", content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<UserManagerResponse>(responseBody);

            if (responseObject.IsSuccess)
            {
                App.accessToken = responseObject.Message;
                Application.Current.MainPage = new NavigationPage(new CountrySearch());
                //Frame.Navigate(typeof(MainPage), responseObject.Message);
            }
            else
            {
                //var dialog = new MessageDialog(responseObject.Message);
                //await dialog.ShowAsync();
            }


        }
    }
}
