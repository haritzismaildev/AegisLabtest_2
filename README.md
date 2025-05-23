AegisLabsCRUD
🚀 ASP.NET Core Web Application dengan ADO.NET & Stored Procedure untuk Ekspor Excel dan PDF

📌 Deskripsi Proyek
Proyek ini adalah aplikasi berbasis ASP.NET Core yang memungkinkan pengguna mengelola data melalui CRUD, 
serta melakukan ekspor Excel dan PDF menggunakan ADO.NET dengan Stored Procedure di Microsoft SQL Server
tanpa menggunakan ORM seperti Entity Framework.

🔧 Fitur Utama
✔ CRUD Data dengan SQL Server 
✔ Ekspor Data ke Excel menggunakan ClosedXML 
✔ Ekspor Data ke PDF menggunakan Rotativa 
✔ Repository Pattern untuk pemisahan akses database 
✔ Stored Procedure untuk pengambilan data

🏗 Arsitektur dan Struktur Proyek
AegisLabsCRUD/
│── Controllers/
│   ├── DataController.cs
│── Models/
│   ├── DataModel.cs
│── Views/
│   ├── Data/
│   │   ├── Index.cshtml
│   │   ├── ExportPdf.cshtml
│── DataAccess/
│   ├── DbHelper.cs
│── Repositories/
│   ├── DataRepository.cs
│── wwwroot/
│   ├── Rotativa/
│       ├── wkhtmltopdf.exe
│── Program.cs
│── appsettings.json
│── README.md

📌 Repository Pattern memastikan pemisahan antara logika bisnis dan akses database, sehingga kode lebih mudah dikelola dan dikembangkan.

⚙ Persyaratan dan Instalasi

1️⃣ Clone Repository
Sh
git clone https://github.com/username/AegisLabsCRUD.git
cd AegisLabsCRUD

2️⃣ Konfigurasi Database
✔ Pastikan Microsoft SQL Server terinstal. ✔ Buat database dengan script berikut:
Sql
CREATE DATABASE AegisLabsDB;
USE AegisLabsDB;

CREATE TABLE DataModel (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nama NVARCHAR(100) NOT NULL,
    Tanggal DATETIME NOT NULL
);

✔ Tambahkan Stored Procedure:
Sql
CREATE PROCEDURE GetData
AS
BEGIN
    SELECT Id, Nama, Tanggal FROM DataModel;
END;

✔ Masukkan Data Dummy:
Sql
INSERT INTO DataModel (Nama, Tanggal) VALUES 
('Haritz', '2025-05-23'),
('Dimas', '2025-05-22'),
('Nadia', '2025-05-21');

3️⃣ Install Dependencies
Sh
dotnet restore
dotnet build

4️⃣ Jalankan Aplikasi
Sh
dotnet run

🛠 Cara Menggunakan
Fitur	      URL
Lihat Data	http://localhost:5000/Data/Index
Export Excel	http://localhost:5000/Data/ExportExcel
Export PDF	http://localhost:5000/Data/ExportPdf

💡 Tombol untuk ekspor tersedia di halaman utama (Index.cshtml).

📌 Kontributor & Lisensi
👨‍💻 Dikembangkan oleh: Haritz 📜 Lisensi: null
