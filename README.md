# 🔮 Predictor de Tendencia de Activos (Acciones / Criptomonedas)

Sistema desarrollado en ASP.NET Core MVC para predecir la tendencia futura de un activo financiero (acción o criptomoneda) a partir de datos históricos. La aplicación permite al usuario elegir entre diferentes modos de predicción para analizar los valores ingresados y determinar si el comportamiento del activo será alcista o bajista.

---

##  Objetivo General

Crear una aplicación web con ASP.NET Core que permita predecir el valor de un activo financiero utilizando algoritmos estadísticos simples integrados en un patrón de arquitectura MVC.

---

## Funcionalidades Generales

### 📈 Modos de Predicción

Pantalla con un formulario que permite seleccionar el **modo de predicción** a utilizar (por defecto: SMA Crossover). La opción elegida se guarda en memoria (usando patrón Singleton).

## 🔬 Detalle de los Modos

### 1️⃣ Media Móvil Simple (SMA) Crossover

- **SMA Corta:** Promedio de los últimos 5 valores.
- **SMA Larga:** Promedio de los 20 valores.
- **Resultado:**  
  - Si SMA corta > SMA larga → Tendencia **alcista**
  - Si SMA corta < SMA larga → Tendencia **bajista**

### 2️⃣ Regresión Lineal

- Calcula una recta `y = mx + b` con los datos de los 20 días.
- Proyecta el valor del activo en el día 21.
- Determina la tendencia según la **pendiente (m)**:
  - `m > 0` → Alcista
  - `m < 0` → Bajista

### 3️⃣ Momentum (ROC)

- Fórmula: `ROC = ((Vt / Vt-n) - 1) * 100`
- Se fija `n = 5`
- Calcula la velocidad de cambio cada 5 días.
- Muestra la evolución del ROC en una tabla

---

## Requisitos Técnicos

- ✔️ ASP.NET Core MVC
- ✔️ Arquitectura por capas:
  - Capa Web (UI)
  - Capa de Lógica de Negocio
- ✔️ Uso de `ViewModels` con validaciones
- ✔️ Uso de `DTOs` para transferencia de datos entre servicios
- ✔️ Interfaz visual clara usando Bootstrap (o framework CSS equivalente)

