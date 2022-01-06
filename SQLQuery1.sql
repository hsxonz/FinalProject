CREATE DATABASE QLKHO

USE QLKHO

CREATE TABLE ACCOUNT(
	taikhoan nvarchar(50),
	matkhau nvarchar(50),
)

CREATE TABLE PRODUCT(
	MaHang Nvarchar(50) PRIMARY KEY,
	TenHang  Nvarchar(50),
	Soluong int,
	DonGiaBan float,
	DonGiaNhap float,
)

CREATE TABLE HOADON(
	MaHang Nvarchar(50),
	MaHoaDon Nvarchar(50),
	NgayNhap Date ,
	PRIMARY KEY (MaHang , MaHoaDon) 
)

CREATE TABLE HOADONXUAT(
	MaHoaDon Nvarchar(50),
	daily nvarchar(50),
	NgayXuat Date ,
	PRIMARY KEY ( MaHoaDon) 
)

Create table chiTietHoaDon(
	MaHang Nvarchar(50),
	MaHoaDon Nvarchar(50),
	Soluong int,
	PRIMARY KEY (MaHang, MaHoaDon) 
)

ALTER TABLE HOADON ADD FOREIGN KEY  (MaHang) REFERENCES PRODUCT(MaHang)
ALTER TABLE chiTietHoaDon ADD FOREIGN KEY  (MaHoaDon) REFERENCES HOADONXUAT(MaHoaDon)
ALTER TABLE chiTietHoaDon ADD FOREIGN KEY  (MaHang) REFERENCES PRODUCT(MaHang)

insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A1', 'Coca cola' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A2', 'Pepsi' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A3', 'Strong bold' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A4', 'Minidar' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A5', 'Moutain dex' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A6', 'Corona' , 100, 20000, 10000);
insert into PRODUCT(MaHang, TenHang, Soluong, DonGiaBan,  DonGiaNhap) values('A7', 'Tiger' , 100, 20000, 10000);


insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A1', 'HD1', '07/07/2021');
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A2', 'HD1', '07/07/2021' );
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A3', 'HD2', '07/08/2021');
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A4', 'HD2',  '07/08/2021');
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A5', 'HD2',  '07/08/2021');
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A6', 'HD1',  '07/07/2021');
insert into HOADON(MaHang, MaHoaDon, NgayNhap) values('A7', 'HD3',  '07/06/2021');

insert into HOADONXUAT(daily,MaHoaDon, NgayXuat) values('Vinamilk', 'XK1',  '10/07/2021');
insert into HOADONXUAT(daily, MaHoaDon, NgayXuat) values('Vinamilk', 'XK2',  '10/07/2021');
insert into HOADONXUAT(daily, MaHoaDon, NgayXuat) values('Vinamilk', 'XK3',  '11/07/2021');
insert into HOADONXUAT(daily , MaHoaDon, NgayXuat) values('Vinamilk', 'XK4',  '11/07/2021');
insert into HOADONXUAT(daily , MaHoaDon, NgayXuat) values('Vinamilk', 'XK5',   '11/07/2021');
insert into HOADONXUAT(daily, MaHoaDon, NgayXuat) values('Vinamilk', 'XK6',   '11/07/2021');
insert into HOADONXUAT(daily , MaHoaDon, NgayXuat) values('Vinamilk', 'XK7',   '11/07/2021');

insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A1','XK1',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A1','XK2',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A2','XK1',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A3','XK1',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A4','XK1',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A1','XK3',10);
insert into chiTietHoaDon (MaHang, MaHoaDon,Soluong) values('A1','XK4',10);

DELETE  FROM HOADON
DELETE  FROM PRODUCT

select PRODUCT.MaHang,TenHang,chiTietHoaDon.Soluong from chiTietHoaDon 
join PRODUCT on chiTietHoaDon.MaHang = PRODUCT.MaHang
where MaHoaDon = 'XKK'

select distinct PRODUCT.MaHang,TenHang,chiTietHoaDon.Soluong,chiTietHoaDon.MaHoaDon from PRODUCT 
inner JOIN chiTietHoaDon on chiTietHoaDon.MaHang in (select MaHang from chiTietHoaDon where MaHoaDon = 'XKk')  
where PRODUCT.MaHang in (select MaHang from chiTietHoaDon where MaHoaDon = 'XKk') 

select * from HOADON
select * from HOADONXUAT
select Distinct MaHoaDon,NgayNhap from HOADON

UPDATE PRODUCT
SET Soluong = Soluong + 100
WHERE MaHang = 'A1';
select * from PRODUCT


UPDATE PRODUCT
SET TenHang='Coca',Soluong = 100, DonGiaBan = 10000, DonGiaNhap=10000
WHERE MaHang in (select MaHang from HOADON where MaHang = 'A1' and MaHoaDon ='HD1');


select * from HOADONXUAT where MaHoaDon = 'XK1'

SELECT * FROM chiTietHoaDon

update chiTietHoaDon  set Soluong= Soluong +10   where MaHoaDon = 'XKK' and MaHang = 'A1'


DELETE FROM chiTietHoaDon where MaHoaDon = 'XKK' and MaHang = 'A1' 

