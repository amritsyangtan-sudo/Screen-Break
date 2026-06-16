<div align="center">

# ScreenBreak

**A cross-platform desktop app to remind you to take breaks and protect your eyes.**  
Built with **C#**, **Avalonia UI**, and **MVVM** architecture.

![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux%20%7C%20macOS-blue?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![UI](https://img.shields.io/badge/UI-Avalonia-purple?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-In%20Development-red?style=for-the-badge)

> 🧠 *"Take breaks. Protect your eyes."* — Built for developers and anyone spending long hours in front of a screen.

</div>

---

## 📸 Screenshot

> Dashboard — Work timer, session info, break statistics, and progress tracking.

![screenBreak Dashboard](Assets/Screenshot.png)


## ✨ Features

| Feature | Description |
|---|---|
| ⏱️ **Work Timer** | Circular countdown timer showing remaining work session time |
| 🟢 **Break Reminders** | Automatic break scheduling with configurable intervals |
| 👁️ **Eye Rest Guidance** | Suggested eye exercises during break time |
| 📊 **Break Statistics** | Tracks today's breaks, total breaks, and focus time |
| 📈 **Progress Tracking** | Daily goal, current streak, and success rate |
| ⏸️ **Pause & Skip** | Full session control — pause or skip the current break |
| 🕘 **Break History** | Review past break sessions |
| ⚙️ **Settings** | Customize timer intervals and preferences |

---


## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Clone & Run

```bash
git clone https://github.com/amritsyangtan-sudo/Screen-Break.git
cd Screen-Break
dotnet run
```

### Build

```bash
dotnet build
```

### Publish (Windows self-contained)

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

---