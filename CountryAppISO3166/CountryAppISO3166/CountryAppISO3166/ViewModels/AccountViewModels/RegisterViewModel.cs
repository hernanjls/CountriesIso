using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CountryAppISO3166.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidPasswordPrompt;
        public Action DisplayInvalidEmailPasswordPrompt;
        

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

        private string confirmPassword;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public RegisterViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            if (string.IsNullOrEmpty(email)  || string.IsNullOrEmpty(password))
            {
                await Application.Current.MainPage.DisplayAlert("Message", "Email and password are required!", "OK");
                return;
            }

            if (Password.Equals(ConfirmPassword) != true)
            {
                await Application.Current.MainPage.DisplayAlert("Message", "Password and Confirm Password must be the same", "OK");
                return;
            }

            HttpClient client = new HttpClient();

            var jsonData = JsonConvert.SerializeObject(this);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(App.UrlApi + "auth/register", content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<UserManagerResponse>(responseBody);

            if (responseObject.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Your account has been created successfully!", "OK");
                await App.Current.MainPage.Navigation.PopModalAsync();
                //await dialog.ShowAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", responseObject.Errors.FirstOrDefault(), "OK");
                //await dialog.ShowAsync();
            }



        }
    }
}
