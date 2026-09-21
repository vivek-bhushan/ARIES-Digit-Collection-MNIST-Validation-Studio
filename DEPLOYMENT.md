# 🚀 ARIES Deployment Guide

This guide details all methods for hosting, sharing, and running **ARIES** — whether locally, as a standalone desktop executable, or publicly over the internet.

---

## Table of Contents
1. [Option 1: Deploy to GitHub Pages (Free Cloud Hosting)](#option-1-deploy-to-github-pages-free-cloud-hosting)
2. [Option 2: Expose Locally via Cloudflare Tunnel (Instant Public URL)](#option-2-expose-locally-via-cloudflare-tunnel-instant-public-url)
3. [Option 3: Build Standalone Windows Executable (`ARIES_Studio.exe`)](#option-3-build-standalone-windows-executable-aries_studioexe)
4. [Option 4: Deploy to Vercel / Netlify](#option-4-deploy-to-vercel--netlify)

---

## Option 1: Deploy to GitHub Pages (Free Cloud Hosting)

Because ARIES is a static client-side web application, it can be hosted directly on GitHub Pages with zero server configuration.

### Steps:
1. Push this repository to your GitHub account:
   ```bash
   git remote add origin https://github.com/vivek-bhushan/aries-mnist-studio.git
   git branch -M main
   git push -u origin main
   ```
2. Navigate to your repository on GitHub.
3. Click **Settings** $\to$ **Pages** (in the left sidebar).
4. Under **Build and deployment**:
   - **Source**: Select `Deploy from a branch`.
   - **Branch**: Select `main` and folder `/ (root)`.
   - Click **Save**.
5. Within 1–2 minutes, GitHub will provide a live public URL:  
   `https://vivek-bhushan.github.io/aries-mnist-studio/`

---

## Option 2: Expose Locally via Cloudflare Tunnel (Instant Public URL)

If you are running ARIES locally on your Windows computer and want to make your local session accessible to remote contributors or smartphones without deploying to a cloud host:

### Steps:
1. Download `cloudflared.exe` for Windows 64-bit:
   - [Direct Download link](https://github.com/cloudflare/cloudflared/releases/latest/download/cloudflared-windows-amd64.exe)
2. Place `cloudflared.exe` into your project directory.
3. Ensure your local server is running:
   ```powershell
   python -m http.server 8088
   ```
4. Open another terminal in the project directory and run:
   ```powershell
   .\cloudflared.exe tunnel --url http://localhost:8088
   ```
5. Cloudflare will output an active public HTTPS address:
   ```text
   +--------------------------------------------------------------------------------------------+
   |  Your quick Tunnel has been created! Visit it at (it may take some time to be reachable):  |
   |  https://example-random-words.trycloudflare.com                                            |
   +--------------------------------------------------------------------------------------------+
   ```
6. Anyone with this link can open the ARIES login gateway, draw digits, and have their contributions stored locally in your workspace!

---

## Option 3: Build Standalone Windows Executable (`ARIES_Studio.exe`)

You can compile a native desktop launcher for Windows using the included `Launcher.cs` source:

### Prerequisites:
Windows includes the Microsoft C# compiler by default. No Visual Studio installation is required.

### Compilation Command:
Open Command Prompt or PowerShell as Administrator and run:
```powershell
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /out:"ARIES_Studio.exe" /target:winexe "Launcher.cs"
```

### Output:
* Generates `ARIES_Studio.exe` in the root folder.
* Double-clicking `ARIES_Studio.exe` launches the background HTTP daemon (if not already running) and opens the default web browser directly to the ARIES login page.

---

## Option 4: Deploy to Vercel / Netlify

### Using Vercel CLI:
```bash
npm install -g vercel
vercel
```

### Using Netlify CLI:
```bash
npm install -g netlify-cli
netlify deploy --prod --dir=.
```

---

## 🔒 Security Best Practices for Public Hosting

1. **Admin Credentials**: The admin credentials (`admin / Muzaffarpur`) are verified client-side. If hosting on a public domain, ensure administrative surveillance is conducted through secure channels.
2. **Local Storage**: Contributor practice samples and surveillance logs are stored in the client's browser `localStorage`. When contributors complete their 10-digit sets, their personal CSV is automatically downloaded directly to their machine.
3. **Master CSV**: The consolidated master CSV combines all local practices with the 200 authentic MNIST validation samples and can be exported exclusively by Vivek Bhushan via the Tab 6 Admin Vault.
