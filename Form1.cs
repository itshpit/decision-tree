using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТПР_лаб_р_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double bezResult, sprResult, nesprResult;

        private void button1_Click(object sender, EventArgs e)
        {
            double a1BezResult = 0.0, a2BezResult = 0.0 , a3BezResult = 0.0;
            double a1SprResult = 0.0, a2SprResult = 0.0, a3SprResult = 0.0;
            double a1NeSprResult = 0.0, a2NeSprResult = 0.0, a3NeSprResult = 0.0;

            if (str1_spr!=null && str1_nespr != null && str2_spr.Text != null && str2_nespr!= null && str3_spr != null && str3_nespr != null)
            {
                a1BezResult = Int32.Parse(str1_spr.Text) * 0.5 + Int32.Parse(str1_nespr.Text) * 0.5;
                a1_bez.Text = a1BezResult.ToString();
                a2BezResult = Int32.Parse(str2_spr.Text) * 0.5 + Int32.Parse(str2_nespr.Text) * 0.5;
                a2_bez.Text = a2BezResult.ToString();
                a3BezResult = Int32.Parse(str3_spr.Text) * 0.5 + Int32.Parse(str3_nespr.Text) * 0.5;
                a3_bez.Text = a3BezResult.ToString();
                if(spr_spr.Text != null && spr_nespr.Text != null)
                {
                    try
                    {
                        a1SprResult = Int32.Parse(str1_spr.Text) * Convert.ToDouble(spr_spr.Text) + Int32.Parse(str1_nespr.Text) * Convert.ToDouble(spr_nespr.Text);
                        a1_spr.Text = a1SprResult.ToString();
                        a2SprResult = Int32.Parse(str2_spr.Text) * Convert.ToDouble(spr_spr.Text) + Int32.Parse(str2_nespr.Text) * Convert.ToDouble(spr_nespr.Text);
                        a2_spr.Text = a2SprResult.ToString();
                        a3SprResult = Int32.Parse(str3_spr.Text) * Convert.ToDouble(spr_spr.Text) + Int32.Parse(str3_nespr.Text) * Convert.ToDouble(spr_nespr.Text);
                        a3_spr.Text = a3SprResult.ToString();

                        a1NeSprResult = Int32.Parse(str1_spr.Text) * Convert.ToDouble(nespr_spr.Text) + Int32.Parse(str1_nespr.Text) * Convert.ToDouble(nespr_nespr.Text);
                        a1_nespr.Text = a1NeSprResult.ToString();
                        a2NeSprResult = Int32.Parse(str2_spr.Text) * Convert.ToDouble(nespr_spr.Text) + Int32.Parse(str2_nespr.Text) * Convert.ToDouble(nespr_nespr.Text);
                        a2_nespr.Text = a2NeSprResult.ToString();
                        a3NeSprResult = Int32.Parse(str3_spr.Text) * Convert.ToDouble(nespr_spr.Text) + Int32.Parse(str3_nespr.Text) * Convert.ToDouble(nespr_nespr.Text);
                        a3_nespr.Text = a3NeSprResult.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Йой-ой, щось не так з вашими даними...");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Заповніть усі поля секції 1 'Прибуток'!!!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля секції 2 'Прогноз фірми'!!!");
            }

            bezResult = Math.Max(Math.Max(a1BezResult, a2BezResult), a3BezResult);
            sprResult = Math.Max(Math.Max(a1SprResult, a2SprResult), a3SprResult);
            nesprResult = Math.Max(Math.Max(a1NeSprResult, a2NeSprResult), a3NeSprResult);

            MOPspr.Text = sprResult.ToString();
            MOPnespr.Text = nesprResult.ToString();

            pryb_posl.Text = Math.Max(sprResult - Int32.Parse(vart_posl.Text), nesprResult - Int32.Parse(vart_posl.Text)).ToString();
            pryb_bez.Text = bezResult.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bezResult == Math.Max(Math.Max(sprResult - Int32.Parse(vart_posl.Text), nesprResult - Int32.Parse(vart_posl.Text)), bezResult))
            {
                string ans = "Не потрібно проводити додаткові дослідження. Прибуток: " + bezResult.ToString();
                MessageBox.Show(ans, "Висновок");
            }
            else
            {
                string ans = "Варто провести додаткове дослідження. Прибуток: " + Math.Max(sprResult - Int32.Parse(vart_posl.Text), nesprResult - Int32.Parse(vart_posl.Text)).ToString();
                MessageBox.Show(ans, "Висновок");
            }

           
        }
    }
}
