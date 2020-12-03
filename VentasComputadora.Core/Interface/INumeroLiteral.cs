using System;
using System.Collections.Generic;
using System.Text;

namespace VentasComputadora.Core.Interface
{
    public interface INumeroLiteral
    {
        string Convertir(string num, bool mayusculas);
        string getUnidades(string num);
        string getDecenas(string num);
        string getCentenas(string num);
        string getMiles(string num);
        string getMillones(String num);
    }
}
