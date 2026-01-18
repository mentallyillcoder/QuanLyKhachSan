-- Tạo database QuanLyKhachSan1 nếu chưa có
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyKhachSan1')
BEGIN
    CREATE DATABASE QuanLyKhachSan1;
END
GO

USE QuanLyKhachSan1;
GO

-- Tạo bảng TAIKHOAN
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TAIKHOAN' AND xtype='U')
BEGIN
    CREATE TABLE TAIKHOAN (
        Username NVARCHAR(50) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        Password NVARCHAR(50) NOT NULL,
        LoaiTaiKhoan NVARCHAR(20) NOT NULL,
        Email NVARCHAR(100)
    );
    
    -- Thêm tài khoản mặc định
    INSERT INTO TAIKHOAN VALUES 
    ('admin', N'Quản trị viên', 'admin', N'Quản lý','24520584@gm.uit.edu.vn'),
    ('letan01', N'Lễ tân 1', '123456', N'Nhân viên','Buibabong2k6@gmail.com');
END
GO

-- Tạo bảng LOAIPHONG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LOAIPHONG' AND xtype='U')
BEGIN
    CREATE TABLE LOAIPHONG (
        IDLoaiPhong INT IDENTITY(1,1) PRIMARY KEY,
        TenLoaiPhong NVARCHAR(50) NOT NULL,
        DonGia DECIMAL(18,0) NOT NULL,
        LoaiGiuong NVARCHAR(50) NOT NULL
    );
    
    -- Thêm dữ liệu mẫu
    INSERT INTO LOAIPHONG (TenLoaiPhong, DonGia, LoaiGiuong) VALUES 
    (N'Standard', 500000, N'Đơn'),
    (N'Deluxe', 800000, N'Đôi'),
    (N'Suite', 1200000, N'King');
END
GO

-- Tạo bảng PHONG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PHONG' AND xtype='U')
BEGIN
    CREATE TABLE PHONG (
        IDPhong NVARCHAR(10) PRIMARY KEY,
        TenPhong NVARCHAR(50) NOT NULL,
        IDLoaiPhong INT NOT NULL,
        TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Trống',
        FOREIGN KEY (IDLoaiPhong) REFERENCES LOAIPHONG(IDLoaiPhong)
    );
    
    -- Thêm phòng mẫu
    INSERT INTO PHONG VALUES 
    ('P101', N'Phòng 101', 1, N'Trống'),
    ('P102', N'Phòng 102', 1, N'Trống'),
    ('P103', N'Phòng 103', 2, N'Trống'),
    ('P201', N'Phòng 201', 2, N'Trống'),
    ('P301', N'Phòng 301 VIP', 3, N'Trống');
END
GO

-- Tạo bảng KHACHHANG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='KHACHHANG' AND xtype='U')
BEGIN
    CREATE TABLE KHACHHANG (
        IDKhachHang INT IDENTITY(1,1) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        CCCD NVARCHAR(20),
        SoDienThoai NVARCHAR(15),
        DiaChi NVARCHAR(200)
    );
    
    -- Thêm khách hàng mẫu
    INSERT INTO KHACHHANG (HoTen, CCCD, SoDienThoai) VALUES 
    (N'Nguyễn Văn A', '123456789012', '0901234567'),
    (N'Trần Thị B', '987654321098', '0987654321');
END
GO

-- Tạo bảng PHIEUDATPHONG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PHIEUDATPHONG' AND xtype='U')
BEGIN
    CREATE TABLE PHIEUDATPHONG (
        IDPhieuDat INT IDENTITY(1,1) PRIMARY KEY,
        IDKhachHang INT NOT NULL,
        NgayLapPhieu DATETIME DEFAULT GETDATE(),
        NgayCheckIn DATETIME,
        NgayCheckOut DATETIME,
        SoNguoi INT,
        TrangThai NVARCHAR(50) NOT NULL,
        UsernameNV NVARCHAR(50),
        TongTienHoaDon DECIMAL(18,0),
        FOREIGN KEY (IDKhachHang) REFERENCES KHACHHANG(IDKhachHang),
        FOREIGN KEY (UsernameNV) REFERENCES TAIKHOAN(Username)
    );
END
GO

-- Tạo bảng CHITIET_PHIEUDATPHONG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CHITIET_PHIEUDATPHONG' AND xtype='U')
BEGIN
    CREATE TABLE CHITIET_PHIEUDATPHONG (
        IDPhieuDat INT NOT NULL,
        IDPhong NVARCHAR(10) NOT NULL,
        SoNguoi INT NOT NULL,
        NgayBatDau DATETIME NOT NULL,
        NgayKetThuc DATETIME NOT NULL,
        DonGia DECIMAL(18,0) NOT NULL,
        PRIMARY KEY (IDPhieuDat, IDPhong),
        FOREIGN KEY (IDPhieuDat) REFERENCES PHIEUDATPHONG(IDPhieuDat),
        FOREIGN KEY (IDPhong) REFERENCES PHONG(IDPhong)
    );
END
GO

-- Tạo bảng DICHVU
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DICHVU' AND xtype='U')
BEGIN
    CREATE TABLE DICHVU (
        IDDichVu INT IDENTITY(1,1) PRIMARY KEY,
        TenDichVu NVARCHAR(100) NOT NULL,
        DonGia DECIMAL(18,0) NOT NULL
    );
    
    -- Thêm dịch vụ mẫu
    INSERT INTO DICHVU (TenDichVu, DonGia) VALUES 
    (N'Bia lon', 20000),
    (N'Nước suối', 10000),
    (N'Massage', 200000),
    (N'Giặt ủi', 50000);
END
GO

-- Tạo bảng CHITIET_DICHVU
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CHITIET_DICHVU' AND xtype='U')
BEGIN
    CREATE TABLE CHITIET_DICHVU (
        IDPhieuDat INT NOT NULL,
        IDDichVu INT NOT NULL,
        SoLuong INT NOT NULL,
        DonGia DECIMAL(18,0) NOT NULL,
        ThanhTien AS (SoLuong * DonGia) PERSISTED, -- Computed column được lưu trữ
        PRIMARY KEY (IDPhieuDat, IDDichVu),
        FOREIGN KEY (IDPhieuDat) REFERENCES PHIEUDATPHONG(IDPhieuDat),
        FOREIGN KEY (IDDichVu) REFERENCES DICHVU(IDDichVu)
    );
    
    PRINT 'Đã tạo bảng CHITIET_DICHVU với cột ThanhTien tự động tính';
END
ELSE
BEGIN
    -- Kiểm tra và thêm cột ThanhTien nếu chưa có
    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CHITIET_DICHVU' AND COLUMN_NAME = 'ThanhTien')
    BEGIN
        ALTER TABLE CHITIET_DICHVU ADD ThanhTien AS (SoLuong * DonGia) PERSISTED;
        PRINT 'Đã thêm cột ThanhTien vào bảng CHITIET_DICHVU';
    END
END
GO

-- Tạo bảng HOADON
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HOADON' AND xtype='U')
BEGIN
    CREATE TABLE HOADON (
        IDHoaDon INT IDENTITY(1,1) PRIMARY KEY,
        IDPhieuDat INT NOT NULL,
        NgayThanhToan DATETIME NOT NULL,
        TongTien DECIMAL(18,0) NOT NULL,
        FOREIGN KEY (IDPhieuDat) REFERENCES PHIEUDATPHONG(IDPhieuDat)
    );
END
GO

PRINT 'Database QuanLyKhachSan1 đã được tạo thành công!';