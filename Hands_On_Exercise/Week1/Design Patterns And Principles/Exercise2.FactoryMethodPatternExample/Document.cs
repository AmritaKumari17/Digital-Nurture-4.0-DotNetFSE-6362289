// Documents.cs
using System;

public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Word Document");
    }
}

public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF Document");
    }
}

public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Excel Document");
    }
}
