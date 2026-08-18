using IKKIpet.Models;
using IKKIpet.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;
using IKKIpet.Models;
using IKKIpet.Services;

namespace IKKIpet
{
    public partial class MainWindow : Window
    {
        private readonly CharachterController _charachter;

        public MainWindow()
        {
            InitializeComponent();

            _charachter =
                new CharachterController(PetImage);

            _charachter.SetCharacter(
                CharachterId.WindWarrior);

            _charachter.Play(
                AnimationId.Idle); 

            Closed += OnWindowClosed;
        }

        private void OnWindowClosed(
            object? sender,
            System.EventArgs e)
        {
            _charachter.Stop();
        }

        private void WarriorImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _charachter.Attack();
        }
    }
}