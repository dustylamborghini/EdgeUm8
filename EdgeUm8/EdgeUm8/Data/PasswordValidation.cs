using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace EdgeUm8.Data
{
    public class PasswordValidation : Behavior<Entry>
    {
        //a regular expression for password validation, demanding the user to enter at least 8 characters,
        //of which at least one has to be a special, a numerical, an upper-, and a lowercase character.
        const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";

        //override for inherited method in order to apply handler which utilizes the regex.
        protected override void OnAttachedTo(Entry bindable) {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }
        
        //event handler
        void HandleTextChanged(object sender, TextChangedEventArgs e) {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
               
        public static bool ValidatePassword(string pwd) {
            return (Regex.IsMatch(pwd, passwordRegex));
        }
        
        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}

