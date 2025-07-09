using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PdfController : ControllerBase
{
    [HttpPost("generate")]
    public async Task<IActionResult> GeneratePdf([FromBody] PdfRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.HtmlContent) || string.IsNullOrWhiteSpace(request.FileName))
            return BadRequest("HTML content and file name are required.");

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();

        Console.WriteLine("HtmlContent preview:");
        Console.WriteLine(request.HtmlContent);
    

        await page.SetContentAsync(request.HtmlContent, new PageSetContentOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });


        var pdfBytes = await page.PdfAsync(new PagePdfOptions
        {
            Format = "A4",
            PrintBackground = true
        });

        return File(pdfBytes, "application/pdf", $"{request.FileName}.pdf");
    }
}

public class PdfRequest
{
    public string HtmlContent { get; set; }
    public string FileName { get; set; }
}