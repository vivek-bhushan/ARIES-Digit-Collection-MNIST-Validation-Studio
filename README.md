# ♈ ARIES — Handwritten Digit Collection & In-Browser Neural Network Studio

<div align="center">

![ARIES Version](https://img.shields.io/badge/version-2.4.0-blue.svg?style=for-the-badge&color=00f2fe)
![License](https://img.shields.io/badge/license-MIT-green.svg?style=for-the-badge&color=00e676)
![Vanilla JS](https://img.shields.io/badge/stack-Vanilla_JS_%7C_Canvas_%7C_CSS3-orange.svg?style=for-the-badge&color=ff758c)
![Client Side](https://img.shields.io/badge/engine-100%25_In--Browser_Neural_Backprop-purple.svg?style=for-the-badge&color=9d4edd)
[![Author](https://img.shields.io/badge/author-Vivek_Bhushan_(@vivek--bhushan)-cyan.svg?style=for-the-badge&color=00f2fe)](https://github.com/vivek-bhushan)

**A high-performance, glassmorphic, in-browser machine learning studio and crowdsourced handwritten digit collection platform.**  
*Collect handwritten digits, benchmark against authentic MNIST data, train neural networks in the browser using Adam optimizer, and manage contributors via an administrative surveillance console.*

[Live Demo](#quick-start) • [Features](#key-features) • [Architecture](#system-architecture) • [Publishing to Web](#public-deployment--tunneling) • [License](#license)

</div>

---

## 📑 Table of Contents
1. [Overview](#overview)
2. [Key Features](#key-features)
   - [Real-Time Handwritten Digit Collection](#1-real-time-handwritten-digit-collection)
   - [Ink-to-Label Dynamic Detection](#2-ink-to-label-dynamic-detection-no-chronological-forcing)
   - [Multi-Round Continuous Practice](#3-multi-round-continuous-practice--auto-saving)
   - [In-Browser Neural Training Studio](#4-in-browser-neural-training-studio)
   - [Admin Surveillance & Contributor Matrix Hub](#5-admin-surveillance--contributor-matrix-hub)
   - [Dedicated Standalone Email-Style Login Gateway](#6-dedicated-standalone-email-style-login-gateway)
3. [Quick Start & Local Setup](#quick-start--local-setup)
4. [Standalone Windows Executable (`.exe`)](#standalone-windows-executable-launcher)
5. [Public Deployment & Tunneling](#public-deployment--tunneling)
6. [System Architecture & File Structure](#system-architecture--file-structure)
7. [Dataset Export Formats](#dataset-export-formats)
8. [Contributing](#contributing)
9. [License & Attribution](#license)

---

## 🌟 Overview

**ARIES** (Adaptive Real-time Intelligent Extraction Studio) is an end-to-end computer vision and neural learning suite designed for crowdsourcing handwritten digit datasets (0–9) and training deep learning models entirely within modern web browsers.

Inspired by research dataset collection workflows (such as HDCA) and production ML pipelines, ARIES eliminates the need for heavyweight Python backends or complex cloud runtimes for data ingestion. Contributors can draw digits on desktop or mobile touchscreens, have their drawings preprocessed in real time (bounding box cropping, aspect-ratio preservation, and center-of-mass alignment into 28×28 tensors), benchmark against authentic MNIST validation samples, and train a multi-layer perceptron directly inside their browser tab.

---

## ⚡ Key Features

### 1. Real-Time Handwritten Digit Collection
* **Hardware-Accelerated HTML5 Canvas**: Smooth sub-pixel stroke interpolation with responsive brush sizes, eraser mode, and clearing controls.
* **MNIST Preprocessing Pipeline**:
  1. *Raw Ink Capture*: High-resolution canvas stroke tracking.
  2. *Bounding Box Crop*: Tight boundary detection around user strokes.
  3. *Aspect-Ratio Preservation & 28×28 Downsampling*: Downscales strokes into standard MNIST dimensions while preserving line weight.
  4. *Center-of-Mass (CoM) Alignment*: Mathematically calculates the centroid of pixel mass and translates the image so the center of mass aligns at $(13.5, 13.5)$ just like authentic MNIST.

### 2. Ink-to-Label Dynamic Detection (No Chronological Forcing)
* **Real-Time Neural Recognition**: As you draw on the canvas, the built-in neural inference engine inspects your stroke dynamics and recognizes the digit you drew (e.g., writing a `9` is immediately recognized as `9`).
* **Free-Form Drawing Order**: Contributors can write digits in any order (e.g., `9`, then `3`, then `7`). The system binds the drawing directly to the written digit, checking it off from the active missing set.
* **Manual Ground-Truth Override**: Clicking any digit selector button (`0–9`) or pressing keyboard keys `0–9` locks the label if you wish to enforce a specific ground-truth label.

### 3. Multi-Round Continuous Practice & Auto-Saving
* **Hands-Free Auto-Save**: Features a snappy 600ms debounce timer that automatically captures and saves your drawing after you finish writing.
* **Flashing Missing Digit Indicators**: Missing digits in the current set pulse with a glowing red perimeter (`missing-flash`), guiding the contributor on what digits are needed.
* **Automatic CSV Generation & Download**: As soon as all 10 digits (`0–9`) are completed for a round, the contributor's personal contribution CSV is automatically generated and downloaded.
* **Seamless Multi-Round Reset**: Within 1 second of completing a set, the studio resets to Round 2 (then Round 3, 4, etc.) for the **same contributor**, allowing continuous multi-round collection without re-logging or page refreshing.
* **⚡ 1-Click Automated Digit Synthesizer**: Synthesizes and captures all missing digits for the active round using authentic MNIST reference templates in zero clicks.

### 4. In-Browser Neural Training Studio
* **Pure Client-Side Neural Network (`AriesModel`)**:
  * Architecture: 784 Input $\to$ 128 Dense (ReLU) $\to$ 64 Dense (ReLU) $\to$ 10 Output (Softmax).
  * Optimizer: **Adam Optimizer** (adaptive first and second moment estimation, bias correction).
  * Loss Function: Categorical Cross-Entropy.
* **Training Modes**:
  * *Adaptive Fine-Tuning*: Transfer-learns from baseline weights, rapidly adapting to new handwriting styles without catastrophic forgetting.
  * *Train from Scratch*: He-normal weight initialization with full backpropagation.
* **Real-Time Visual Telemetry**:
  * Live interactive canvas plotting Training Loss (amber), Training Accuracy (emerald), and Validation Accuracy (cyan) epoch by epoch.
  * Neural terminal outputting weight norm deltas, epoch timings, and loss gradients.
* **Model Deployment**:
  * 1-click hot-swap: Instantly deploy freshly trained weights to the active Drawing Studio and MNIST validation suite.
  * Weight Export: Download trained model weights as a `.json` file or restore baseline weights.

### 5. Admin Surveillance & Contributor Matrix Hub
*Strictly accessible by Administrator Vivek Bhushan (`admin / Muzaffarpur`):*
* **User Credentials Vault**: Surveillance table recording registered user emails, encrypted/stored passwords, roles, and sign-in timestamps. Includes a 1-click **Export Vault CSV** feature.
* **Contributor Intelligence Matrix**: HDCA-inspired dashboard displaying every contributor's sequential progress across digits `0` through `9` with status pills (`Approved`, `Pending Review`, `Rejected`, `Missing`).
* **Submissions Review Console**: 1-click batch review (`Approve` / `Reject`) with an HDCA 3-Stage Inspection Modal (Raw Ink $\to$ Bounding Box $\to$ 28×28 Tensor Array).
* **Master CSV Repository**: Generates and downloads the complete consolidated dataset (all custom practices across all contributors merged with the 200 authentic MNIST validation samples). Restricted exclusively to Vivek Bhushan.
* **Audit Trail**: Real-time operational surveillance logging authentication, collections, training runs, and export actions.

### 6. Dedicated Standalone Email-Style Login Gateway
* **Clean Authentication Flow**: The root URL (`/` or `index.html`) serves as a standalone login portal.
* **Google / Gmail Sign-In**: Authentic Google branding allowing users to enter their email and any password of their choice without third-party OAuth lock-in.
* **Admin Portal**: Confidential admin login portal with hidden credential hints, validating Vivek Bhushan's administrative access.

---

## 🚀 Quick Start & Local Setup

### Prerequisites
* Any modern web browser (Google Chrome, Microsoft Edge, Firefox, Safari, Brave).
* Python 3.x installed (optional, used as a lightweight local HTTP server).

### 1. Clone the Repository
```bash
git clone https://github.com/vivek-bhushan/aries-mnist-studio.git
cd aries-mnist-studio
```

### 2. Launch Local Server
Using Python:
```bash
# Start HTTP server on port 8088
python -m http.server 8088
```

Using Node.js (alternative):
```bash
npx serve -p 8088 .
```

### 3. Open in Browser
* **Login Gateway**: [http://localhost:8088/](http://localhost:8088/) or [http://localhost:8088/index.html](http://localhost:8088/index.html)
* **Drawing Studio**: [http://localhost:8088/studio.html](http://localhost:8088/studio.html)

---

## 🖥️ Standalone Windows Executable Launcher

The repository includes a native C# launcher ([Launcher.cs](file:///Launcher.cs)) that can be compiled into a standalone Windows `.exe` application:

### Compiling `ARIES_Studio.exe`
Open Command Prompt or PowerShell and compile using the built-in Windows .NET Framework compiler:
```powershell
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /out:"ARIES_Studio.exe" /target:winexe "Launcher.cs"
```

### What `ARIES_Studio.exe` Does:
1. Automatically verifies if the local HTTP server on port `8088` is active.
2. If inactive, silently launches the background server.
3. Opens your default web browser directly to the ARIES login interface.

---

## 🌐 Public Deployment & Tunneling

To share your local ARIES studio with remote users or mobile contributors over the public internet:

### Option 1: Cloudflare Tunnel (Recommended — 100% Free, No Account Needed)
1. Download `cloudflared.exe` from the official repository:
   * [Download Cloudflare Tunnel for Windows](https://github.com/cloudflare/cloudflared/releases/latest/download/cloudflared-windows-amd64.exe)
2. Run the tunnel command targeting your local port:
   ```powershell
   .\cloudflared.exe tunnel --url http://localhost:8088
   ```
3. Cloudflare will output a public HTTPS URL (e.g., `https://your-session.trycloudflare.com`). Share this link with any user to allow them to log in, practice, and contribute digits!

### Option 2: ngrok
```powershell
ngrok http 8088
```

### Option 3: GitHub Pages / Static Web Hosting
Because ARIES is built entirely with client-side HTML5, CSS3, and Vanilla JavaScript, the entire repository can be deployed directly onto **GitHub Pages**, **Vercel**, **Netlify**, or **Cloudflare Pages** without any server-side code alterations.

---

## 📂 System Architecture & File Structure

```
aries-mnist-studio/
├── index.html            # Dedicated Standalone Email & Admin Login Gateway
├── login.html            # Mirrored authentication gateway
├── studio.html           # Main Studio (Drawing, Validation, Trainer, Admin Hub)
├── Launcher.cs           # C# source code for 1-click Windows ARIES_Studio.exe
├── README.md             # Comprehensive project documentation
├── CONTRIBUTING.md       # Contribution guidelines
├── DEPLOYMENT.md         # Deployment and public hosting manual
├── LICENSE.md            # MIT License
├── css/
│   ├── app.css           # Core glassmorphic design system & layout
│   └── background.css    # Ambient theme, tone overlays & Mithila artwork styling
├── js/
│   ├── app.js            # Main application controller, sequence tracking & events
│   ├── canvas_processor.js# 28x28 tensor normalization & Center-of-Mass alignment
│   ├── dataset_manager.js# Sample persistence, data augmentation & state store
│   ├── exporter.js       # CSV, JSON, ZIP and PyTorch template generator
│   ├── mnist_model.js    # In-browser neural network, backpropagation & Adam optimizer
│   └── mnist_data.js     # Pre-loaded 200-sample authentic MNIST validation set
└── assets/               # Cultural Mithila artworks, UI icons, and styling assets
```

---

## 📦 Dataset Export Formats

ARIES provides multiple export pipelines for training machine learning models in external frameworks:

1. **CSV Manifest (`.csv`)**:
   - Each row contains: `label`, `p0` through `p783` (grayscale pixel values 0–255), `collector`, `timestamp`, `strokes_count`, `method`, and `status`.
   - Compatible directly with pandas: `pd.read_csv('aries_dataset.csv')`.
2. **Structured ZIP Archive (`.zip`)**:
   - Packages individual $28\times 28$ PNG images sorted into labeled subfolders (`0/`, `1/`, ..., `9/`).
   - Includes `manifest.csv` and an auto-generated `train_pytorch.py` ready for `torchvision.datasets.ImageFolder`.
3. **JSON Manifest (`.json`)**:
   - Complete serialized object array including base64 image data URLs and tensor metrics.
4. **Surveillance & Audit Logs (`.json`)**:
   - Full chronological audit stream for security compliance and tracking.

---

## 🤝 Contributing

Contributions to ARIES are welcome! Please review [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on code formatting, PR submission, and architectural principles.

---

## 📜 License

Distributed under the **MIT License**. See [LICENSE.md](LICENSE.md) for full details.

Developed with ❤️ by **Vivek Bhushan** ([@vivek-bhushan](https://github.com/vivek-bhushan)).
