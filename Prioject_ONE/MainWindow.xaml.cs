using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prioject_ONE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            ListView_Oicolorlist = new ObservableCollection<Oicolor>();

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            // == CompositionTarget.Rendering += CompositionTarget_Rendering
        }

        private SolidColorBrush m_Mouse_Value_Color;
        public SolidColorBrush Mouse_Value_Color
        {
            get { return m_Mouse_Value_Color; }
            set
            {
                if (m_Mouse_Value_Color != value)
                {
                    m_Mouse_Value_Color = value;
                    Notify("Mouse_Value_Color");
                }
            }
        }

        private BitmapImage m_Mouse_Value_imagesource;
        public BitmapImage Mouse_Value_imagesource
        {
            get { return m_Mouse_Value_imagesource; }
            set
            {
                if (m_Mouse_Value_imagesource != value)
                {
                    m_Mouse_Value_imagesource = value;
                    Notify("Mouse_Value_imagesource");
                }
            }
        }

        private int m_Mouse_ValueX;
        public int Mouse_ValueX
        {
            get { return m_Mouse_ValueX; }
            set
            {
                if (m_Mouse_ValueX != value)
                {
                    m_Mouse_ValueX = value;
                    Notify("Mouse_ValueX");
                }
            }
        }

        private int m_Mouse_ValueY;
        public int Mouse_ValueY
        {
            get { return m_Mouse_ValueY; }
            set
            {
                if (m_Mouse_ValueY != value)
                {
                    m_Mouse_ValueY = value;
                    Notify("Mouse_ValueY");
                }
            }
        }

        private string m_HEXValue;
        public string HEXValue
        {
            get { return m_HEXValue; }
            set
            {
                if (m_HEXValue != value)
                {
                    m_HEXValue = value;
                    Notify("HEXValue");
                }
            }
        }

        private int m_RGB_Value_R;
        public int RGB_Value_R
        {
            get { return m_RGB_Value_R; }
            set
            {
                if (m_RGB_Value_R != value)
                {
                    m_RGB_Value_R = value;
                    Notify("RGB_Value_R");
                }
            }
        }

        private int m_RGB_Value_G;
        public int RGB_Value_G
        {
            get { return m_RGB_Value_G; }
            set
            {
                if (m_RGB_Value_G != value)
                {
                    m_RGB_Value_G = value;
                    Notify("RGB_Value_G");
                }
            }
        }

        private int m_RGB_Value_B;
        public int RGB_Value_B
        {
            get { return m_RGB_Value_B; }
            set
            {
                if (m_RGB_Value_B != value)
                {
                    m_RGB_Value_B = value;
                    Notify("RGB_Value_B");
                }
            }
        }

        #region RGBtoHEX_R,G,B
        private int m_RGBtoHEX_R;
        public int RGBtoHEX_R
        {
            get { return m_RGBtoHEX_R; }
            set
            {
                if (m_RGBtoHEX_R != value)
                {
                    m_RGBtoHEX_R = value;
                    Notify("RGBtoHEX_R");
                }
            }
        }

        private int m_RGBtoHEX_G;
        public int RGBtoHEX_G
        {
            get { return m_RGBtoHEX_G; }
            set
            {
                if (m_RGBtoHEX_G != value)
                {
                    m_RGBtoHEX_G = value;
                    Notify("RGBtoHEX_G");
                }
            }
        }

        private int m_RGBtoHEX_B;
        public int RGBtoHEX_B
        {
            get { return m_RGBtoHEX_B; }
            set
            {
                if (m_RGBtoHEX_B != value)
                {
                    m_RGBtoHEX_B = value;
                    Notify("RGBtoHEX_B");
                }
            }
        }
        #endregion

        #region RGBtoHEX_Button
        private Command m_RGBtoHEX_Button;
        public ICommand RGBtoHEX_Button
        {
            get { return m_RGBtoHEX_Button = new Command(RGBtoHEX_Button_Event); }
        }
        private void RGBtoHEX_Button_Event(object obj)
        {
            RGBtoHEX_Hex = string.Format("{0:X2}{1:X2}{2:X2}", RGBtoHEX_R, RGBtoHEX_G, RGBtoHEX_B);
        }
        #endregion

        private string m_RGBtoHEX_Hex;
        public string RGBtoHEX_Hex
        {
            get { return m_RGBtoHEX_Hex; }
            set
            {
                if (m_RGBtoHEX_Hex != value)
                {
                    m_RGBtoHEX_Hex = value;
                    try
                    {
                        RGBtoHEX_Color = (SolidColorBrush)new BrushConverter().ConvertFrom("#"+ RGBtoHEX_Hex);
                    }
                    catch(Exception)
                    {

                    }
                    Notify("RGBtoHEX_Hex");

                }
            }
        }

        private SolidColorBrush m_RGBtoHEX_Color;
        public SolidColorBrush RGBtoHEX_Color
        {
            get { return m_RGBtoHEX_Color; }
            set
            {
                if (m_RGBtoHEX_Color != value)
                {
                    m_RGBtoHEX_Color = value;
                    Notify("RGBtoHEX_Color");
                }
            }
        }

        private string m_HEXtoRGB_Hex;
        public string HEXtoRGB_Hex
        {
            get { return m_HEXtoRGB_Hex; }
            set
            {
                if (m_HEXtoRGB_Hex != value)
                {
                    m_HEXtoRGB_Hex = value;
                    Notify("HEXtoRGB_Hex");

                }
            }
        }

        #region HEXtoRGB_Button
        private Command m_HEXtoRGB_Button;
        public ICommand HEXtoRGB_Button
        {
            get { return m_HEXtoRGB_Button = new Command(HEXtoRGB_Button_Event); }
        }
        private void HEXtoRGB_Button_Event(object obj)
        {
            try
            {
                if(HEXtoRGB_Hex.Length == 2) //길이가 2개 일때 HEXtoRGB_R만 변경하기
                {
                    HEXtoRGB_R = Convert.ToByte(HEXtoRGB_Hex.Substring(0, 2), 16);
                }
                else if(HEXtoRGB_Hex.Length == 4) //길이가 4개 일때 HEXtoRGB_R,HEXtoRGB_G만 변경하기
                {
                    HEXtoRGB_R = Convert.ToByte(HEXtoRGB_Hex.Substring(0, 2), 16);
                    HEXtoRGB_G = Convert.ToByte(HEXtoRGB_Hex.Substring(2, 2), 16);
                }
                else if(HEXtoRGB_Hex.Length == 6) //길이가 6개 일때 HEXtoRGB_R,HEXtoRGB_G,HEXtoRGB_B 변경하기
                {
                    HEXtoRGB_R = Convert.ToByte(HEXtoRGB_Hex.Substring(0, 2), 16);
                    HEXtoRGB_G = Convert.ToByte(HEXtoRGB_Hex.Substring(2, 2), 16);
                    HEXtoRGB_B = Convert.ToByte(HEXtoRGB_Hex.Substring(4, 2), 16);
                }

                HEXtoRGB_Color = new SolidColorBrush(Color.FromRgb((byte)HEXtoRGB_R, (byte)HEXtoRGB_G, (byte)HEXtoRGB_B));
            }
            catch(Exception ex)
            {

            }

        }
        #endregion

        #region HEXtoRGB_R,G,B
        private int m_HEXtoRGB_R;
        public int HEXtoRGB_R
        {
            get { return m_HEXtoRGB_R; }
            set
            {
                if (m_HEXtoRGB_R != value)
                {
                    m_HEXtoRGB_R = value;
                    Notify("HEXtoRGB_R");
                }
            }
        }

        private int m_HEXtoRGB_G;
        public int HEXtoRGB_G
        {
            get { return m_HEXtoRGB_G; }
            set
            {
                if (m_HEXtoRGB_G != value)
                {
                    m_HEXtoRGB_G = value;
                    Notify("HEXtoRGB_G");
                }
            }
        }

        private int m_HEXtoRGB_B;
        public int HEXtoRGB_B
        {
            get { return m_HEXtoRGB_B; }
            set
            {
                if (m_HEXtoRGB_B != value)
                {
                    m_HEXtoRGB_B = value;
                    Notify("HEXtoRGB_B");
                }
            }
        }
        #endregion

        private SolidColorBrush m_HEXtoRGB_Color;
        public SolidColorBrush HEXtoRGB_Color
        {
            get { return m_HEXtoRGB_Color; }
            set
            {
                if (m_HEXtoRGB_Color != value)
                {
                    m_HEXtoRGB_Color = value;
                    Notify("HEXtoRGB_Color");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        private ObservableCollection<Oicolor> m_ListView_Oicolorlist;
        public ObservableCollection<Oicolor> ListView_Oicolorlist
        {
            get { return m_ListView_Oicolorlist; }
            set
            {
                if (m_ListView_Oicolorlist != value)
                {
                    m_ListView_Oicolorlist = value;
                    Notify("ListView_Oicolorlist");
                }
            }
        }

        #region Mouse Hooking
        bool enableMouseHooking = false;
        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            DoInputKey();

            if (enableMouseHooking == true)
            {
                DoMouse();
            }
        }

        void DoMouse()
        {
            Mouse.Capture(this); // 어플리케이션 바깥으로 마우스가 나갔을 경우에서도 마우스 이벤트와 관련된 이벤트들을 작동시킴(true)
            Point pointToWindow = Mouse.GetPosition(this); // 어플리케이션 내의 마우스 상대 위치
            Point pointToScreen = PointToScreen(pointToWindow); // 화면 내의 마우스 절대 위치

            #region Debug_pointToWindow,pointToScreen
            Debug.WriteLine("pointToWindow.X : " + pointToWindow.X.ToString() + " / " + "pointToWindow.Y : " + pointToWindow.Y.ToString());
            Debug.WriteLine("pointToScreen.X :" + pointToScreen.X.ToString() + " / " + "pointToScreen.Y :" + pointToScreen.Y.ToString());
            #endregion

            Mouse_ValueX = (int)pointToScreen.X;
            Mouse_ValueY = (int)pointToScreen.Y;

            System.Drawing.Bitmap bitmap = GetSreenshot((int)pointToScreen.X, (int)pointToScreen.Y);
            System.Drawing.Color getColor = bitmap.GetPixel(18, 18); // 해당 Bitmap의 지정된 픽셀의 색을 가져옵니다.
            Mouse_Value_Color = new SolidColorBrush(Color.FromRgb(getColor.R, getColor.G, getColor.B));

            HEXValue = Mouse_Value_Color.ToString().Substring(2,6);
            RGB_Value_R = getColor.R;
            RGB_Value_G = getColor.G;
            RGB_Value_B = getColor.B;

            Mouse_Value_imagesource = Convert_(bitmap); // Bitmap > MemoryStream > BitmapImage

            Mouse.Capture(null); // 마우스 캡쳐 해지
        }

        void DoInputKey()
        {
            string input = GetInputKey();

            if (input != "")
            {
            }

            if (input == "F2")
            {
                enableMouseHooking = true;
            }
            else if (input == "F3")
            {
                enableMouseHooking = false;
            }
        }

        string GetInputKey()
        {
            string input = "";

            foreach (int value in Enum.GetValues(typeof(Key)))
            {
                Key k = (Key)value;
                if ((k == Key.None) || (k == Key.KanaMode) || (k == Key.OemAttn)) continue; // 3가지 키 제외
                if ((Keyboard.GetKeyStates(k) & KeyStates.Down) > 0) // Keyboard.GetKeyStates(k) : 키를 누르면 Down = 0x1, Toggled = Ox2 반환, KeyStates.Down은 GetKeyStates가 눌러 졌는지 확인 하기 위해 이용
                {
                    input = k.ToString();
                    break;
                }
            }

            return input;
        }

        private System.Drawing.Bitmap GetSreenshot(int width, int height)
        {
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(36, 36); // 지정된 크기만큼의 Bitmap 생성, 생성되는 화면 크기
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm); // Bitmap 이미지 변경을 위해 Graphics 객체 생성
            g.CopyFromScreen(width-18, height-18, 0, 0, bm.Size); // 화면을 그대로 카피해서 Bitmap 메모리에 저장, 화면 이동
            return bm;
        }

        // Bitmap > MemoryStream > BitmapImage
        public BitmapImage Convert_(System.Drawing.Bitmap src)
        {
            MemoryStream ms = new MemoryStream(); //Bitmap 담을 메모리스트림 초기화
            src.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            // BitmapImage 로 변환
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
        #endregion

        private void ColorListAddKey(object sender, KeyEventArgs e)
        {
            if(enableMouseHooking)
            {
                if(e.Key == Key.A)
                {
                    try
                    {
                        ListView_Oicolorlist.Add(new Oicolor() { ListView_HEX = HEXValue, ListView_RGB = RGB_Value_R.ToString() + " " + RGB_Value_G.ToString() + " " + RGB_Value_B.ToString() });
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
    }
}
