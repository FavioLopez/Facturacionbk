using System;
using System.Collections.Generic;
using System.Text;
using VentasComputadora.Core.Interface;

namespace VentasComputadora.Core.Helpers
{
    public class CodigoControl : ICodigoControl
    {
        public string CifrarMensajeRC4(string mensaje, string llave, bool guion)
        {
            int[] state = new int[256];
            int x = 0;
            int y = 0;
            int index1 = 0;
            int index2 = 0;
            int nmen;
            string MensajeCifrado = "";

            for (int i = 0; i <= 255; i++)
            {
                state[i] = i;
            }

            for (int i = 0; i <= 255; i++)
            {
                index2 = (((int)llave[index1]) + state[i] + index2) % 256;
                int aux = state[i];
                state[i] = state[index2];
                state[index2] = aux;
                index1 = (index1 + 1) % llave.Length;
            }
            for (int i = 0; i < mensaje.Length; i++)
            {
                x = (x + 1) % 256;
                y = (state[x] + y) % 256;
                int aux = state[x];
                state[x] = state[y];
                state[y] = aux;
                nmen = ((int)mensaje[i]) ^ state[(state[x] + state[y]) % 256];
                String nmenHex = nmen.ToString("X").ToUpper();
                MensajeCifrado = MensajeCifrado + ((guion) ? "" : "-") + ((nmenHex.Length == 1) ? ("0" + nmenHex) : nmenHex);
            }

            return (guion) ? MensajeCifrado : MensajeCifrado.Substring(1, MensajeCifrado.Length - 1);
        }

        public string GenerarCodigoControl(string NumAutorizacion, string NumFactura, string NitCi, string FechaTran, string MontoTran, string LlaveDosi)
        {
            try
            {
                LlaveDosi = @"" + LlaveDosi;//reconocer la barra invertida como ascii
                double MontoTranInt = Math.Round(Convert.ToDouble(MontoTran), MidpointRounding.AwayFromZero);
                //Math.Ceiling
                MontoTran = MontoTranInt.ToString();
                //PASO 1 FiveDigitVarVerhoeff

                NumFactura = AddDigitVerhoeff(NumFactura, 2);
                NitCi = AddDigitVerhoeff(NitCi, 2);
                FechaTran = AddDigitVerhoeff(FechaTran, 2);
                MontoTran = AddDigitVerhoeff(MontoTran, 2);


                Int64 suma = Convert.ToInt64(NumFactura) + Convert.ToInt64(NitCi) + Convert.ToInt64(FechaTran) + Convert.ToInt64(MontoTran);

                string FiveDigitVarVerhoeff = AddDigitVerhoeff(suma.ToString(), 5).Substring(suma.ToString().Length, 5);//sacar 5 digitos de verhoeff


                //PASO 2
                int[] vector = new int[FiveDigitVarVerhoeff.Length];//largo de las cadenas 
                string CadenaConcatenada = "";
                string[] valoresCadena = { NumAutorizacion, NumFactura, NitCi, FechaTran, MontoTran };//aumentado las cadenas a cada valor
                int inicial = 0;
                for (int i = 0; i < FiveDigitVarVerhoeff.Length; i++)
                {
                    vector[i] = Convert.ToInt16(FiveDigitVarVerhoeff[i].ToString()) + 1;
                    valoresCadena[i] += LlaveDosi.Substring(inicial, vector[i]);
                    inicial += vector[i];
                    CadenaConcatenada += valoresCadena[i];
                }
                //PASO 3 ALLEGED
                string llaveCifrada = LlaveDosi + FiveDigitVarVerhoeff;
                string AllegedRC4cadena = CifrarMensajeRC4(CadenaConcatenada, llaveCifrada, true);

                //PASO 4 int ST= sumatotal SP=sumaparcialint ST = 0; 
                int ST = 0;
                int SF = 0;
                int[] SP = { 0, 0, 0, 0, 0 };

                for (int i = 0; i < AllegedRC4cadena.Length; i++)
                {
                    ST += AllegedRC4cadena[i];
                    SP[i % 5] += AllegedRC4cadena[i];
                }
                //PASO 5 SF=suma finalint SF = 0;
                for (int i = 0; i < SP.Length; i++)
                {
                    SF += (ST * SP[i]) / vector[i];
                }
                string CadenaBase64 = ObtenerBase64(SF);

                //PASO 6
                string codigoControl = CifrarMensajeRC4(CadenaBase64, LlaveDosi + FiveDigitVarVerhoeff, false);
                return codigoControl;
            }
            catch(Exception e)
            {
                return "Datos invalidos, no se puede generar el codigo de control";
            }
        }

        public string ObtenerBase64(int valor)
        {
            string[] diccionario = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                                "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d",
                                "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
                                "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
                                "y", "z", "+", "/" };
            int cosciente = 1;
            int resto;
            string palabra = "";

            while (cosciente > 0)
            {
                cosciente = valor / 64;
                resto = valor % 64;
                palabra = diccionario[resto] + palabra;
                valor = cosciente;

            }
            return palabra;
        }

        public int ObtenerVerhoeff(string cibra)
        {
            int[,] mult = {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
                { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
                { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
                { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
                { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
                { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
                { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
                { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
                { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
            };

            int[,] per = {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
                { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
                { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
                { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
                { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
                { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
                { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
            };
            int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

            int Check = 0;
            int len = cibra.Length;

            for (int i = 0; i < len; ++i)
                Check = mult[Check, per[((i + 1) % 8), cibra[len - i - 1] - '0']];

            return inv[Check];
        }
        private string AddDigitVerhoeff(string valor, int num)
        {
            for (int i = 0; i < num; i++)
            {
                valor += ObtenerVerhoeff(valor).ToString();
            }
            return valor;
        }
    }
}
