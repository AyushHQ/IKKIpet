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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IKKIpet
{
    public partial class MainWindow : Window
    {
        private readonly SpriteAnimation _animation;

        public MainWindow()
        {
            InitializeComponent();

            _animation = new SpriteAnimation();

            _animation.LoadSpriteSheet(
                "pack://application:,,,/Assets/Cat/cat_atlas.png");

            _animation.FrameChanged += OnFrameChanged;

            var catIdle = new AnimationDefinition
            {
                Frames = new List<Int32Rect>
                {
                    new Int32Rect(303, 2761, 64, 64),
                    new Int32Rect(367, 2761, 64, 64),
                    new Int32Rect(431, 2761, 64, 64),
                    new Int32Rect(495, 2761, 64, 64),
                    new Int32Rect(559, 2761, 64, 64),
                    new Int32Rect(623, 2761, 64, 64),
                    new Int32Rect(687, 2761, 64, 64)

                },
                FramesPerSecond = 7,
                Loop = true
            };

            var catScratch = new AnimationDefinition
            {
                Frames = new List<Int32Rect>
                {
                    new Int32Rect( 296, 1098, 64, 42 ),
                    new Int32Rect( 360, 1098, 64, 42 ),
                    new Int32Rect( 424, 1098, 64, 42 ),
                    new Int32Rect( 488, 1098, 64, 42 ),
                    new Int32Rect( 552, 1098, 64, 42 ),
                    new Int32Rect( 616, 1098, 64, 42 ),
                    new Int32Rect( 680, 1098, 64, 42 ),
                    new Int32Rect( 744, 1098, 64, 42 ),
                    //----------------------------------------
                    new Int32Rect( 296, 1162, 64, 42 ),
                    new Int32Rect( 360, 1162, 64, 42 ),
                    new Int32Rect( 424, 1162, 64, 42 ),
                    new Int32Rect( 488, 1162, 64, 42 ),
                    new Int32Rect( 552, 1162, 64, 42 ),
                    new Int32Rect( 616, 1162, 64, 42 ),
                    new Int32Rect( 680, 1162, 64, 42 ),
                    new Int32Rect( 744, 1162, 64, 42 )
                },
                FramesPerSecond = 16,
                Loop = true
            };

            var catJump = new AnimationDefinition
            {
                Frames = new List<Int32Rect>
                {
                    new Int32Rect(303, 4033, 66, 60),
                    new Int32Rect(367, 4033, 66, 60),
                    new Int32Rect(431, 4033, 66, 60),
                    new Int32Rect(495, 4033, 66, 60),
                    new Int32Rect(559, 4033, 66, 60)
                },
                FramesPerSecond = 7,
                Loop = true
            };

            //var catfortyIdle = new AnimationDefinition
            //{
            //    Frames = new List<Int32Rect>
            //    {
            //        new Int32Rect(12, 62, 138, 138),
            //        new Int32Rect(150, 62, 138, 138),
            //        new Int32Rect(288, 62, 138, 138),
            //        new Int32Rect(426, 62, 138, 138),
            //        new Int32Rect(564, 62, 138, 138),
            //        new Int32Rect(702, 62, 138, 138),
            //        new Int32Rect(840, 62, 138, 138),
            //        new Int32Rect(978, 62, 138, 138),
            //        new Int32Rect(1116, 62, 138, 138),
            //        new Int32Rect(1254, 62, 138, 138),

            //    },
            //    FramesPerSecond = 10,
            //    Loop = true
            //};

            Loaded += (_, _) =>
                _animation.Play(catScratch);

            Closed += (_, _) =>
                _animation.Stop();
        }

        private void OnFrameChanged(
            BitmapSource frame)
        {
            PetImage.Source = frame;
        }
    }
}