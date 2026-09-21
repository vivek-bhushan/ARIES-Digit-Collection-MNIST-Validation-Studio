# Contributing to ARIES

Thank you for your interest in contributing to **ARIES — Handwritten Digit Collection & In-Browser Neural Network Studio**! This document provides guidelines for contributing to the repository.

---

## 📋 Code of Conduct

Please help us keep this project a welcoming, respectful, and productive environment for all contributors. Treat fellow community members with courtesy and constructive feedback.

---

## 🛠️ Development Workflow

### 1. Fork & Clone
1. Fork the repository on GitHub.
2. Clone your fork locally:
   ```bash
   git clone https://github.com/vivek-bhushan/aries-mnist-studio.git
   cd aries-mnist-studio
   ```

### 2. Running Locally
Because ARIES is built using vanilla web technologies (HTML5, Vanilla CSS3, Canvas API, and pure JavaScript), no heavy build steps (Webpack, Vite, or Babel) are strictly required.

Start a lightweight HTTP server in the repository root:
```bash
# Using Python
python -m http.server 8088

# Or using Node
npx serve -p 8088 .
```

Open your browser at `http://localhost:8088/index.html`.

---

## 🏛️ Architectural Principles

When adding features or modifying existing code, please adhere to these core design tenets:

1. **Zero External Runtime Dependencies**:
   - The neural inference engine, Adam optimizer, canvas preprocessing, and Center-of-Mass calculations are implemented in pure vanilla JavaScript (`mnist_model.js`, `canvas_processor.js`).
   - Avoid introducing heavy external npm frameworks or multi-megabyte bundle dependencies unless strictly necessary.

2. **Hardware-Accelerated HTML5 Canvas Performance**:
   - Canvas operations must remain responsive and non-blocking (aim for 60 FPS drawing).
   - Heavy operations (e.g. neural training backprop iterations) should yield to the browser rendering loop using `requestAnimationFrame` or `setTimeout` ticks.

3. **Ink-to-Label Real-Time Binding**:
   - Drawings on the canvas must bind dynamically to the digit actually written by the user rather than forcing chronological sequences.
   - Ground-truth manual overrides (`userExplicitDigit`) must always take precedence when manually clicked by the user.

4. **Multi-Round Continuum**:
   - When a user completes drawing digits 0–9 for a round, the system must auto-generate their contribution CSV and immediately reset for subsequent rounds from the same contributor without page reloading.

5. **Security & Surveillance Isolation**:
   - The Admin Surveillance Hub (Tab 6), Credentials Vault, and Master CSV Export must remain strictly restricted to Administrator Vivek Bhushan.
   - Regular users must only have access to their personal practice data and contribution exports.

---

## 📝 Pull Request Guidelines

1. **Create a Topic Branch**:
   ```bash
   git checkout -b feature/my-new-feature
   ```
2. **Make Small, Focused Commits**:
   Write clear, descriptive commit messages describing *what* and *why*.
3. **Test in Modern Browsers**:
   Verify your changes in Chrome, Firefox, and Edge before submitting.
4. **Submit a Pull Request**:
   - Provide a concise summary of the problem solved and the implementation details.
   - Include screenshots or short screen captures for any UI alterations.

---

## 📬 Questions & Support

If you encounter any bugs or have feature requests, please open an Issue on GitHub. For administrative inquiries, contact **Vivek Bhushan** (`owner`).
