using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

Console.Write("Digite o caminho da foto: ");
string imgPath = Console.ReadLine()!;
Console.WriteLine("");

Console.Write("Digite o caminho onde o pdf será salvo (com o nome do arquivo e o .pdf): ");
string pdfPath = Console.ReadLine()!;
Console.WriteLine("");

try
{
    Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);

                page.Content()
                    .Column(column =>
                    {
                        column
                            .Item()
                            .Image(imgPath, ImageScaling.FitArea);
                    });
            });

            
        })
        .GeneratePdf(pdfPath);
    
    Console.WriteLine($"Arquivo gerado no seguinte caminho: {pdfPath}");
}
catch (Exception e)
{
    Console.WriteLine($"Mensagem de erro: {e.Message}");
}
