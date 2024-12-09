using System.Media;
using University_Dasboard.Properties;

namespace University_Dasboard
{
    internal class PasswordVisibility
    {
        private static Image shownPasswordIcon = Resources.ShownPassword.ToBitmap();
        private static Image hiddenPasswordIcon = Resources.HiddenPassword.ToBitmap();
        private const char passwordChar = '*';
        private const char nonePasswordChar = '\0';

        public static void changeVisibility(Button button, TextBox textBox)
        {
            if (textBox.PasswordChar != nonePasswordChar)
            {
                button.Image = shownPasswordIcon;
                textBox.PasswordChar = nonePasswordChar;
            }
            else
            {
                button.Image = hiddenPasswordIcon;
                textBox.PasswordChar = passwordChar;
            }
        }
    }
}
