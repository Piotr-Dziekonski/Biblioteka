using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TypImprezy
/// </summary>
public class Kategoria
{
    public Kategoria()
    {

    }

    private string _nazwaKategorii;
    private int _idKategorii;

    public int IdKategorii
    {
        get { return _idKategorii; }
        set { _idKategorii = value; }
    }

    public string NazwaKategorii
    {
        get { return _nazwaKategorii; }
        set { _nazwaKategorii = value; }
    }


    public string Rok { get; set; }
}