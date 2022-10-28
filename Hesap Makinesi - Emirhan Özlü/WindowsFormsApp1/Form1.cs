using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Hesap Makinesi
// Emirhan Özlü
// 200707054

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // program içerisinde public olarak kullanmam gereken bazı değişkenleri tanımladım
        bool islem = false;  
        double sonuc = 0;
        string opt1 = "";
        int sayac ;
        Panel yeni = new Panel(); // bunu birşeyler öğrenmem açısından denemek istedim.
        Label yeniLabel = new Label();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Textbox ın uzunluğunun taşmaması için her büyüdüğünde font sizez ın küçülmesi için internetten de araştırmam sayesinde böyle bir şey yaptım. 
            Font eski = textBox1.Font;
            // textBox1.Enabled = false; bunu textbox a fare ile basılmaması için yapmıştım oluyor ancak rengi solduğundan eklemedim.  

            if (textBox1.Text.Length > 8)
            {
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size - 2, eski.Style);
                
            }

        }

        private void button32_Click(object sender, EventArgs e) // Bu kısmı biraz öğrenmek ve öylesine yaptım.
        {
            // Bu buton panelin açılması için 
            // paneli açtıktan sonra konumunu rengini falan ayarladım.
            Font yeniFont = yeniLabel.Font;

            yeniLabel.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Bold);
            yeniLabel.Top = 50;
            yeniLabel.Left = 70;
            yeniLabel.Width = 200;
            yeniLabel.Height = 90;
            yeniLabel.Location = new Point(12, 50);
            yeniLabel.BackColor = Color.White;

            yeniLabel.Text = "Bu paneli kullanmak için \nekstra DLC paketi \nalmanız gerekmektedir.";

            yeni.Width = 266;
            yeni.Height = 479;
            yeni.Location = new Point(0, 0);
            yeni.BackColor = Color.White;
            button32.BackColor = Color.White;
            button32.FlatAppearance.BorderColor = Color.White;
            yeni.AutoScroll = true;

            // Butona her tıkladığımda panelin açılıp kapanması için bir sayaç tanımladım ve if else ile kodlarını yazdım.
            // bu kısımda kodlar için internetten çok yardım aldım.
            if (sayac % 2 == 0) 
            {
                Controls.Add(yeni);  // Ayarladığım panelin açılması için.
                yeni.BringToFront(); // Panelin diğer buton yada herhangi şeyin altında kalmaması için en öne aldım.
                button32.BringToFront(); // Aynı şekilde paneli açtığım buton içinde geçerli.

                Controls.Add(yeniLabel);
                yeniLabel.BringToFront();
            }
            else
            {
                Controls.Remove(yeni); // Sayaça 2. kez yada 4. kez gibi tıkladığımda kapanması için.
                Controls.Remove(yeniLabel);
                button32.BackColor = System.Drawing.Color.FromArgb(230,230,230); // Paneli açıp kapatırken görsel açıdan iyi olması için buton rengini ayarladım.
                button32.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(230, 230, 230);
            }
            sayac++;


        }
        private void yeni_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void sayilar(object sender, EventArgs e)
        {
            // Windows hesap makinesindeki mantıkla bir operator kullanıldıysa textbox1 i temizle komutu.
            if (textBox1.Text == "0" || islem)
                textBox1.Clear();

            // En fazla 16 rakam girmek şartıyla her karakteri girdiğimde textbox üzerinde toplanıp yan yana yazılması için
            // ve daha sonra bunu Double veya İnteger bir değere çeivrmem için yaptım.
         
            islem = false;
            Button buton = (Button)sender; // bu kod parçasını internet üzerinden öğrendim.
            
            if(textBox1.Text.Length < 16) // Bu kodları çoğu yerde kullandığım için hepsinde açıklamadım textbox a sığmadığında sayıları küçültmek büyültmek için yaptım.
                textBox1.Text += buton.Text;

            // sayıların ve operatörlerin hepsini tek tek yapmadan bir arada aynı kodu çalıştırması için internetten araştırıp click olayıyla hallettim



        }

        private void islemler(object sender, EventArgs e)
        {
            // operator girildiğinde program içinde yapılacak şeyler için yazdığım komutlar.

            islem = true;
            Button buton = (Button)sender;
            string opt = buton.Text;
            Font eski = textBox1.Font;

            // Hesap makinesi üzerinde operator işaretlerinin windows hesap makinesindeki gibi gözükmesi için farklı bir operator stringi oluşturup
            // birini textboxa yazdırmak ve dğierne eşitleyip işlemi yaptırmak için bir kod yazdım. (tam ifade edememiş olabilirim.)
            textBox2.Text = textBox2.Text + " " + textBox1.Text + " " + opt;


            // Bu kısım operatorlere basıldığında textbox üzerinde toplama çıkarma işlemlerinden sonra yazacak sayıyı belirlemek için.
            switch(opt1)
            {
                case "+":textBox1.Text = (sonuc + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-": textBox1.Text = (sonuc - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "×": textBox1.Text = (sonuc * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷": textBox1.Text = (sonuc / Double.Parse(textBox1.Text)).ToString();
                    break;
            }

            // Double.Parse ve Convert.ToDouble galiba aynı işlevi görüyor farkını anlayamadım.

            sonuc = Convert.ToDouble(textBox1.Text);
            textBox1.Text = sonuc.ToString();
            opt1 = opt;

            if (textBox1.Text.Length > 20) // işlemlerden sonra sayı uzunluğunun textbox a sığması için font size ını küçültmek istedim ancak tam oturtamadım.
            {
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size -2, eski.Style);
                textBox1.Text = sonuc.ToString();
            }

            if (textBox1.Font.Size < 22)  // Aynı şekilde font size çok küçüldüğünde eski haline gelmesi için bu if komutunu yazdım.
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 16, eski.Style);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Bu butona basıldığında textboxtan bir sayı silinmesi için internetten bu kod parçasını öğrendim.
            int uzunluk = textBox1.Text.Length;
            textBox1.Text = textBox1.Text.Substring(0,uzunluk-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Bu butona basıldığında textbox1 ve onun kaydını alan textbox2 nin temizlenmesi için kodlar yazdım.
            Font eski = textBox1.Font;

            if (textBox1.Font.Size < 22)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 16, eski.Style);

            textBox1.Text = "0";
            textBox2.Text = "";
            sonuc = 0;
            islem = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bu butona sadece textbox1 in temizlenmesi için kod yazdım (kaydını alan textbox2 de eski işlemlerin yine kalması için).
            Font eski = textBox1.Font;
            if (textBox1.Font.Size < 22)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 16, eski.Style);

            textBox1.Text = "0";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // bu eşittir butonu textbox1 in kaydını tutan yeri temizlemek ve sonucu textbox1 e yazdırmak için yazdığım kodlar.

            textBox2.Text = "";
            islem = true;

            switch (opt1) // işlemlerde kullandığım switch case yapısını burdada kullanmam gerekti biraz internetten araştırdım.
            {
                case "+":
                    textBox1.Text = (sonuc + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (sonuc - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "×":
                    textBox1.Text = (sonuc * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    textBox1.Text = (sonuc / Double.Parse(textBox1.Text)).ToString();
                    break;
            }
            Font eski = textBox1.Font;

            if (textBox1.Font.Size < 20)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 12, eski.Style);

            sonuc = Double.Parse(textBox1.Text);
            textBox1.Text = sonuc.ToString();
            opt1 = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Bu karekök butonu 

            islem = true;
            Button buton = (Button)sender;
            Font eski = textBox1.Font;
            textBox2.Text = textBox2.Text + buton.Text[0] + "(" + textBox1.Text + ")"; // kayıt tutan kısıma karekök sembolünün içinde sayıyı yazdırmak için.
            double say = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Math.Sqrt(say).ToString(); // Math kütüphanesinden sayının karekökükünü aldım.
            say = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Math.Round(say, 8).ToString(); // sayının textbox ta fazla uzun olmaması için virgülden sonra kalan rakamı azalttım.
            
            if (textBox1.Font.Size < 22)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 16, eski.Style);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // Bu buton virgül butonu.
            // Görsel olarak tam ayarlayamadım.
            // işlemler doğru ancak virgülü ilk bastığımda virgül sayının sol tarafına yazılıyor virgülden sonraki sayıyı yazınca asıl yerine oturuyor.
            if(textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else if(islem) // Eğer bir operatore basılmışsa textbox1 i temizlemek için.
            {
                textBox1.Text = "0";
            }

            if (!textBox1.Text.Contains(".") && !textBox1.Text.Contains(",")) // textbox1 de nokta veya virgül yoksa sayının yanına virgül eklemesi için.
            {
                textBox1.Text += ",";
            }

            islem = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // bu kodları klaveyeden basınca istediğim butonların çalışması için yaptım switch case ile.
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    button22.PerformClick();
                    break;
                case Keys.NumPad1:
                    button19.PerformClick();
                    break;
                case Keys.NumPad2:
                    button18.PerformClick();
                    break;
                case Keys.NumPad3:
                    button17.PerformClick();
                    break;
                case Keys.NumPad4:
                    button15.PerformClick();
                    break;
                case Keys.NumPad5:
                    button14.PerformClick();
                    break;
                case Keys.NumPad6:
                    button13.PerformClick();
                    break;
                case Keys.NumPad7:
                    button11.PerformClick();
                    break;
                case Keys.NumPad8:
                    button10.PerformClick();
                    break;
                case Keys.NumPad9:
                    button9.PerformClick();
                    break;
                case Keys.Add:
                    button20.PerformClick();
                    break;
                case Keys.Subtract:
                    button16.PerformClick();
                    break;
                case Keys.Multiply:
                    button12.PerformClick();
                    break;
                case Keys.Divide:
                    button8.PerformClick();
                    break;
                case Keys.Back:
                    button4.PerformClick();
                    break;


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Bu kare alma butonu.

            islem = true;
            Font eski = textBox1.Font;
            textBox2.Text = textBox2.Text + "sqr" + "(" + textBox1.Text + ")"; // Kare alma sembolünü kayıt bölümüne yazmak için. 
            double say = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Math.Pow(say, 2).ToString();  //  Math kütphanesinden sayının karesini aldım.
            say = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Math.Round(say, 8).ToString(); // Sayı virgüllü ise fazla uzun olmaması için virgülden sonraki kısmı kısıtladım.


            if (textBox1.Text.Length > 8)
            {
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size - 12, eski.Style);
 
            }

            if (textBox1.Font.Size < 22)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 13, eski.Style);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Bu 1/x butonu
            islem = true;
            Font eski = textBox1.Font;
            textBox2.Text = textBox2.Text + "1/" + "(" + textBox1.Text + ")"; // Butona basıldığında kayıt kısmına yazılması için.
            double say = Convert.ToDouble(textBox1.Text);
            double a = 1 / say;
            if (textBox1.Text.Length > 10) // Bu kodları çoğu yerde kullandığım için hepsinde açıklamadım textbox a sığmadığında sayıları küçültmek büyültmek için yaptım.
            {
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size - 12, eski.Style);
                textBox1.Text = sonuc.ToString();
            }
            textBox1.Text = a.ToString();
            textBox1.Text = Math.Round(a, 8).ToString(); // Virgülden sonraki kısmı kısıtlmak için math kütüphanesinden round u kullandım.


            if (textBox1.Font.Size < 20)
                textBox1.Font = new Font(eski.FontFamily, textBox1.Font.Size + 12, eski.Style);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Bu buton işaret değiştirme butonu
            double say = Convert.ToDouble(textBox1.Text);
            say = -say;
            textBox1.Text = say.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Bu yüzde alma butonu

            if(islem==true) // Operator kullanıldığında devreye girmesi için if else.
            {
                double say = 0;
                say = sonuc * (sonuc / 100);
                textBox1.Text = say.ToString();


            }
            else // Operator kullanılmadan önce basılmışsa sıfırlamak için.
            {
                textBox2.Text = "0";
                textBox1.Text = "0";
            }
        }

    }
}
