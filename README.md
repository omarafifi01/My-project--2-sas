# 🚗 AR Auto Showroom

An augmented reality (AR) application developed in Unity that showcases interactive 3D car models using both **marker-based** and **markerless** AR. Built for Android using **AR Foundation** and **ARCore**, this app serves as a demo for car feature exploration in a real-world environment.

---

## 📱 Features

### Markerless AR Scene
- Tap to place a car on a real-world plane
- Start engine with sound 
- Change car color (cycles through predefined palette)
- Play car voiceover (30-second TTS description)
- Remove car
- Floating UI for interaction

### Marker-Based AR Scene
- Scan a **Jeep logo** to spawn the vehicle
- Anchored prefab precisely over the marker
- Same interaction features as markerless scene

---

## 🛠 Tech Stack

- **Engine:** Unity 2022.3.6f1
- **XR SDK:** AR Foundation + ARCore XR Plugin
- **Target Platform:** Android
- **Development Tool:** Visual Studio + GitHub

---


##  How to Run

1. Clone the repo and open the project in **Unity 2022.3.6f1**
2. Switch platform to Android (`File > Build Settings`)
3. Add both scenes to build settings
4. Connect ARCore-supported Android phone via USB
5. Click **Build and Run**

> Note: Some older Samsung devices (e.g., Galaxy A7 2017) may not support ARCore.

---

## 📈 Performance

- ~24K vertices per car model
- Optimized for mid-range Android devices
- Uses compressed WAV files and low-overhead UI

---

##  Debugging Tools

- In-app world-space floating panel shows:
  - FPS
  - Tracking state


## 🙋‍♂️ Author

**Omar Afifi**  
AI & Data Science Student – ESLSCA University  