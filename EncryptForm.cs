using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class EncryptForm : Form
    {
        int errCnt = 0;
        DESCryptoServiceProvider DESCSP;  // объект класса алгоритма шифрования DES
        byte[] IV;
        PasswordDeriveBytes pdb;     // объект для генерации ключа из парольной фразы
        byte[] randBytes;
        FileStream finStream, foutStream;
        CryptoStream CrStream;
        byte[] bytes;
        int numBytesToRead;
        ArgumentException ex;
        public EncryptForm()
        {
            InitializeComponent();
            DESCSP = new DESCryptoServiceProvider(); //объект для криптоалгоритма
            IV = DESCSP.IV;
            DESCSP.Mode = CipherMode.CBC;  // определение режима шифрования
            KeySizes[] ks = DESCSP.LegalKeySizes;

        }



        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (PassFrase1.Text == PassFrase2.Text)
                {

                    if (PassFrase1.Text.Length < 8)
                        throw ex = new ArgumentException("Парольная фраза короче требуемой длины.");
                    string OutputFName = "";

                    byte[] pwd = Encoding.Unicode.GetBytes(PassFrase1.Text);
                    pdb = new PasswordDeriveBytes(pwd, randBytes);
                    DESCSP.Key = pdb.CryptDeriveKey("DES", "MD5", (int)64, IV);  // генерация ключа 
                    ICryptoTransform encryptor = DESCSP.CreateEncryptor(DESCSP.Key, IV);    // создание объекта шифрования
                    OutputFName = "Info.txt.enc";
                    finStream = new FileStream("Info.txt", FileMode.Open);
                    foutStream = new FileStream(OutputFName, FileMode.Create);
                    CrStream = new CryptoStream(foutStream, encryptor, CryptoStreamMode.Write);
                    bytes = new byte[finStream.Length];
                    numBytesToRead = (int)finStream.Length;
                    int n = finStream.Read(bytes, 0, numBytesToRead);
                    numBytesToRead = n;
                    CrStream.Write(bytes, 0, numBytesToRead);
                    DESCSP.Clear();
                    CrStream.Close();
                    finStream.Close();
                    foutStream.Close();
                    File.Delete("Info.txt");
                    MessageBox.Show(" Файл зашифрован! ");
                    Encrypt.Enabled = false;
                    Open.Enabled = false;
                    Decrypt.Enabled = true;
                    PassFrase1.Text = "";
                    PassFrase2.Text = "";
                }

                else MessageBox.Show("Парольные фразы не совпадают");


            }
            catch (CryptographicException ex)
            {
                // вывод сообщения об ошибке
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // закрытие файлов
                finStream.Close();
                foutStream.Close();
                errCnt++;
                if (errCnt >= 3)
                {
                    MessageBox.Show("Превышен лимит ошибок");
                    Close();
                }
            }
            // обработка остальных ошибок
            catch (Exception ex)
            {
                // вывод сообщения об ошибке
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void Decrypt_Click(object sender, EventArgs e)
        {

            try
            {
                if (PassFrase1.Text == PassFrase2.Text)
                {
                    finStream = new FileStream("Info.txt.enc", FileMode.Open);
                    byte[] pwd = Encoding.Unicode.GetBytes(PassFrase1.Text);
                    pdb = new PasswordDeriveBytes(pwd, randBytes);
                    DESCSP.Clear();
                    DESCSP.Key = pdb.CryptDeriveKey("DES", "MD5", (int)64, IV);
                    ICryptoTransform decryptor = DESCSP.CreateDecryptor(DESCSP.Key, IV);
                    foutStream = new FileStream("Info.txt", FileMode.Create);
                    CrStream = new CryptoStream(finStream, decryptor, CryptoStreamMode.Read);
                    bytes = new byte[finStream.Length];
                    numBytesToRead = (int)(finStream.Length);
                    int n = CrStream.Read(bytes, 0, numBytesToRead);
                    numBytesToRead = n;
                    foutStream.Write(bytes, 0, numBytesToRead);
                    DESCSP.Clear();
                    CrStream.Close();
                    finStream.Close();
                    foutStream.Close();
                    File.Delete("Info.txt.enc");

                    StartForm f1 = new StartForm();
                    f1.ShowDialog();
                    label2.Text = PassFrase1.Text;
                    Open.Enabled = true;
                    Encrypt.Enabled = true;

                    Decrypt.Enabled = false;
                    PassFrase1.Text = "";
                    PassFrase2.Text = "";
                }
                else MessageBox.Show("Парольные фразы не совпадают");
            }
            // обработка ошибки криптографической операции
            catch (CryptographicException ex)
            {
               
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);           
                finStream.Close();
                foutStream.Close();
                File.Delete("Info.txt");
                errCnt++;
                if (errCnt >= 3)
                {
                    MessageBox.Show("Превышен лимит ошибок");
                    Close();
                }
            }
            // обработка остальных ошибок
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete("Info.txt");

            }
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            if ((!(File.Exists("Info.txt"))) && (!(File.Exists("Info.txt.enc"))))
            {
                FileStream file = new FileStream("Info.txt", FileMode.Create);
                StreamWriter fnew = new StreamWriter(file);
                fnew.WriteLine("admin" + ' ' + "" + ' ' + "0" + ' ' + "0");
                fnew.Close();
            }

        }

        private void PassFrase1_TextChanged(object sender, EventArgs e)
        {

            if (File.Exists("Info.txt"))
            {
                Encrypt.Enabled = true;
                Decrypt.Enabled = false;

            };
            if (File.Exists("Info.txt.enc"))
            {
                Decrypt.Enabled = true;
                Encrypt.Enabled = false;
            };
        }

        private void EncryptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
 
            
            
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (File.Exists("Info.txt"))
            {
                StartForm f1 = new StartForm();
                f1.ShowDialog();
            }
        }

        private void EncryptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("Info.txt"))
            {
                if ((PassFrase1.Text == "") || (PassFrase2.Text == ""))
                {
                    MessageBox.Show(" Введите парольную фразу! ");
                    e.Cancel = true;
                    errCnt++;
                    if (errCnt >= 3)
                    {
                        MessageBox.Show("Превышен лимит ошибок");
                        File.Delete("Info.txt");
                        Close();
                    }
                }
                else
                {
                    if (PassFrase1.Text == PassFrase2.Text)
                    {
                        if (PassFrase1.Text.Length < 8)
                        {
                            MessageBox.Show(" Парольная фраза короче требуемой длины! ");
                            e.Cancel = true;
                            errCnt++;
                            if (errCnt >= 3)
                            {
                                MessageBox.Show("Превышен лимит ошибок");
                                File.Delete("Info.txt");
                                Close();
                            }
                        }

                        else
                        {
                            // создание объекта для генерации случайной примеси
                            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
                            string OutputFName = "";

                            // декодирование парольной фразы
                            byte[] pwd = Encoding.Unicode.GetBytes(PassFrase1.Text);
                            // создание объекта для генерации ключа из парольной фразы
                            pdb = new PasswordDeriveBytes(pwd, randBytes);
                            // генерация ключа 
                            DESCSP.Key = pdb.CryptDeriveKey("DES", "MD5", (int)64, IV);
                            // создание объекта шифрования
                            ICryptoTransform encryptor = DESCSP.CreateEncryptor(DESCSP.Key, IV);
                            /* отображение имени зашифрованного файла (к имени исходного файла добавляется расширение .enc) */
                            OutputFName = "Info.txt.enc";
                            // создание объектов для файловых потоков 
                            finStream = new FileStream("Info.txt", FileMode.Open);
                            foutStream = new FileStream(OutputFName, FileMode.Create);
                            // создание объекта для потока шифрования
                            CrStream = new CryptoStream(foutStream, encryptor, CryptoStreamMode.Write);
                            // выделение памяти для буфера ввода-вывода
                            bytes = new byte[finStream.Length];
                            // задание количества непрочитанных байт
                            numBytesToRead = (int)finStream.Length;
                            // ввод данных из исходного файла
                            int n = finStream.Read(bytes, 0, numBytesToRead);
                            // сохранение фактического количества прочитанных байт
                            numBytesToRead = n;
                            // запись в зашифрованный файл
                            CrStream.Write(bytes, 0, numBytesToRead);
                            // очистка памяти с конфиденциальными данными
                            DESCSP.Clear();
                            // закрытие потока шифрования
                            CrStream.Close();
                            // закрытие файлов
                            finStream.Close();
                            foutStream.Close();
                            File.Delete("Info.txt");
                            MessageBox.Show(" Файл зашифрован! ");
                            Encrypt.Enabled = false;
                            Decrypt.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Парольные фразы не совпадают");
                        e.Cancel = true;
                        errCnt++;
                        if (errCnt >= 3)
                        {
                            MessageBox.Show("Превышен лимит ошибок");
                            File.Delete("Info.txt");
                            Close();
                        }
                    }
                }
                    
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
