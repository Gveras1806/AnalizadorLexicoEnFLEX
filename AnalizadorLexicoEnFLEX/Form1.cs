using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AnalizadorLexicoEnFLEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // trae la funcion analizarLexico desde ddel dll
        [DllImport("lexer.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr analizarLexico(string input);

        // traer la funcion liberar memoria
        [DllImport("lexer.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void liberarMemoria(IntPtr ptr);

        private void button1_Click(object sender, EventArgs e)
        {
            string entrada = anali.Text;
            IntPtr ptrResultado = IntPtr.Zero;

            try
            {
                ptrResultado = analizarLexico(entrada);

                if (ptrResultado == IntPtr.Zero)
                {
                    MessageBox.Show("Error al analizar el texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // copia la memoria y libera
                string resultado = Marshal.PtrToStringAnsi(ptrResultado);
                string resultadoCopia = resultado != null ? string.Copy(resultado) : "Sin resultado";

                salida.Text = resultadoCopia.Replace("\n", Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // libera la memoria en el dll fue lierada
                if (ptrResultado != IntPtr.Zero)
                {
                    try
                    {
                        liberarMemoria(ptrResultado);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al liberar memoria: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void LIMP_Click(object sender, EventArgs e)
        {
            string entrada = anali.Text; // anali = textbx de entrada
            IntPtr ptrResultado = IntPtr.Zero;

            try
            {
                //llama a la funcion del dll
                ptrResultado = analizarLexico(entrada);

                //valida ssi el dll devuel un puntero
                if (ptrResultado == IntPtr.Zero)
                {
                    salida.Text = "Error al analizar el texto.";
                    return;
                }

                //Hacer una copia de la cadena antes de liberar la memoria
                string resultado = Marshal.PtrToStringAnsi(ptrResultado);
                string resultadoCopia = string.Copy(resultado); //  liberar memoria al copiar antes de 

                //Formatear saltos de línea correctamente
                salida.Text = resultadoCopia.Replace("\n", Environment.NewLine);
            }
            finally
            {
                //aseghura que se limpio la memoria correctament en el dll
                if (ptrResultado != IntPtr.Zero)
                    liberarMemoria(ptrResultado);
            }

            //Limpiar los textbox
            anali.Clear();  // entrada
            salida.Clear(); // salida
        }
    }
}

