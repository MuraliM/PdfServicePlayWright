# 📄 Generic HTML-to-PDF Generation Service

This is a generic, ASP.NET Core Web API that converts HTML content into high-quality PDF documents using [Microsoft.Playwright](https://playwright.dev/dotnet/).

Built to support:
- Full HTML5 and CSS3 rendering
- Headless browser rendering with Chromium
- Easy integration via HTTP POST

---

## 🚀 Features

- ✅ Convert raw HTML to PDF
- ✅ Specify file name via API
- ✅ CSS and JavaScript supported (via headless Chromium)
- ✅ Based on free and open-source [Microsoft.Playwright for .NET](https://playwright.dev/dotnet/)

---

## 🛠 Requirements

- .NET 6 or later
- PowerShell (for Playwright browser install)
- Windows / Linux / macOS (cross-platform)

---

## 📦 Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/muralim/pdf-generator-service.git
cd pdf-generator-service
```

### 2. Install Playwright browser binaries (required once)
```powershell -ExecutionPolicy Bypass -File bin/Debug/net6.0/playwright.ps1 install```

Currently, In csproj, the installation happened when you build.
https://github.com/MuraliM/PdfServicePlayWright/blob/5555d803f6c7a0ae650d3c40214bec2568dc4055/PdfService/PdfService.csproj#L13

```
	<Target Name="PlaywrightInstall" AfterTargets="Build">
		<Exec Command="powershell -ExecutionPolicy Bypass -File bin\Debug\net8.0\playwright.ps1 install" />
	</Target>
```

## 📥 API Usage

### `POST /api/pdf/generate`

Converts raw HTML into a downloadable PDF file.

---

### ✅ Request

- **Method**: `POST`
- **URL**: `/api/pdf/generate`
- **Content-Type**: `application/json`

#### 📦 Sample JSON Body

```json
{
  "htmlContent": "<!DOCTYPE html><html><body><h1>Hello PDF!</h1></body></html>",
  "fileName": "sample-invoice"
}
```
Or Copy paste the sample file content from https://github.com/MuraliM/PdfServicePlayWright/blob/5555d803f6c7a0ae650d3c40214bec2568dc4055/PdfService/samplehtml.json#L1

