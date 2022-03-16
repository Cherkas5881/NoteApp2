using System.Diagnostics;
using System.Windows.Forms;

namespace NoteAppUI
{
    /// <summary>
    /// Форма AboutForm, содержащая информацию о разработчике
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Загрузка формы AboutForm
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обрабокта события нажатия на ссылку GitHub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start(linkLabel2.Text);
        }

        /// <summary>
        /// Обработка события нажатия на ссылку
        /// на почтовый ящик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto: alicewhite00@mail.ru");
        }
    }
}
