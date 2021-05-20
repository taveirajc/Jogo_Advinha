using System;
using System.Windows.Forms;

namespace Advinha_numero
{
    public partial class Form1 : Form
    {
        int minimo = 0; // variável que guarda o valor mínimo do número a ser gerado pelo computador
        int maximo = 100; // variável que guarda o valor máximo do número a ser gerado pelo computador
        int tentativas = 0; // número de tentativas até acertar o número
        int numero = 0; // guarda o número aleatório gerado pelo computador

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false; // desativa o textbox onde o usuário digita o número
        }

        private void btn_jogar_Click(object sender, EventArgs e)
        {            
            minimo = 0;  // numero mínimo para a geração
            tentativas = 0; // contador de tentativas
            Random rnd = new Random();
            numero = rnd.Next(minimo, maximo); // guarda em numero o valor gerado entre 1 e 100
            label2.Text = ""; // limpa o label de informações
            label3.Text = "Jogo iniciado." + Environment.NewLine +
                "Digite um número entre " + Environment.NewLine +
                string.Format("{0} e {1}", minimo, maximo) + " e aperte Enter.";
            textBox1.Enabled = true; // torna visível o textbox para digitar o numero
            textBox1.Text = String.Empty;
            textBox1.Select();  // coloca o foco no textbox1
            btn_jogar.Visible = false;

        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && textBox1.Text != "")
            {
                // transformação do texto em valor inteiro e colocando na variável valor
                int.TryParse(textBox1.Text, out int valor);
                if (valor < numero)  // se o valor digitado for menor que o numero gerado....
                {
                    label3.Text = "O número digitado é menor.";
                    tentativas++;
                    label2.Text = "Tentativas: " + tentativas.ToString();
                }
                else
                if (valor > numero)  // se o valor digitado for maior que o numero gerado....
                {
                    label3.Text = "O número digitado é maior.";
                    tentativas++;
                    label2.Text = "Tentativas: " + tentativas.ToString();
                }
                else
                {
                    tentativas++;
                    label2.Text = "Tentativas: " + tentativas.ToString();
                    label3.Text = "Você acertou" + Environment.NewLine +
                             " em " + tentativas + Environment.NewLine +
                            "tentativas.";
                    textBox1.Enabled = false;
                    btn_jogar.Visible = true;
                }
            }
        }
    }
}
